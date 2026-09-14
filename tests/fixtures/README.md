`aapl.json` is a recorded Yahoo Finance daily-chart response retrieved on
14 September 2026 for AAPL. It includes raw and adjusted historical closes.

The offline tests use it to verify real response parsing and date alignment.
They do not expect a particular current price. Smaller synthetic responses in
`Tests.cs` exercise missing data, IPOs, stale observations, weekends, exchange
time zones and corporate-action adjustment behavior.

Live tests are optional: run the compiled test executable with `--live`.
They request AAPL, BA, WOLF and BIO.B and save successful snapshots in the
application's normal local cache. The default test run makes no network requests.
