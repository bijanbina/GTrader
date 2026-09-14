using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GTrader
{
    public class PriceHistoryService : IDisposable
    {
        private const int MaximumAttempts = 3;
        private const int MaximumGapDays = 10;
        private const int RequestTimeoutSeconds = 30;
        private const int MaximumRetryDelaySeconds = 30;
        private const string PrimaryHost = "https://query1.finance.yahoo.com";
        private const string FallbackHost = "https://query2.finance.yahoo.com";
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly TimeZoneInfo NewYork = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        private readonly HttpClient client;
        private bool disposed;

        public PriceHistoryService()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(RequestTimeoutSeconds);
            client.MaxResponseContentBufferSize = 8 * 1024 * 1024;
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) GTrader/1.0");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public static string ProviderSymbol(string symbol)
        {
            return NormalizeSymbol(symbol).Replace('.', '-');
        }

        public async Task<StockSnapshot> FetchAsync(string symbol, DateTime anchorDate, CancellationToken token)
        {
            if (disposed) throw new ObjectDisposedException("PriceHistoryService");
            token.ThrowIfCancellationRequested();
            symbol = NormalizeSymbol(symbol);
            anchorDate = ValidateAnchor(anchorDate);
            string requestPath = BuildRequestPath(symbol, anchorDate);
            bool useFallback = false;

            for (int attempt = 0; attempt < MaximumAttempts; attempt++)
            {
                token.ThrowIfCancellationRequested();
                string sourceUrl = (useFallback ? FallbackHost : PrimaryHost) + requestPath;
                HttpResponseMessage response = null;
                // Only transport failures choose the alternate host. HTTP errors, including
                // rate limiting, never bypass the server's response by changing hosts.
                try
                {
                    response = await client.GetAsync(sourceUrl, HttpCompletionOption.ResponseContentRead, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException ex)
                {
                    token.ThrowIfCancellationRequested();
                    if (attempt == MaximumAttempts - 1)
                        throw new TimeoutException("Yahoo price requests timed out for " + symbol + " (" + RequestTimeoutSeconds + " seconds per attempt).", ex);
                    useFallback = true;
                }
                catch (HttpRequestException ex)
                {
                    token.ThrowIfCancellationRequested();
                    if (attempt == MaximumAttempts - 1)
                        throw new HttpRequestException("Unable to reach Yahoo's price service for " + symbol + " after " + MaximumAttempts + " attempts. " + ex.Message, ex);
                    useFallback = true;
                }
                if (response == null)
                {
                    await Task.Delay(TimeSpan.FromSeconds(attempt + 1), token).ConfigureAwait(false);
                    continue;
                }

                using (response)
                {
                    token.ThrowIfCancellationRequested();
                    int status = (int)response.StatusCode;
                    if (!response.IsSuccessStatusCode)
                    {
                        bool transient = status == 429 || (status >= 500 && status <= 599);
                        TimeSpan retryDelay = RetryDelay(response, attempt);
                        if (transient && attempt < MaximumAttempts - 1 && retryDelay <= TimeSpan.FromSeconds(MaximumRetryDelaySeconds))
                        {
                            await Task.Delay(retryDelay, token).ConfigureAwait(false);
                            continue;
                        }
                        string message = status == 429
                            ? "Yahoo rate-limited the request for " + symbol + ". Please try again later."
                            : "Yahoo could not provide price history for " + symbol + ".";
                        message += " HTTP " + status.ToString(CultureInfo.InvariantCulture) + " (" + response.ReasonPhrase + ").";
                        if (transient && retryDelay > TimeSpan.FromSeconds(MaximumRetryDelaySeconds))
                            message += " The server requested a wait of " + Math.Ceiling(retryDelay.TotalSeconds).ToString(CultureInfo.InvariantCulture) + " seconds; no earlier retry was made.";
                        throw new InvalidOperationException(message);
                    }

                    string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    token.ThrowIfCancellationRequested();
                    StockSnapshot snapshot = Parse(symbol, anchorDate, json);
                    token.ThrowIfCancellationRequested();
                    snapshot.SourceUrl = sourceUrl;
                    return snapshot;
                }
            }
            throw new InvalidOperationException("Yahoo price retrieval did not complete for " + symbol + ".");
        }

        public static StockSnapshot Parse(string symbol, DateTime anchorDate, string json)
        {
            symbol = NormalizeSymbol(symbol);
            anchorDate = ValidateAnchor(anchorDate);
            if (String.IsNullOrWhiteSpace(json)) throw new FormatException("Yahoo returned an empty price response for " + symbol + ".");
            object decoded;
            try
            {
                var serializer = new JavaScriptSerializer { MaxJsonLength = 8 * 1024 * 1024, RecursionLimit = 64 };
                decoded = serializer.DeserializeObject(json);
            }
            catch (ArgumentException ex)
            {
                throw new FormatException("Yahoo returned invalid price JSON for " + symbol + ".", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new FormatException("Yahoo returned invalid price JSON for " + symbol + ".", ex);
            }

            var chart = AsObject(Get(AsObject(decoded), "chart"));
            if (chart == null) throw new FormatException("Yahoo's price response is missing its chart data for " + symbol + ".");
            object errorValue = Get(chart, "error");
            if (errorValue != null)
            {
                var error = AsObject(errorValue);
                string code = AsText(Get(error, "code"));
                string description = AsText(Get(error, "description"));
                throw new InvalidOperationException("Yahoo price error for " + symbol + ": " + (code ?? "unavailable") + (String.IsNullOrEmpty(description) ? "." : " - " + description));
            }
            var result = FirstObject(Get(chart, "result"));
            if (result == null) throw new InvalidOperationException("Yahoo returned no price history for " + symbol + ".");
            var meta = AsObject(Get(result, "meta"));
            string returnedSymbol = AsText(Get(meta, "symbol"));
            if (!String.IsNullOrWhiteSpace(returnedSymbol) && !String.Equals(ProviderSymbol(returnedSymbol), ProviderSymbol(symbol), StringComparison.Ordinal))
                throw new InvalidOperationException("Yahoo returned " + returnedSymbol + " when " + symbol + " was requested.");

            var timestamps = AsArray(Get(result, "timestamp"));
            var indicators = AsObject(Get(result, "indicators"));
            var closes = AsArray(Get(FirstObject(Get(indicators, "quote")), "close"));
            var adjustedCloses = AsArray(Get(FirstObject(Get(indicators, "adjclose")), "adjclose"));
            var bars = new List<Bar>();
            if (timestamps != null && closes != null)
            {
                int count = Math.Min(timestamps.Count, closes.Count);
                for (int i = 0; i < count; i++)
                {
                    DateTime timestamp;
                    double? close = PositiveNumber(closes[i]);
                    if (!close.HasValue || !TryUnixTime(timestamps[i], out timestamp)) continue;
                    bars.Add(new Bar
                    {
                        TimestampUtc = timestamp,
                        Date = NewYorkDate(timestamp),
                        Close = close.Value,
                        AdjustedClose = adjustedCloses != null && i < adjustedCloses.Count ? PositiveNumber(adjustedCloses[i]) : null,
                        Sequence = i
                    });
                }
            }
            bars.Sort(delegate(Bar a, Bar b)
            {
                int resultOrder = a.TimestampUtc.CompareTo(b.TimestampUtc);
                return resultOrder == 0 ? a.Sequence.CompareTo(b.Sequence) : resultOrder;
            });

            var snapshot = new StockSnapshot
            {
                Symbol = symbol,
                Currency = AsText(Get(meta, "currency")),
                AnchorDate = anchorDate,
                FetchedAtUtc = DateTime.UtcNow,
                Prices = new PriceObservation[7],
                SourceUrl = PrimaryHost + BuildRequestPath(symbol, anchorDate)
            };
            DateTime[] targets = PriceMath.TargetDates(anchorDate);
            for (int i = 0; i < targets.Length; i++)
            {
                Bar bar = FindBar(bars, targets[i]);
                snapshot.Prices[i] = bar == null ? new PriceObservation() : new PriceObservation
                {
                    // Yahoo close already reflects stock splits. Do not apply split events again.
                    Close = bar.Close,
                    AdjustedClose = bar.AdjustedClose,
                    Date = bar.Date
                };
            }

            DateTime quoteAt;
            double? quote = PositiveNumber(Get(meta, "regularMarketPrice"));
            if (quote.HasValue && TryUnixTime(Get(meta, "regularMarketTime"), out quoteAt))
            {
                DateTime quoteDate = NewYorkDate(quoteAt);
                Bar latestBar = FindBar(bars, anchorDate);
                if (quoteDate <= anchorDate && (anchorDate - quoteDate).TotalDays <= MaximumGapDays &&
                    (latestBar == null || quoteAt >= latestBar.TimestampUtc))
                {
                    snapshot.Prices[0] = new PriceObservation
                    {
                        Close = quote.Value,
                        // A current quote is already in current-share/current-dividend units.
                        AdjustedClose = quote.Value,
                        Date = quoteDate
                    };
                    snapshot.QuoteAtUtc = quoteAt;
                }
            }
            // Daily chart timestamps usually denote the session open, not the close.
            // A closing-bar fallback therefore has only Prices[0].Date, no quote timestamp.
            if (bars.Count == 0 && !snapshot.Prices[0].Close.HasValue)
                throw new InvalidOperationException("Yahoo returned no usable daily prices or recent quote for " + symbol + ".");
            return snapshot;
        }

        private static Bar FindBar(List<Bar> bars, DateTime target)
        {
            for (int i = bars.Count - 1; i >= 0; i--)
            {
                if (bars[i].Date > target) continue;
                return (target - bars[i].Date).TotalDays <= MaximumGapDays ? bars[i] : null;
            }
            return null;
        }

        private static string BuildRequestPath(string symbol, DateTime anchorDate)
        {
            DateTime start = anchorDate.AddYears(-5).AddDays(-MaximumGapDays);
            DateTime tomorrow = NewYorkDate(DateTime.UtcNow).AddDays(1);
            long period1 = UnixSeconds(TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(start, DateTimeKind.Unspecified), NewYork));
            long period2 = UnixSeconds(TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(tomorrow, DateTimeKind.Unspecified), NewYork));
            return "/v8/finance/chart/" + Uri.EscapeDataString(ProviderSymbol(symbol)) + "?period1=" + period1.ToString(CultureInfo.InvariantCulture)
                + "&period2=" + period2.ToString(CultureInfo.InvariantCulture) + "&interval=1d&includeAdjustedClose=true&events=div%2Csplits&includePrePost=false";
        }

        private static TimeSpan RetryDelay(HttpResponseMessage response, int attempt)
        {
            if (response.Headers.RetryAfter != null)
            {
                TimeSpan delay = response.Headers.RetryAfter.Delta ?? (response.Headers.RetryAfter.Date.HasValue
                    ? response.Headers.RetryAfter.Date.Value - DateTimeOffset.UtcNow : TimeSpan.Zero);
                return delay > TimeSpan.Zero ? delay : TimeSpan.Zero;
            }
            return TimeSpan.FromSeconds(attempt + 1);
        }

        private static string NormalizeSymbol(string symbol)
        {
            if (String.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("A stock symbol is required.", "symbol");
            symbol = symbol.Trim().ToUpperInvariant();
            if (symbol.Length > 32) throw new ArgumentException("The stock symbol is too long.", "symbol");
            foreach (char c in symbol)
                if (!((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '.' || c == '-'))
                    throw new ArgumentException("The stock symbol contains an unsupported character.", "symbol");
            return symbol;
        }

        private static DateTime ValidateAnchor(DateTime anchorDate)
        {
            anchorDate = DateTime.SpecifyKind(anchorDate.Date, DateTimeKind.Unspecified);
            if (anchorDate < new DateTime(6, 1, 11)) throw new ArgumentOutOfRangeException("anchorDate", "The anchor must allow five years and ten days of history.");
            return anchorDate;
        }

        private static DateTime NewYorkDate(DateTime utc) { return TimeZoneInfo.ConvertTimeFromUtc(utc, NewYork).Date; }
        private static long UnixSeconds(DateTime utc) { return (long)(utc - UnixEpoch).TotalSeconds; }
        private static IDictionary<string, object> AsObject(object value) { return value as IDictionary<string, object>; }
        private static IList AsArray(object value) { return value as IList; }
        private static object Get(IDictionary<string, object> value, string key)
        {
            object result;
            return value != null && value.TryGetValue(key, out result) ? result : null;
        }
        private static IDictionary<string, object> FirstObject(object value)
        {
            IList array = AsArray(value);
            return array != null && array.Count > 0 ? AsObject(array[0]) : null;
        }
        private static string AsText(object value) { return value as string; }
        private static double? PositiveNumber(object value)
        {
            double number;
            if (!TryNumber(value, out number) || number <= 0) return null;
            return number;
        }
        private static bool TryNumber(object value, out double number)
        {
            number = 0;
            return value != null && !(value is Boolean) && Double.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Float, CultureInfo.InvariantCulture, out number)
                && !Double.IsNaN(number) && !Double.IsInfinity(number);
        }
        private static bool TryUnixTime(object value, out DateTime timestamp)
        {
            timestamp = default(DateTime);
            double seconds;
            if (!TryNumber(value, out seconds)) return false;
            try { timestamp = UnixEpoch.AddSeconds(seconds); return true; }
            catch (ArgumentOutOfRangeException) { return false; }
        }

        private sealed class Bar
        {
            public DateTime TimestampUtc;
            public DateTime Date;
            public double Close;
            public double? AdjustedClose;
            public int Sequence;
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            client.Dispose();
        }
    }
}
