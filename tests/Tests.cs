using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;

namespace GTrader.Tests
{
    // Dependency-free, deterministic tests. Compile alongside the application sources
    // with /main:GTrader.Tests.Tests and a reference to System.Web.Extensions.dll.
    public static class Tests
    {
        private static int passed;
        private static int failed;
        private static string fixturePath;
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static int Main(string[] args)
        {
            fixturePath = FindFixture(args);
            Run("calendar offsets clamp leap days and month ends", TestCalendarDates);
            Run("price selection preserves raw and adjusted distinction", TestPriceModes);
            Run("invalid, absent and out-of-range prices are unavailable", TestInvalidPrices);
            Run("percent change uses the selected baseline", TestPercentChange);
            Run("same-period comparison is zero when available", TestSamePeriod);
            Run("ascending sort puts largest falls first and missing last", TestAscendingSort);
            Run("descending sort puts largest gains first and missing last", TestDescendingSort);
            Run("equal returns have a deterministic symbol tie-break", TestSortTies);
            Run("sorting uses the requested adjusted price mode", TestAdjustedSort);
            Run("real Yahoo fixture has seven dated price observations", TestRealFixture);
            Run("weekends use a previous trading day without looking ahead", TestWeekend);
            Run("IPO history remains missing before first trade", TestIpo);
            Run("null, zero, negative and nonnumeric closes fall back safely", TestInvalidBars);
            Run("a ten-day observation is accepted", TestTenDayBoundary);
            Run("an eleven-day observation is unavailable", TestElevenDayBoundary);
            Run("a valid current quote wins over the closing bar", TestLiveQuote);
            Run("a future quote cannot leak into an earlier anchor", TestFutureQuote);
            Run("an invalid quote falls back to the closing bar", TestInvalidQuote);
            Run("a stale quote cannot displace newer chart data", TestStaleQuote);
            Run("bar dates use the New York calendar", TestNewYorkDates);
            Run("adjusted history is not invented when unavailable", TestMissingAdjusted);
            Run("historical adjusted closes remain separate", TestAdjustedHistory);
            Run("provider errors and malformed responses fail explicitly", TestProviderErrors);
            Run("provider maps common share-class ticker separators", TestProviderSymbols);
            Run("repository normalizes, deduplicates and enriches symbols", TestRepositorySymbols);
            Run("repository rejects an empty or invalid symbol file", TestRepositoryInvalidSymbols);
            Run("cache preserves dates, values and quote timestamps", TestRepositoryRoundTrip);
            Run("corrupt or mismatched cache entries are ignored", TestRepositoryCorruption);
            if (args.Contains("--live")) Run("live AAPL, BA, WOLF and BIO.B requests warm the cache", TestLiveRequests);
            Console.WriteLine("{0} passed; {1} failed.", passed, failed);
            return failed == 0 ? 0 : 1;
        }

        private static void Run(string name, Action test)
        {
            try { test(); passed++; Console.WriteLine("PASS " + name); }
            catch (Exception ex) { failed++; Console.Error.WriteLine("FAIL " + name + ": " + ex.Message); }
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
        }

        private static void Equal<T>(T expected, T actual, string message)
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
                throw new Exception(message + "; expected " + expected + ", got " + actual);
        }

        private static void Near(double expected, double? actual, string message)
        {
            Assert(actual.HasValue && !Double.IsNaN(actual.Value) && !Double.IsInfinity(actual.Value)
                && Math.Abs(expected - actual.Value) < 0.000001, message + "; expected "
                + expected.ToString(CultureInfo.InvariantCulture) + ", got " + actual);
        }

        private static void Throws(Action action, string message)
        {
            bool threw = false;
            try { action(); }
            catch (Exception) { threw = true; }
            Assert(threw, message);
        }

