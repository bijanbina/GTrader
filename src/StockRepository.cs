using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace GTrader
{
    public class StockRepository
    {
        private readonly string baseDirectory;
        private readonly string cacheDirectory;
        public string SymbolsPath { get; private set; }
        public string CacheDirectory { get { return cacheDirectory; } }
        public StockRepository(string baseDirectory) : this(baseDirectory, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GTraderPriceExplorer", "cache-v1")) { }
        public StockRepository(string baseDirectory, string cacheDirectory)
        {
            this.baseDirectory = Path.GetFullPath(baseDirectory);
            this.cacheDirectory = Path.GetFullPath(cacheDirectory);
            SymbolsPath = Path.Combine(this.baseDirectory, "nasdaq_nyse_innovation_over_1b.txt");
        }
        private string ReadData(string file, string resource)
        {
            string path = Path.Combine(baseDirectory, file);
            if (File.Exists(path)) return File.ReadAllText(path, Encoding.UTF8);
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                if (stream == null) return null;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) return reader.ReadToEnd();
            }
        }
        public List<StockInfo> LoadSymbols()
        {
            string symbols = ReadData("nasdaq_nyse_innovation_over_1b.txt", "GTrader.Symbols");
            if (symbols == null) throw new FileNotFoundException("The stock symbol file was not found.", SymbolsPath);
            Dictionary<string, StockInfo> metadata = new Dictionary<string, StockInfo>(StringComparer.OrdinalIgnoreCase);
            string json = ReadData("companies.json", "GTrader.Companies");
            if (!String.IsNullOrWhiteSpace(json))
            {
                try
                {
                    List<StockInfo> items = new JavaScriptSerializer().Deserialize<List<StockInfo>>(json);
                    if (items != null)
                        foreach (StockInfo item in items)
                            if (item != null && !String.IsNullOrEmpty(item.Symbol)) metadata[item.Symbol] = item;
                }
                catch (ArgumentException) { }
                catch (InvalidOperationException) { }
            }
            HashSet<string> seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            List<StockInfo> result = new List<StockInfo>();
            foreach (string line in symbols.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string symbol = line.Trim().TrimStart('\uFEFF').ToUpperInvariant();
                if (symbol.Length == 0 || symbol.StartsWith("#")) continue;
                if (!Regex.IsMatch(symbol, @"^[A-Z0-9][A-Z0-9.\-^]{0,19}$"))
                    throw new InvalidDataException("Invalid symbol in the symbol file: " + symbol);
                if (!seen.Add(symbol)) continue;
                StockInfo info;
                if (!metadata.TryGetValue(symbol, out info)) info = new StockInfo { Symbol = symbol, Company = symbol, Exchange = "" };
                result.Add(info);
            }
            if (result.Count == 0) throw new InvalidDataException("The symbol file is empty.");
            return result.OrderBy(s => s.Symbol, StringComparer.OrdinalIgnoreCase).ToList();
        }
        private string CachePath(string symbol)
        {
            if (String.IsNullOrEmpty(symbol) || !Regex.IsMatch(symbol, @"^[A-Za-z0-9][A-Za-z0-9.\-^]{0,19}$")) throw new ArgumentException("Invalid symbol.");
            return Path.Combine(cacheDirectory, symbol.ToUpperInvariant() + ".json");
        }
        public StockSnapshot LoadCache(string symbol)
        {
            try
            {
                string path = CachePath(symbol);
                if (!File.Exists(path)) return null;
                StockSnapshot snapshot = new JavaScriptSerializer().Deserialize<StockSnapshot>(File.ReadAllText(path));
                if (snapshot == null || !String.Equals(snapshot.Symbol, symbol, StringComparison.OrdinalIgnoreCase) || snapshot.Prices == null || snapshot.Prices.Length != 7 || snapshot.FetchedAtUtc == default(DateTime) || snapshot.AnchorDate == default(DateTime)) return null;
                snapshot.AnchorDate = DateTime.SpecifyKind(snapshot.AnchorDate.Date, DateTimeKind.Unspecified);
                foreach (PriceObservation point in snapshot.Prices)
                    if (point != null && point.Date.HasValue) point.Date = DateTime.SpecifyKind(point.Date.Value.Date, DateTimeKind.Unspecified);
                return snapshot;
            }
            catch (IOException) { return null; }
            catch (UnauthorizedAccessException) { return null; }
            catch (ArgumentException) { return null; }
            catch (InvalidOperationException) { return null; }
        }
        public void SaveCache(StockSnapshot snapshot)
        {
            if (snapshot == null) throw new ArgumentNullException("snapshot");
            string path = CachePath(snapshot.Symbol);
            Directory.CreateDirectory(cacheDirectory);
            string temp = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                // Calendar dates must not shift through the serializer's local-to-UTC conversion.
                StockSnapshot stored = new StockSnapshot
                {
                    Symbol = snapshot.Symbol, Currency = snapshot.Currency,
                    AnchorDate = DateTime.SpecifyKind(snapshot.AnchorDate.Date, DateTimeKind.Utc),
                    FetchedAtUtc = DateTime.SpecifyKind(snapshot.FetchedAtUtc, DateTimeKind.Utc),
                    QuoteAtUtc = snapshot.QuoteAtUtc.HasValue ? DateTime.SpecifyKind(snapshot.QuoteAtUtc.Value, DateTimeKind.Utc) : (DateTime?)null,
                    SourceUrl = snapshot.SourceUrl,
                    Prices = snapshot.Prices.Select(p => p == null ? null : new PriceObservation
                    {
                        Close = p.Close, AdjustedClose = p.AdjustedClose,
                        Date = p.Date.HasValue ? DateTime.SpecifyKind(p.Date.Value.Date, DateTimeKind.Utc) : (DateTime?)null
                    }).ToArray()
                };
                File.WriteAllText(temp, new JavaScriptSerializer().Serialize(stored), new UTF8Encoding(false));
                if (File.Exists(path)) File.Replace(temp, path, null);
                else File.Move(temp, path);
            }
            finally { if (File.Exists(temp)) File.Delete(temp); }
        }
    }
}
