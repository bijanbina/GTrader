# Validation — 14 September 2026

- Release executable compiled successfully with the Windows .NET Framework compiler, with no warnings in the final build.
- All 28 offline tests passed: comparison math, both sort directions, missing data, calendar boundaries, provider parsing, symbol mapping and cache integrity.
- Live sample requests passed for AAPL, BA, BIO.B and WOLF.
- Full integration fetch passed: **1,148 of 1,148 symbols**, zero failures, zero missing latest prices. This run completed in 416 seconds. Results are cached locally for the application.
- The form's in-process component test completed a real four-symbol refresh, checked displayed percentage values and ordering, and rendered the interface successfully.
- The full-universe component test loaded all 1,148 cached rows, checked displayed ascending order and missing values last, and rendered the interface successfully.
- Rendered previews were visually inspected. External mouse interaction could not be verified because the Computer Use connection could not attach to the running GTrader window. The left/right header handlers and refresh/cancellation flow were independently reviewed in source.

| Price period | Symbols with a valid observation |
|---|---:|
| Latest | 1,148 |
| 1 month | 1,147 |
| 3 months | 1,129 |
| 6 months | 1,106 |
| 1 year | 1,080 |
| 3 years | 1,007 |
| 5 years | 953 |

Historical availability varies by listing. No values were substituted for unavailable history. Latest prices retain the actual provider quote/session dates; fetching on 14 September does not imply that each stock traded on that date.
