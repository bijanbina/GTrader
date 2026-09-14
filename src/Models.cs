using System;
using System.Collections.Generic;
using System.Linq;

namespace GTrader
{
    public class StockInfo
    {
        public string Symbol { get; set; }
        public string Company { get; set; }
        public string Exchange { get; set; }
    }

    public class PriceObservation
    {
        public double? Close { get; set; }
        public double? AdjustedClose { get; set; }
        public DateTime? Date { get; set; }
    }

    public class StockSnapshot
    {
        public string Symbol { get; set; }
        public string Currency { get; set; }
        public DateTime AnchorDate { get; set; }
        public DateTime FetchedAtUtc { get; set; }
        public DateTime? QuoteAtUtc { get; set; }
        public PriceObservation[] Prices { get; set; }
        public string SourceUrl { get; set; }
    }

    public class StockRow
    {
        public StockInfo Info { get; set; }
        public StockSnapshot Snapshot { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public bool FromCache { get; set; }
        public StockRow() { Status = "Not loaded"; }
    }

    public static class PriceMath
    {
        public static readonly string[] Labels = { "Today", "1 month", "3 months", "6 months", "1 year", "3 years", "5 years" };
        public static DateTime NewYorkToday()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).Date;
        }
        public static DateTime[] TargetDates(DateTime anchor)
        {
            anchor = anchor.Date;
            return new[] { anchor, anchor.AddMonths(-1), anchor.AddMonths(-3), anchor.AddMonths(-6), anchor.AddYears(-1), anchor.AddYears(-3), anchor.AddYears(-5) };
        }
        public static double? Price(StockRow row, int index, bool adjusted)
        {
            if (row == null || row.Snapshot == null || row.Snapshot.Prices == null || index < 0 || index >= row.Snapshot.Prices.Length) return null;
            PriceObservation p = row.Snapshot.Prices[index];
            if (p == null) return null;
            double? value = adjusted ? p.AdjustedClose : p.Close;
            return value.HasValue && value.Value > 0 && !Double.IsNaN(value.Value) && !Double.IsInfinity(value.Value) ? value : null;
        }
        public static double? Change(StockRow row, int target, int baseline, bool adjusted)
        {
            double? a = Price(row, target, adjusted), b = Price(row, baseline, adjusted);
            return a.HasValue && b.HasValue ? (a.Value / b.Value - 1.0) * 100.0 : (double?)null;
        }
        public static List<StockRow> Sort(IEnumerable<StockRow> rows, int target, int baseline, bool adjusted, bool ascending)
        {
            return rows.OrderBy(r => !Change(r, target, baseline, adjusted).HasValue)
                .ThenBy(r => { double? v = Change(r, target, baseline, adjusted); return v.HasValue ? (ascending ? v.Value : -v.Value) : 0; })
                .ThenBy(r => r.Info.Symbol, StringComparer.OrdinalIgnoreCase).ToList();
        }
    }
}
