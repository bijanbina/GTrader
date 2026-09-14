using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GTrader.Tests
{
    // Optional live integration run: fetch every listed ticker and warm the application's cache.
    public static class BulkFetch
    {
        private static readonly object ResultsLock = new object();
        private static readonly SemaphoreSlim StartGate = new SemaphoreSlim(1, 1);
        private static readonly Stopwatch Timer = Stopwatch.StartNew();
        private static readonly List<Failure> Failures = new List<Failure>();
        private static readonly List<string> MissingToday = new List<string>();
        private static readonly int[] AvailableByPeriod = new int[7];
        private static long nextStartMilliseconds;
        private static int nextIndex = -1;
        private static int completed;
        private static int succeeded;
        private static int completeHistory;
        private static DateTime startedAtUtc;
        private static string outputPath;
        private static List<StockInfo> symbols;
        private static DateTime anchor;

        public static int Main(string[] args)
        {
            string projectRoot = args.Length > 0 ? Path.GetFullPath(args[0])
                : Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".."));
            outputPath = Path.Combine(projectRoot, "tests", "bulk-results.json");
            startedAtUtc = DateTime.UtcNow;
            anchor = PriceMath.NewYorkToday();
            StockRepository repository = new StockRepository(projectRoot);
            symbols = repository.LoadSymbols();
            using (var cancellation = new CancellationTokenSource())
            using (var service = new PriceHistoryService())
            {
                Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
                {
                    e.Cancel = true;
                    cancellation.Cancel();
                };
                Console.WriteLine("Fetching {0} symbols with 3 workers and 350 ms start spacing; anchor {1:yyyy-MM-dd}.", symbols.Count, anchor);
                Console.WriteLine("Cache: {0}", repository.CacheDirectory);
                SaveSummary(false, false);
                bool canceled = false;
                try
                {
                    Task.WhenAll(Enumerable.Range(0, 3).Select(i => Worker(service, repository, cancellation.Token))).GetAwaiter().GetResult();
                }
                catch (OperationCanceledException) { canceled = true; }
                SaveSummary(true, canceled);
                Console.WriteLine("Finished: {0}/{1} completed, {2} fetched and cached, {3} failed, {4} missing today's price; {5:0.0} seconds.",
                    completed, symbols.Count, succeeded, Failures.Count, MissingToday.Count, Timer.Elapsed.TotalSeconds);
                Console.WriteLine("Results: {0}", outputPath);
                return canceled ? 2 : Failures.Count == 0 && MissingToday.Count == 0 ? 0 : 1;
            }
        }

        private static async Task Worker(PriceHistoryService service, StockRepository repository, CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                int index = Interlocked.Increment(ref nextIndex);
                if (index >= symbols.Count) return;
                string symbol = symbols[index].Symbol;
                await WaitForStart(token).ConfigureAwait(false);
                StockSnapshot snapshot = null;
                string error = null;
                try
                {
                    using (var requestCancellation = CancellationTokenSource.CreateLinkedTokenSource(token))
                    {
                        requestCancellation.CancelAfter(TimeSpan.FromSeconds(120));
                        snapshot = await service.FetchAsync(symbol, anchor, requestCancellation.Token).ConfigureAwait(false);
                    }
                    Validate(snapshot);
                    repository.SaveCache(snapshot);
                }
                catch (OperationCanceledException)
                {
                    token.ThrowIfCancellationRequested();
                    error = "The per-symbol request exceeded 120 seconds.";
                }
                catch (Exception ex) { error = ex.GetType().Name + ": " + ex.Message; }
                lock (ResultsLock)
                {
                    completed++;
                    if (error != null) Failures.Add(new Failure { Symbol = symbol, Error = error });
                    else
                    {
                        succeeded++;
                        int available = 0;
                        for (int i = 0; i < snapshot.Prices.Length; i++)
                            if (snapshot.Prices[i].Close.HasValue) { AvailableByPeriod[i]++; available++; }
                        if (available == 7) completeHistory++;
                        if (!snapshot.Prices[0].Close.HasValue) MissingToday.Add(symbol);
                    }
                    if (completed % 50 == 0 || completed == symbols.Count)
                    {
                        Console.WriteLine("{0}/{1}: {2} cached, {3} failed, {4} missing today; {5:0.0} seconds.", completed,
                            symbols.Count, succeeded, Failures.Count, MissingToday.Count, Timer.Elapsed.TotalSeconds);
                        SaveSummary(false, false);
                    }
                }
            }
        }

        private static async Task WaitForStart(CancellationToken token)
        {
            await StartGate.WaitAsync(token).ConfigureAwait(false);
            try
            {
                long delay = nextStartMilliseconds - Timer.ElapsedMilliseconds;
                if (delay > 0) await Task.Delay(TimeSpan.FromMilliseconds(delay), token).ConfigureAwait(false);
                nextStartMilliseconds = Timer.ElapsedMilliseconds + 350;
            }
            finally { StartGate.Release(); }
        }

        private static void Validate(StockSnapshot snapshot)
        {
            if (snapshot == null || snapshot.Prices == null || snapshot.Prices.Length != 7)
                throw new InvalidDataException("Expected seven observations.");
            DateTime[] targets = PriceMath.TargetDates(anchor);
            for (int i = 0; i < snapshot.Prices.Length; i++)
            {
                PriceObservation point = snapshot.Prices[i];
                if (point == null) throw new InvalidDataException("An observation object is missing.");
                if (!point.Close.HasValue) continue;
                if (point.Close.Value <= 0 || Double.IsNaN(point.Close.Value) || Double.IsInfinity(point.Close.Value))
                    throw new InvalidDataException("A price is not finite and positive.");
                if (!point.Date.HasValue || point.Date.Value.Date > targets[i] || (targets[i] - point.Date.Value.Date).TotalDays > 10)
                    throw new InvalidDataException("A price violates the historical date bounds.");
            }
        }

        private static void SaveSummary(bool finished, bool canceled)
        {
            var summary = new
            {
                startedAtUtc = startedAtUtc.ToString("o", CultureInfo.InvariantCulture),
                updatedAtUtc = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                anchorDate = anchor.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                elapsedSeconds = Math.Round(Timer.Elapsed.TotalSeconds, 1),
                finished = finished,
                canceled = canceled,
                total = symbols.Count,
                completed = completed,
                succeeded = succeeded,
                failed = Failures.Count,
                fullSevenPeriodHistory = completeHistory,
                availableByPeriod = PriceMath.Labels.Select((label, i) => new { period = label, count = AvailableByPeriod[i] }).ToArray(),
                missingToday = MissingToday.OrderBy(s => s, StringComparer.Ordinal).ToArray(),
                failedSymbols = Failures.OrderBy(f => f.Symbol, StringComparer.Ordinal).ToArray()
            };
            string temporaryPath = outputPath + ".tmp";
            File.WriteAllText(temporaryPath, new JavaScriptSerializer().Serialize(summary), new UTF8Encoding(false));
            if (File.Exists(outputPath)) File.Replace(temporaryPath, outputPath, null);
            else File.Move(temporaryPath, outputPath);
        }

        public class Failure
        {
            public string Symbol { get; set; }
            public string Error { get; set; }
        }
    }
}
