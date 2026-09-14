# GTrader Price Explorer

A native C# Windows desktop app for comparing the 1,148 Nasdaq and NYSE symbols in `nasdaq_nyse_innovation_over_1b.txt`.

## Run

Open `dist\GTrader.PriceExplorer.exe`. Click **Refresh** to fetch the entire symbol list. Internet access is required for new prices. No API key is needed. A full refresh can take several minutes; you can cancel it and keep the results already received.

The app reads the symbol file beside the executable. To change the universe, edit that file and restart the app. A bundled copy is used if the external file is missing. The company names and exchanges come from `companies.json`. The executable has both resources embedded, so it also works on its own.

## Compare and sort

- Click a **symbol** to open a Google search for that symbol followed by "stock" in your default browser.
- Click a **company name** to open that stock's main Yahoo Finance page. The **Open Yahoo** button opens its history page.
- Left-click any price column header to choose the target price.
- Right-click any price column header to choose the baseline price.
- The two date selectors provide the same controls using a keyboard.
- Percentage change is **100 × (target / baseline − 1)**.
- **Ascending** shows the biggest falls first (most negative change).
- **Descending** shows the biggest gains first (most positive change).
- Missing comparisons always appear last. Equal changes sort by symbol.

For example, left-click **Today** and right-click **1 year** to rank declines since one year ago. Choose **1 month** and **3 years** to compare those two historical prices instead. The price columns display dollar/share amounts, while the comparison column displays percentages. Prices remain in each listing's reported currency.

## Dates and price basis

The columns are Today, 1 month, 3 months, 6 months, 1 year, 3 years, and 5 years. Requested dates use calendar month/year offsets from the current date in New York. Each historical price uses the latest available daily close **on or before** the requested date, never a future bar. The actual observation dates are available in the interface. More than ten calendar days without a valid bar, or a date before a company's available history, produces N/A.

**Today** means Yahoo's latest regular-session quote, which may be delayed or belong to the last trading day when the market is closed. Its actual timestamp is shown; it is not represented as a live streaming quote.

The default comparison uses daily **Close**, adjusted by the provider for stock splits. The optional adjusted-close basis also incorporates provider dividend adjustments; this is a historical performance proxy, not the unadjusted amount paid on the original day. It does not account for fees or taxes. Yahoo describes its price adjustments in [Historical data](https://help.yahoo.com/kb/SLN28256.html).

## Data and reliability

Quotes and daily history come from Yahoo Finance's public chart endpoint, with a Yahoo source link for each symbol. This endpoint is unofficial and can change or limit requests. The app uses bounded concurrency, delays, timeouts and retries. Failed symbols are identified individually; their values are never invented. Dotted share classes are mapped to Yahoo's hyphen convention (for example `BIO.B` → `BIO-B`).

Successful snapshots are cached under `%LOCALAPPDATA%\GTraderPriceExplorer\cache-v1`. Cached rows are labeled and retain their original reference date and retrieval timestamp. A failed refresh can continue displaying a previous cached snapshot; check its dates before comparing it with freshly fetched rows. Clearing that cache only removes downloaded prices, not your symbol list.

The symbol universe is the saved **14 September 2026** screening snapshot. Refresh updates prices; it does not re-screen exchange membership, industries or the >US$1 billion company market-cap filter. The complete selection method and per-symbol audit are in `nasdaq_nyse_innovation_over_1b.sources.md`.

## Build and verification

Requires Windows with .NET Framework 4.8 or newer. No additional SDK or NuGet packages are required on this computer.

```powershell
.\build.ps1
.\build.ps1 -Test
.\dist\GTrader.PriceExplorer.exe --refresh
```

Source files are in `src`. The build uses the Windows .NET Framework C# compiler and creates the executable and its companion data files in `dist`. Tests cover comparison math, missing-data ordering, calendar dates, provider parsing, and cache round-trips. Synthetic prices are used only in tests, never in the application.