        private static DateTime Day(int year, int month, int day) { return new DateTime(year, month, day); }
        private static long Unix(DateTime utc) { return (long)(utc.ToUniversalTime() - Epoch).TotalSeconds; }
        private static DateTime BarTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 14, 0, 0, DateTimeKind.Utc);
        }

        private static StockRow Row(string symbol, double? today, double? baseline)
        {
            return new StockRow
            {
                Info = new StockInfo { Symbol = symbol },
                Snapshot = new StockSnapshot
                {
                    Symbol = symbol,
                    Prices = new[]
                    {
                        new PriceObservation { Close = today, AdjustedClose = today },
                        new PriceObservation { Close = baseline, AdjustedClose = baseline }
                    }
                }
            };
        }

        private static PriceObservation Observation(StockSnapshot snapshot, int index)
        {
            Assert(snapshot != null && snapshot.Prices != null && snapshot.Prices.Length == 7,
                "The provider must preserve all seven comparison positions");
            return snapshot.Prices[index] ?? new PriceObservation();
        }

        private static void Missing(StockSnapshot snapshot, int index, string message)
        {
            PriceObservation observation = Observation(snapshot, index);
            Assert(!observation.Close.HasValue && !observation.AdjustedClose.HasValue, message);
        }

        private static void TestCalendarDates()
        {
            DateTime[] dates = PriceMath.TargetDates(new DateTime(2024, 3, 31, 18, 30, 0));
            DateTime[] expected = { Day(2024, 3, 31), Day(2024, 2, 29), Day(2023, 12, 31),
                Day(2023, 9, 30), Day(2023, 3, 31), Day(2021, 3, 31), Day(2019, 3, 31) };
            Equal(PriceMath.Labels.Length, dates.Length, "Labels and target dates must align");
            Assert(expected.SequenceEqual(dates), "Month and year offsets must use calendar dates");
            dates = PriceMath.TargetDates(Day(2024, 2, 29));
            Equal(Day(2023, 2, 28), dates[4], "One year before leap day");
            Equal(Day(2021, 2, 28), dates[5], "Three years before leap day");
            Equal(Day(2019, 2, 28), dates[6], "Five years before leap day");
        }

        private static void TestPriceModes()
        {
            StockRow row = Row("MODE", 110, 100);
            row.Snapshot.Prices[1].AdjustedClose = 80;
            Near(100, PriceMath.Price(row, 1, false), "Raw close");
            Near(80, PriceMath.Price(row, 1, true), "Adjusted close");
        }

        private static void TestInvalidPrices()
        {
            Assert(!PriceMath.Price(null, 0, false).HasValue, "Null row");
            Assert(!PriceMath.Price(new StockRow(), 0, false).HasValue, "Unloaded row");
            StockRow row = Row("BAD", 100, 100);
            Assert(!PriceMath.Price(row, -1, false).HasValue, "Negative index");
            Assert(!PriceMath.Price(row, 2, false).HasValue, "Index beyond history");
            foreach (double value in new[] { 0.0, -1.0, Double.NaN, Double.PositiveInfinity, Double.NegativeInfinity })
            {
                row.Snapshot.Prices[0].Close = value;
                Assert(!PriceMath.Price(row, 0, false).HasValue, "Invalid price " + value);
            }
            row.Snapshot.Prices[0] = null;
            Assert(!PriceMath.Price(row, 0, false).HasValue, "Null observation");
            row.Snapshot.Prices = null;
            Assert(!PriceMath.Price(row, 0, true).HasValue, "Missing array");
        }

        private static void TestPercentChange()
        {
            Near(25, PriceMath.Change(Row("UP", 125, 100), 0, 1, false), "Gain from baseline");
            Near(-20, PriceMath.Change(Row("DOWN", 80, 100), 0, 1, false), "Loss from baseline");
            Near(-20, PriceMath.Change(Row("REVERSE", 125, 100), 1, 0, false), "Reversed baseline");
            Assert(!PriceMath.Change(Row("ZERO", 10, 0), 0, 1, false).HasValue, "Zero divisor must be unavailable");
        }

        private static void TestSamePeriod()
        {
            Near(0, PriceMath.Change(Row("SAME", 37.5, 100), 0, 0, false), "Same available period");
            Assert(!PriceMath.Change(Row("EMPTY", null, 100), 0, 0, false).HasValue,
                "An absent price compared with itself must stay unavailable");
        }

        private static StockRow[] SortRows()
        {
            return new[] { Row("MISSING", null, 100), Row("WINNER", 160, 100),
                Row("FLAT", 100, 100), Row("LOSER", 50, 100), Row("ZEROBASE", 100, 0) };
        }

        private static void Symbols(string expected, IEnumerable<StockRow> rows)
        {
            Equal(expected, String.Join(",", rows.Select(r => r.Info.Symbol)), "Sorted symbol order");
        }

        private static void TestAscendingSort()
        {
            Symbols("LOSER,FLAT,WINNER,MISSING,ZEROBASE", PriceMath.Sort(SortRows(), 0, 1, false, true));
        }

        private static void TestDescendingSort()
        {
            Symbols("WINNER,FLAT,LOSER,MISSING,ZEROBASE", PriceMath.Sort(SortRows(), 0, 1, false, false));
        }

        private static void TestSortTies()
        {
            StockRow[] rows = { Row("Zulu", 120, 100), Row("alpha", 240, 200), Row("Beta", 60, 50) };
            Symbols("alpha,Beta,Zulu", PriceMath.Sort(rows, 0, 1, false, true));
            Symbols("alpha,Beta,Zulu", PriceMath.Sort(rows, 0, 1, false, false));
        }

        private static void TestAdjustedSort()
        {
            StockRow a = Row("A", 100, 100), b = Row("B", 110, 100);
            a.Snapshot.Prices[1].AdjustedClose = 50;
            Symbols("B,A", PriceMath.Sort(new[] { a, b }, 0, 1, false, false));
            Symbols("A,B", PriceMath.Sort(new[] { a, b }, 0, 1, true, false));
        }

        private static string FindFixture(string[] args)
        {
            string explicitPath = args.FirstOrDefault(a => !a.StartsWith("--", StringComparison.Ordinal));
            if (explicitPath != null) return Path.GetFullPath(explicitPath);
            string[] roots = { Environment.CurrentDirectory, AppDomain.CurrentDomain.BaseDirectory,
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar)) };
            foreach (string root in roots)
            {
                if (String.IsNullOrEmpty(root)) continue;
                foreach (string relative in new[] { "tests/fixtures/aapl.json", "fixtures/aapl.json" })
                {
                    string candidate = Path.Combine(root, relative.Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(candidate)) return candidate;
                }
            }
            return Path.Combine(Environment.CurrentDirectory, "tests", "fixtures", "aapl.json");
        }

        private static void TestRealFixture()
        {
            DateTime anchor = Day(2026, 9, 14);
            StockSnapshot snapshot = PriceHistoryService.Parse("AAPL", anchor, File.ReadAllText(fixturePath));
            Equal("AAPL", snapshot.Symbol, "Requested stock identity");
            Equal("USD", snapshot.Currency, "Quote currency");
            Equal(anchor, snapshot.AnchorDate.Date, "Anchor date");
            DateTime[] targets = PriceMath.TargetDates(anchor);
            for (int i = 0; i < targets.Length; i++)
            {
                PriceObservation observation = Observation(snapshot, i);
                Assert(observation.Close.HasValue && observation.Close.Value > 0, "Fixture has a valid close at index " + i);
                Assert(observation.AdjustedClose.HasValue && observation.AdjustedClose.Value > 0, "Fixture has adjusted price at index " + i);
                Assert(observation.Date.HasValue && observation.Date.Value.Date <= targets[i], "No future observation at index " + i);
                Assert((targets[i] - observation.Date.Value.Date).TotalDays <= 10, "Bounded lookup at index " + i);
            }
        }

        private static string Chart(DateTime[] times, object[] closes, object[] adjusted,
            object quote, DateTime? quoteTime)
        {
            Dictionary<string, object> meta = new Dictionary<string, object>
            {
                { "symbol", "TEST" }, { "currency", "USD" }, { "gmtoffset", -14400 },
                { "exchangeTimezoneName", "America/New_York" }, { "regularMarketPrice", quote },
                { "regularMarketTime", quoteTime.HasValue ? (object)Unix(quoteTime.Value) : null }
            };
            Dictionary<string, object> indicators = new Dictionary<string, object>
            {
                { "quote", new object[] { new Dictionary<string, object> { { "close", closes } } } }
            };
            if (adjusted != null) indicators["adjclose"] = new object[] { new Dictionary<string, object> { { "adjclose", adjusted } } };
            Dictionary<string, object> result = new Dictionary<string, object>
            {
                { "meta", meta }, { "timestamp", times.Select(Unix).ToArray() }, { "indicators", indicators }
            };
            return new JavaScriptSerializer().Serialize(new Dictionary<string, object>
            {
                { "chart", new Dictionary<string, object> { { "result", new object[] { result } }, { "error", null } } }
            });
        }

        private static StockSnapshot Parse(DateTime anchor, DateTime[] dates, object[] closes,
            object[] adjusted, object quote, DateTime? quoteTime)
        {
            return PriceHistoryService.Parse("TEST", anchor, Chart(dates.Select(BarTime).ToArray(), closes, adjusted, quote, quoteTime));
        }

        private static void TestWeekend()
        {
            StockSnapshot s = Parse(Day(2026, 9, 13), new[] { Day(2026, 8, 12), Day(2026, 8, 14),
                Day(2026, 9, 11), Day(2026, 9, 14) }, new object[] { 80, 82, 100, 105 },
                new object[] { 79, 81, 100, 105 }, null, null);
            Near(100, Observation(s, 0).Close, "Sunday uses Friday");
            Equal(Day(2026, 9, 11), Observation(s, 0).Date.Value.Date, "Actual trading date");
            Near(80, Observation(s, 1).Close, "August 13 cannot use August 14");
        }

        private static void TestIpo()
        {
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 9, 10), Day(2026, 9, 11) },
                new object[] { 20, 21 }, new object[] { 20, 21 }, null, null);
            Near(21, Observation(s, 0).Close, "Recent IPO current price");
            for (int i = 1; i < 7; i++) Missing(s, i, "Pre-IPO history must stay unavailable at index " + i);
        }

        private static void TestInvalidBars()
        {
            StockSnapshot s = Parse(Day(2026, 9, 16), new[] { Day(2026, 9, 10), Day(2026, 9, 11),
                Day(2026, 9, 14), Day(2026, 9, 15), Day(2026, 9, 16) },
                new object[] { 98, null, 0, -2, "invalid" }, new object[] { 97, 99, 100, 101, 102 }, null, null);
            Near(98, Observation(s, 0).Close, "Invalid chart closes must not become usable observations");
            Equal(Day(2026, 9, 10), Observation(s, 0).Date.Value.Date, "Fallback retains the valid bar date");
        }

        private static void TestTenDayBoundary()
        {
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 9, 4) }, new object[] { 70 }, null, null, null);
            Near(70, Observation(s, 0).Close, "Exactly ten calendar days is within lookup tolerance");
        }

        private static void TestElevenDayBoundary()
        {
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 9, 3) }, new object[] { 70 }, null, null, null);
            Missing(s, 0, "Do not silently show a stale eleven-day-old price");
        }

        private static void TestLiveQuote()
        {
            DateTime quoteTime = new DateTime(2026, 9, 14, 15, 45, 0, DateTimeKind.Utc);
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 9, 11) }, new object[] { 100 },
                new object[] { 99 }, 105, quoteTime);
            Near(105, Observation(s, 0).Close, "Latest regular-market quote");
            Near(105, Observation(s, 0).AdjustedClose, "Current adjusted basis uses current quote");
            Equal(quoteTime, s.QuoteAtUtc.Value, "Preserve the actual quote timestamp");
        }

        private static void TestFutureQuote()
        {
            StockSnapshot s = Parse(Day(2026, 9, 13), new[] { Day(2026, 9, 11) }, new object[] { 100 },
                null, 900, new DateTime(2026, 9, 14, 14, 0, 0, DateTimeKind.Utc));
            Near(100, Observation(s, 0).Close, "Future metadata is ignored");
        }

        private static void TestInvalidQuote()
        {
            foreach (object quote in new object[] { 0, -5, null, "invalid" })
            {
                StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 9, 11) }, new object[] { 100 },
                    null, quote, new DateTime(2026, 9, 14, 14, 0, 0, DateTimeKind.Utc));
                Near(100, Observation(s, 0).Close, "Invalid quote falls back to chart");
            }
        }

        private static void TestStaleQuote()
        {
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 9, 11) }, new object[] { 100 },
                null, 50, new DateTime(2026, 9, 3, 14, 0, 0, DateTimeKind.Utc));
            Near(100, Observation(s, 0).Close, "Stale metadata falls back to newer chart data");
        }

        private static void TestNewYorkDates()
        {
            DateTime utc = new DateTime(2026, 9, 12, 1, 0, 0, DateTimeKind.Utc);
            StockSnapshot s = PriceHistoryService.Parse("TEST", Day(2026, 9, 11),
                Chart(new[] { utc }, new object[] { 75 }, null, null, null));
            Near(75, Observation(s, 0).Close, "01:00 UTC belongs to previous New York date");
            Equal(Day(2026, 9, 11), Observation(s, 0).Date.Value.Date, "Exchange-local bar date");
        }

        private static void TestMissingAdjusted()
        {
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 8, 14), Day(2026, 9, 11) },
                new object[] { 80, 100 }, null, null, null);
            Near(80, Observation(s, 1).Close, "Historical raw close stays available");
            Assert(!Observation(s, 1).AdjustedClose.HasValue, "Missing adjusted series is not fabricated");
        }

        private static void TestAdjustedHistory()
        {
            StockSnapshot s = Parse(Day(2026, 9, 14), new[] { Day(2026, 8, 14), Day(2026, 9, 11) },
                new object[] { 80, 100 }, new object[] { 60, 100 }, null, null);
            Near(80, Observation(s, 1).Close, "Raw historical value");
            Near(60, Observation(s, 1).AdjustedClose, "Provider adjusted historical value");
            StockRow row = new StockRow { Info = new StockInfo { Symbol = "TEST" }, Snapshot = s };
            Near(25, PriceMath.Change(row, 0, 1, false), "Raw percentage");
            Near((100.0 / 60.0 - 1.0) * 100.0, PriceMath.Change(row, 0, 1, true), "Adjusted percentage");
        }

        private static void TestProviderErrors()
        {
            Throws(delegate { PriceHistoryService.Parse("TEST", Day(2026, 9, 14), "{broken"); }, "Malformed JSON must fail");
            Throws(delegate { PriceHistoryService.Parse("TEST", Day(2026, 9, 14), "{\"chart\":{\"result\":[],\"error\":null}}"); },
                "An empty provider result must fail");
            Throws(delegate { PriceHistoryService.Parse("TEST", Day(2026, 9, 14),
                "{\"chart\":{\"result\":null,\"error\":{\"code\":\"Not Found\",\"description\":\"No data found\"}}}"); },
                "Provider errors must fail explicitly");
        }

        private static void TestProviderSymbols()
        {
            Equal("AAPL", PriceHistoryService.ProviderSymbol("AAPL"), "Ordinary symbol remains unchanged");
            Equal("BRK-B", PriceHistoryService.ProviderSymbol("BRK.B"), "Class B separator mapping");
            Equal("BF-B", PriceHistoryService.ProviderSymbol("BF.B"), "Brown-Forman separator mapping");
        }

        private static void WithRepository(Action<StockRepository, string> action)
        {
            string directory = Path.Combine(Path.GetTempPath(), "GTraderTests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            try { action(new StockRepository(directory, Path.Combine(directory, "cache")), directory); }
            finally
            {
                // The target is a freshly created, fully qualified test-only directory.
                if (Directory.Exists(directory)) Directory.Delete(directory, true);
            }
        }

        private static void TestRepositorySymbols()
        {
            WithRepository(delegate(StockRepository repository, string directory)
            {
                File.WriteAllText(repository.SymbolsPath, "# Symbols\r\n aapl \r\nBIO.B\nAAPL\n\n wolf\n");
                File.WriteAllText(Path.Combine(directory, "companies.json"),
                    "[{\"Symbol\":\"AAPL\",\"Company\":\"Apple Inc.\",\"Exchange\":\"NASDAQ\"}]");
                List<StockInfo> stocks = repository.LoadSymbols();
                Equal("AAPL,BIO.B,WOLF", String.Join(",", stocks.Select(s => s.Symbol)), "Normalized unique symbols");
                Equal("Apple Inc.", stocks[0].Company, "Known company name");
                Equal("NASDAQ", stocks[0].Exchange, "Known exchange");
                Equal("WOLF", stocks[2].Company, "Missing company metadata has a readable fallback");
            });
        }

        private static void TestRepositoryInvalidSymbols()
        {
            WithRepository(delegate(StockRepository repository, string directory)
            {
                File.WriteAllText(repository.SymbolsPath, "# only a comment\n\n");
                Throws(delegate { repository.LoadSymbols(); }, "An empty universe should fail explicitly");
                File.WriteAllText(repository.SymbolsPath, "AAPL\n../../outside\n");
                Throws(delegate { repository.LoadSymbols(); }, "Path-like symbols must not be accepted");
            });
        }

        private static StockSnapshot CacheSample()
        {
            StockSnapshot snapshot = new StockSnapshot
            {
                Symbol = "BIO.B", Currency = "USD", AnchorDate = Day(2024, 3, 31),
                FetchedAtUtc = new DateTime(2024, 3, 31, 15, 40, 0, DateTimeKind.Utc),
                QuoteAtUtc = new DateTime(2024, 3, 29, 20, 0, 0, DateTimeKind.Utc),
                SourceUrl = "https://example.invalid/fixture", Prices = new PriceObservation[7]
            };
            DateTime[] dates = PriceMath.TargetDates(snapshot.AnchorDate);
            for (int i = 0; i < dates.Length; i++)
                snapshot.Prices[i] = new PriceObservation { Close = 100 + i, AdjustedClose = 90 + i, Date = dates[i] };
            return snapshot;
        }

        private static void TestRepositoryRoundTrip()
        {
            WithRepository(delegate(StockRepository repository, string directory)
            {
                StockSnapshot original = CacheSample();
                repository.SaveCache(original);
                StockSnapshot loaded = repository.LoadCache("bio.b");
                Assert(loaded != null, "A saved cache must load");
                Equal(original.AnchorDate, loaded.AnchorDate, "Calendar anchor cannot shift through local timezone serialization");
                Equal(DateTimeKind.Unspecified, loaded.AnchorDate.Kind, "Anchor stays a calendar date");
                Equal(original.FetchedAtUtc, loaded.FetchedAtUtc, "Fetch instant must round trip");
                Equal(original.QuoteAtUtc, loaded.QuoteAtUtc, "Quote instant must round trip");
                for (int i = 0; i < original.Prices.Length; i++)
                {
                    Equal(original.Prices[i].Date, loaded.Prices[i].Date, "Calendar price date at index " + i);
                    Near(original.Prices[i].Close.Value, loaded.Prices[i].Close, "Raw price at index " + i);
                    Near(original.Prices[i].AdjustedClose.Value, loaded.Prices[i].AdjustedClose, "Adjusted price at index " + i);
                }
                original.Prices[0].Close = 321;
                repository.SaveCache(original);
                Near(321, repository.LoadCache("BIO.B").Prices[0].Close, "Existing cache must be replaceable");
                Equal(1, Directory.GetFiles(repository.CacheDirectory).Length, "Successful writes leave no temporary files");
            });
        }

        private static void TestRepositoryCorruption()
        {
            WithRepository(delegate(StockRepository repository, string directory)
            {
                Assert(repository.LoadCache("AAPL") == null, "A missing cache is normal");
                repository.SaveCache(CacheSample());
                string path = Path.Combine(repository.CacheDirectory, "BIO.B.json");
                string original = File.ReadAllText(path);
                File.WriteAllText(path, "{not valid JSON");
                Assert(repository.LoadCache("BIO.B") == null, "Truncated cache should be ignored");
                File.WriteAllText(path, original.Replace("BIO.B", "OTHER"));
                Assert(repository.LoadCache("BIO.B") == null, "A different stock's cache must be rejected");
                File.WriteAllText(path, "null");
                Assert(repository.LoadCache("BIO.B") == null, "Null cache should be ignored");
                Assert(repository.LoadCache("../../outside") == null, "Cache reads cannot escape the cache directory");
                StockSnapshot invalid = CacheSample();
                invalid.Symbol = "../../outside";
                Throws(delegate { repository.SaveCache(invalid); }, "Cache writes must reject path traversal");
            });
        }

        private static void TestLiveRequests()
        {
            string project = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(fixturePath)));
            StockRepository repository = new StockRepository(project);
            PriceHistoryService service = new PriceHistoryService();
            DateTime anchor = PriceMath.NewYorkToday();
            foreach (string symbol in new[] { "AAPL", "BA", "WOLF", "BIO.B" })
            {
                using (CancellationTokenSource cancellation = new CancellationTokenSource(45000))
                {
                    StockSnapshot snapshot = service.FetchAsync(symbol, anchor, cancellation.Token).GetAwaiter().GetResult();
                    Equal(symbol, snapshot.Symbol, "Provider must preserve original ticker for " + symbol);
                    PriceObservation current = Observation(snapshot, 0);
                    Assert(current.Close.HasValue && current.Close.Value > 0 && !Double.IsNaN(current.Close.Value)
                        && !Double.IsInfinity(current.Close.Value), "Live price must be finite and positive for " + symbol);
                    DateTime[] targets = PriceMath.TargetDates(anchor);
                    int available = 0;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        PriceObservation point = Observation(snapshot, i);
                        if (!point.Close.HasValue) continue;
                        available++;
                        Assert(point.Date.HasValue && point.Date.Value.Date <= targets[i], "Live history cannot look ahead for " + symbol);
                        Assert((targets[i] - point.Date.Value.Date).TotalDays <= 10, "Live history must respect lookup tolerance for " + symbol);
                    }
                    repository.SaveCache(snapshot);
                    Assert(repository.LoadCache(symbol) != null, "Live cache round trip for " + symbol);
                    Console.WriteLine("LIVE {0}: {1} {2}, session {3:yyyy-MM-dd}, {4}/7 periods; quote timestamp {5}",
                        symbol, current.Close.Value.ToString("0.####", CultureInfo.InvariantCulture), snapshot.Currency,
                        current.Date, available, snapshot.QuoteAtUtc.HasValue ? snapshot.QuoteAtUtc.Value.ToString("u") : "closing bar");
                }
            }
        }
    }
}
