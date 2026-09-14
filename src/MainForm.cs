using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTrader
{
    public class MainForm : Form
    {
        private readonly StockRepository repository;
        private readonly PriceHistoryService provider = new PriceHistoryService();
        private readonly List<StockRow> allRows = new List<StockRow>();
        private List<StockRow> visibleRows = new List<StockRow>();
        private readonly ConcurrentQueue<RowUpdate> updates = new ConcurrentQueue<RowUpdate>();
        private readonly SemaphoreSlim requestGate = new SemaphoreSlim(1, 1);
        private DateTime lastRequest = DateTime.MinValue;
        private readonly System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
        private CancellationTokenSource refreshCancellation;
        private Task initialization;
        private bool refreshing, rebuilding, dirty, closing;
        private int completed, failures, targetIndex, baselineIndex = 4;
        private readonly ComboBox target = new ComboBox(), baseline = new ComboBox(), order = new ComboBox(), basis = new ComboBox(), exchange = new ComboBox();
        private readonly TextBox search = new TextBox();
        private readonly DataGridView grid = new DataGridView();
        private readonly Button refresh = new Button(), cancel = new Button(), source = new Button();
        private readonly Label universeLabel = new Label(), selectionTitle = new Label(), selectionDetail = new Label(), selectionSource = new Label(), formula = new Label();
        private readonly ToolStripStatusLabel status = new ToolStripStatusLabel();
        private readonly ToolStripProgressBar progress = new ToolStripProgressBar();
        private readonly ToolTip tooltips = new ToolTip();
        private static readonly Color Navy = Color.FromArgb(20, 35, 58), Blue = Color.FromArgb(30, 101, 206), Amber = Color.FromArgb(164, 102, 5);

        private class RowUpdate
        {
            public string Symbol;
            public StockSnapshot Snapshot;
            public string Error;
            public bool CacheError;
        }

        public MainForm(StockRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.repository = repository;
            Text = "GTrader | High-tech stock explorer";
            Size = new Size(1500, 920);
            MinimumSize = new Size(1120, 680);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 247, 251);
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); } catch { }
            BuildInterface();
            updateTimer.Interval = 300;
            updateTimer.Tick += delegate { DrainUpdates(); if (dirty) ApplyView(); };
            updateTimer.Start();
            Shown += async delegate { try { await EnsureInitializedAsync(); } catch (Exception ex) { ShowError("Could not load the stock universe", ex); } };
            FormClosing += delegate { closing = true; if (refreshCancellation != null) refreshCancellation.Cancel(); updateTimer.Stop(); };
        }

        private void BuildInterface()
        {
            TableLayoutPanel layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 5, Padding = new Padding(0), Margin = new Padding(0) };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 105));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            Controls.Add(layout);
            Panel header = new Panel { Dock = DockStyle.Fill, BackColor = Navy, Margin = new Padding(0) };
            Label title = new Label { Text = "GTrader", ForeColor = Color.White, Font = new Font("Segoe UI", 24F, FontStyle.Bold), Location = new Point(22, 10), AutoSize = true };
            universeLabel.Text = "NASDAQ + NYSE  /  Innovative companies over $1 billion";
            universeLabel.ForeColor = Color.FromArgb(186, 204, 226); universeLabel.Location = new Point(25, 59); universeLabel.AutoSize = true;
            header.Controls.Add(title); header.Controls.Add(universeLabel);
            FlowLayoutPanel actions = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 435, FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(5, 27, 8, 0), BackColor = Navy, WrapContents = false };
            ConfigureButton(refresh, "Refresh all stocks", 158, Blue, Color.White);
            ConfigureButton(cancel, "Cancel", 85, Color.FromArgb(53, 69, 91), Color.White);
            ConfigureButton(source, "Open Yahoo", 125, Color.FromArgb(53, 69, 91), Color.White);
            cancel.Enabled = false; source.Enabled = false;
            actions.Controls.Add(refresh); actions.Controls.Add(cancel); actions.Controls.Add(source); header.Controls.Add(actions);
            refresh.Click += async delegate { await RefreshAllAsync(); };
            cancel.Click += delegate { if (refreshCancellation != null) { refreshCancellation.Cancel(); cancel.Enabled = false; status.Text = "Canceling active requests..."; } };
            source.Click += delegate { OpenSelectedSource(); };
            layout.Controls.Add(header, 0, 0);

            TableLayoutPanel filters = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(16, 6, 16, 0), Margin = new Padding(0) };
            filters.RowStyles.Add(new RowStyle(SizeType.Absolute, 64)); filters.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            FlowLayoutPanel comparisons = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, Margin = new Padding(0) };
            target.Items.AddRange(PriceMath.Labels); baseline.Items.AddRange(PriceMath.Labels);
            order.Items.AddRange(new object[] { "Ascending: biggest falls first", "Descending: biggest gains first" });
            basis.Items.AddRange(new object[] { "Split-adjusted price", "Adjusted close (dividends + splits)" });
            target.SelectedIndex = 0; baseline.SelectedIndex = 4; order.SelectedIndex = 0; basis.SelectedIndex = 0;
            comparisons.Controls.Add(FilterControl("&Target / left-click header", target, 176, Blue));
            comparisons.Controls.Add(FilterControl("&Baseline / right-click header", baseline, 190, Amber));
            comparisons.Controls.Add(FilterControl("Ranking &order", order, 230, Navy));
            comparisons.Controls.Add(FilterControl("Price &basis", basis, 254, Navy));
            filters.Controls.Add(comparisons, 0, 0);
            FlowLayoutPanel find = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, Margin = new Padding(0), Padding = new Padding(4, 4, 0, 0) };
            find.Controls.Add(new Label { Text = "Search", AutoSize = true, Margin = new Padding(0, 6, 9, 0) });
            search.Width = 250; search.Margin = new Padding(0, 1, 16, 0); find.Controls.Add(search);
            exchange.DropDownStyle = ComboBoxStyle.DropDownList; exchange.Width = 125; exchange.Items.AddRange(new object[] { "All exchanges", "NASDAQ", "NYSE" }); exchange.SelectedIndex = 0; find.Controls.Add(exchange);
            formula.AutoSize = true; formula.ForeColor = Color.FromArgb(78, 94, 117); formula.Margin = new Padding(22, 6, 0, 0); find.Controls.Add(formula);
            tooltips.SetToolTip(search, "Filter by ticker symbol or company name. Sorting and filtering stay available during refresh.");
            tooltips.SetToolTip(basis, "Split-adjusted price uses the provider's Close series. Adjusted close additionally accounts for dividends. Missing observations remain N/A.");
            filters.Controls.Add(find, 0, 1); layout.Controls.Add(filters, 0, 1);
            target.SelectedIndexChanged += delegate { targetIndex = target.SelectedIndex; UpdateComparison(); };
            baseline.SelectedIndexChanged += delegate { baselineIndex = baseline.SelectedIndex; UpdateComparison(); };
            order.SelectedIndexChanged += delegate { ApplyView(); };
            basis.SelectedIndexChanged += delegate { UpdateComparison(); };
            search.TextChanged += delegate { ApplyView(); };
            exchange.SelectedIndexChanged += delegate { ApplyView(); };

            grid.Dock = DockStyle.Fill; grid.Margin = new Padding(20, 0, 20, 0); grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None; grid.ReadOnly = true; grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false; grid.RowHeadersVisible = false; grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; grid.VirtualMode = true; grid.AutoGenerateColumns = false;
            grid.EnableHeadersVisualStyles = false; grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 45; grid.RowTemplate.Height = 32; grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(236, 240, 246); grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.DefaultCellStyle.BackColor = Color.White; grid.DefaultCellStyle.ForeColor = Navy;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 236, 253); grid.DefaultCellStyle.SelectionForeColor = Navy;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 251, 254);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(234, 239, 247); grid.ColumnHeadersDefaultCellStyle.ForeColor = Navy;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddLinkColumn("symbol", "Symbol", 78); AddLinkColumn("company", "Company", 210); AddColumn("exchange", "Exchange", 78, false);
            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; grid.Columns[1].MinimumWidth = 150;
            for (int i = 0; i < 7; i++) AddColumn("price" + i, PriceMath.Labels[i], 86, true);
            AddColumn("change", "Change %", 100, true); AddColumn("status", "Status / reference", 158, false); AddColumn("source", "Source", 108, false);
            grid.Columns[0].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.CellValueNeeded += GridCellValueNeeded; grid.CellFormatting += GridCellFormatting;
            grid.CellContentClick += GridCellContentClick;
            grid.CellToolTipTextNeeded += GridCellToolTipTextNeeded;
            grid.ColumnHeaderMouseClick += delegate(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.ColumnIndex >= 3 && e.ColumnIndex < 10)
                {
                    if (e.Button == MouseButtons.Right) baseline.SelectedIndex = e.ColumnIndex - 3;
                    else if (e.Button == MouseButtons.Left) target.SelectedIndex = e.ColumnIndex - 3;
                }
                else if (e.ColumnIndex == 10 && e.Button == MouseButtons.Left) order.SelectedIndex = order.SelectedIndex == 0 ? 1 : 0;
            };
            grid.SelectionChanged += delegate { if (!rebuilding) UpdateSelection(); };
            layout.Controls.Add(grid, 0, 2);

            TableLayoutPanel details = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(25, 11, 25, 0), ColumnCount = 1, RowCount = 3, Margin = new Padding(0) };
            details.RowStyles.Add(new RowStyle(SizeType.Absolute, 24)); details.RowStyles.Add(new RowStyle(SizeType.Absolute, 29)); details.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            selectionTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold); selectionTitle.ForeColor = Navy;
            selectionDetail.ForeColor = Color.FromArgb(68, 83, 106); selectionSource.ForeColor = Color.FromArgb(93, 107, 127);
            foreach (Label label in new[] { selectionTitle, selectionDetail, selectionSource }) { label.Dock = DockStyle.Fill; label.AutoEllipsis = true; label.Margin = new Padding(0); }
            details.Controls.Add(selectionTitle, 0, 0); details.Controls.Add(selectionDetail, 0, 1); details.Controls.Add(selectionSource, 0, 2); layout.Controls.Add(details, 0, 3);
            StatusStrip strip = new StatusStrip { Dock = DockStyle.Fill, SizingGrip = false, BackColor = Color.FromArgb(234, 239, 247), Padding = new Padding(20, 0, 20, 0) };
            status.Spring = true; status.TextAlign = ContentAlignment.MiddleLeft; status.Text = "Loading stock universe and local cache...";
            progress.Size = new Size(190, 16); progress.Visible = false; strip.Items.Add(status); strip.Items.Add(progress); layout.Controls.Add(strip, 0, 4);
            UpdateComparison();
        }

        private static void ConfigureButton(Button button, string text, int width, Color background, Color foreground)
        {
            button.Text = text; button.Width = width; button.Height = 36; button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0; button.BackColor = background; button.ForeColor = foreground;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold); button.Margin = new Padding(3, 0, 3, 0); button.Cursor = Cursors.Hand;
        }
        private static Control FilterControl(string label, ComboBox combo, int width, Color color)
        {
            Panel panel = new Panel { Width = width, Height = 60, Margin = new Padding(4, 0, 12, 0) };
            panel.Controls.Add(new Label { Text = label, ForeColor = color, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), Location = new Point(0, 2), AutoSize = true });
            combo.DropDownStyle = ComboBoxStyle.DropDownList; combo.Location = new Point(0, 25); combo.Width = width; panel.Controls.Add(combo); return panel;
        }
        private void AddColumn(string name, string header, int width, bool numeric)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn { Name = name, HeaderText = header, Width = width, SortMode = DataGridViewColumnSortMode.Programmatic };
            if (numeric) { column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; column.DefaultCellStyle.Padding = new Padding(0, 0, 8, 0); }
            else column.DefaultCellStyle.Padding = new Padding(7, 0, 0, 0);
            grid.Columns.Add(column);
        }
        private void AddLinkColumn(string name, string header, int width)
        {
            DataGridViewLinkColumn column = new DataGridViewLinkColumn
            {
                Name = name, HeaderText = header, Width = width,
                SortMode = DataGridViewColumnSortMode.Programmatic,
                LinkColor = Navy, ActiveLinkColor = Navy, VisitedLinkColor = Navy,
                TrackVisitedState = false, LinkBehavior = LinkBehavior.NeverUnderline
            };
            column.DefaultCellStyle.Padding = new Padding(7, 0, 0, 0);
            grid.Columns.Add(column);
        }
        private Task EnsureInitializedAsync()
        {
            if (initialization == null) initialization = LoadInitialAsync();
            return initialization;
        }
        private async Task LoadInitialAsync()
        {
            refresh.Enabled = false;
            List<StockRow> loaded = await Task.Run(delegate
            {
                List<StockRow> result = new List<StockRow>();
                foreach (StockInfo info in repository.LoadSymbols())
                {
                    StockRow row = new StockRow { Info = info };
                    try { row.Snapshot = repository.LoadCache(info.Symbol); row.FromCache = row.Snapshot != null; row.Status = row.FromCache ? "Cached" : "Not loaded"; }
                    catch (Exception ex) { row.Status = "Cache error"; row.Error = ex.Message; }
                    result.Add(row);
                }
                return result;
            });
            if (closing) return;
            allRows.AddRange(loaded); refresh.Enabled = true;
            universeLabel.Text = allRows.Count.ToString("N0") + " STOCKS  /  NASDAQ + NYSE  /  Saved universe above $1 billion";
            ApplyView();
            status.Text = "Ready. " + allRows.Count(r => r.Snapshot != null).ToString("N0") + " cached stocks loaded. Refresh all stocks to request current prices.";
        }

        public async Task RefreshAllAsync()
        {
            if (closing || refreshing) return;
            try { await EnsureInitializedAsync(); } catch (Exception ex) { if (!closing) ShowError("Could not load the stock universe", ex); return; }
            if (closing || refreshing || allRows.Count == 0) return;
            refreshing = true; completed = 0; failures = 0; refresh.Enabled = false; cancel.Enabled = true;
            refreshCancellation = new CancellationTokenSource(); CancellationToken token = refreshCancellation.Token;
            DateTime anchor = PriceMath.NewYorkToday(); string[] symbols = allRows.Select(r => r.Info.Symbol).ToArray();
            progress.Maximum = symbols.Length; progress.Value = 0; progress.Visible = true;
            foreach (StockRow row in allRows) { row.Status = "Queued"; row.Error = null; }
            dirty = true; int next = -1;
            List<Task> workers = new List<Task>();
            for (int worker = 0; worker < 3; worker++)
                workers.Add(Task.Run(async delegate
                {
                    while (!token.IsCancellationRequested)
                    {
                        int index = Interlocked.Increment(ref next); if (index >= symbols.Length) return;
                        string symbol = symbols[index];
                        try
                        {
                            await requestGate.WaitAsync(token);
                            try
                            {
                                double wait = 350 - (DateTime.UtcNow - lastRequest).TotalMilliseconds;
                                if (wait > 0) await Task.Delay((int)Math.Ceiling(wait), token);
                                token.ThrowIfCancellationRequested(); lastRequest = DateTime.UtcNow;
                            }
                            finally { requestGate.Release(); }
                            StockSnapshot snapshot = await provider.FetchAsync(symbol, anchor, token);
                            token.ThrowIfCancellationRequested();
                            RowUpdate update = new RowUpdate { Symbol = symbol, Snapshot = snapshot };
                            try { repository.SaveCache(snapshot); } catch (Exception ex) { update.Error = "Price loaded, but cache could not be saved: " + ex.Message; update.CacheError = true; }
                            updates.Enqueue(update);
                        }
                        catch (OperationCanceledException) { return; }
                        catch (Exception ex) { updates.Enqueue(new RowUpdate { Symbol = symbol, Error = ex.Message }); }
                    }
                }));
            try { await Task.WhenAll(workers); }
            catch (Exception ex) { if (!closing) status.Text = "Refresh interrupted: " + ex.Message; }
            finally
            {
                bool canceled = token.IsCancellationRequested;
                if (!closing)
                {
                    DrainUpdates(); refreshing = false;
                    foreach (StockRow row in allRows) if (row.Status == "Queued") row.Status = canceled ? "Canceled" : "Not loaded";
                    ApplyView(); refresh.Enabled = true; cancel.Enabled = false; progress.Visible = false;
                    status.Text = (canceled ? "Canceled. " : "Refresh complete. ") + completed.ToString("N0") + " / " + symbols.Length.ToString("N0") + " processed; " + failures.ToString("N0") + " errors. " + visibleRows.Count.ToString("N0") + " stocks shown. Cached values are retained on failure.";
                }
                refreshing = false; refreshCancellation.Dispose(); refreshCancellation = null;
            }
        }
        private void DrainUpdates()
        {
            RowUpdate update; bool changed = false;
            while (updates.TryDequeue(out update))
            {
                StockRow row = allRows.FirstOrDefault(r => r.Info.Symbol == update.Symbol); if (row == null) continue;
                completed++;
                if (update.Snapshot != null) { row.Snapshot = update.Snapshot; row.FromCache = false; row.Status = update.CacheError ? "Cache write error" : "Updated"; }
                else { row.Status = "Error"; if (row.Snapshot != null) row.FromCache = true; failures++; }
                row.Error = update.Error; changed = true;
            }
            if (changed) dirty = true;
            if (refreshing)
            {
                progress.Value = Math.Min(completed, progress.Maximum);
                status.Text = "Refreshing all " + allRows.Count.ToString("N0") + " stocks: " + completed.ToString("N0") + " completed, " + failures.ToString("N0") + " errors. Sorting and search remain available.";
            }
        }
        private bool Adjusted { get { return basis.SelectedIndex == 1; } }
        private StockRow SelectedRow()
        {
            int index = grid.CurrentCell == null ? -1 : grid.CurrentCell.RowIndex;
            return index >= 0 && index < visibleRows.Count ? visibleRows[index] : null;
        }
        private void ApplyView()
        {
            if (closing) return;
            StockRow selected = SelectedRow(); string selectedSymbol = selected == null ? null : selected.Info.Symbol;
            string query = search.Text.Trim(); string selectedExchange = exchange.SelectedIndex > 0 ? exchange.SelectedItem.ToString() : null;
            visibleRows = PriceMath.Sort(allRows.Where(r => (selectedExchange == null || String.Equals(r.Info.Exchange, selectedExchange, StringComparison.OrdinalIgnoreCase)) && (query.Length == 0 || r.Info.Symbol.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || (r.Info.Company ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)), targetIndex, baselineIndex, Adjusted, order.SelectedIndex == 0);
            rebuilding = true;
            try
            {
                grid.RowCount = visibleRows.Count;
                if (visibleRows.Count > 0)
                {
                    int index = selectedSymbol == null ? 0 : visibleRows.FindIndex(r => r.Info.Symbol == selectedSymbol); if (index < 0) index = 0;
                    int column = grid.CurrentCell == null ? 0 : grid.CurrentCell.ColumnIndex;
                    grid.CurrentCell = grid.Rows[index].Cells[column];
                }
                grid.Columns[10].HeaderCell.SortGlyphDirection = order.SelectedIndex == 0 ? SortOrder.Ascending : SortOrder.Descending;
                grid.Invalidate();
            }
            finally { rebuilding = false; }
            dirty = false; UpdateSelection();
            if (!refreshing && initialization != null && initialization.IsCompleted) status.Text = visibleRows.Count.ToString("N0") + " of " + allRows.Count.ToString("N0") + " stocks shown. N/A values always rank last.";
        }
        private void UpdateComparison()
        {
            if (grid.Columns.Count < 10) return;
            for (int i = 0; i < 7; i++)
            {
                DataGridViewColumn column = grid.Columns[i + 3]; bool isTarget = i == targetIndex, isBaseline = i == baselineIndex;
                column.HeaderCell.Style.BackColor = isTarget && isBaseline ? Color.FromArgb(108, 83, 158) : isTarget ? Blue : isBaseline ? Color.FromArgb(245, 196, 92) : Color.FromArgb(234, 239, 247);
                column.HeaderCell.Style.ForeColor = isTarget ? Color.White : Navy;
                column.HeaderText = PriceMath.Labels[i] + (isTarget && isBaseline ? "\nTarget + base" : isTarget ? "\nTarget" : isBaseline ? "\nBaseline" : "");
                column.ToolTipText = "Left-click: use as target. Right-click: use as baseline. Or use the labeled dropdowns above.";
            }
            formula.Text = "Change = (" + PriceMath.Labels[targetIndex] + " / " + PriceMath.Labels[baselineIndex] + " - 1) x 100";
            ApplyView();
        }
        private static string PriceText(double? price)
        {
            return price.HasValue ? price.Value.ToString(price.Value < 1 ? "0.0000" : "N2", CultureInfo.InvariantCulture) : "N/A";
        }
        private string RowStatus(StockRow row)
        {
            string cache = row.FromCache ? "Cached" : row.Status;
            if (row.FromCache && row.Status != "Cached") cache += " / " + row.Status;
            return cache + (row.Snapshot == null ? "" : " · " + row.Snapshot.AnchorDate.ToString("yyyy-MM-dd"));
        }
        private void GridCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= visibleRows.Count) return;
            StockRow row = visibleRows[e.RowIndex];
            if (e.ColumnIndex == 0) e.Value = row.Info.Symbol;
            else if (e.ColumnIndex == 1) e.Value = row.Info.Company;
            else if (e.ColumnIndex == 2) e.Value = row.Info.Exchange;
            else if (e.ColumnIndex >= 3 && e.ColumnIndex < 10) e.Value = PriceText(PriceMath.Price(row, e.ColumnIndex - 3, Adjusted));
            else if (e.ColumnIndex == 10) { double? change = PriceMath.Change(row, targetIndex, baselineIndex, Adjusted); e.Value = change.HasValue ? change.Value.ToString("+0.00;-0.00;0.00", CultureInfo.InvariantCulture) + "%" : "N/A"; }
            else if (e.ColumnIndex == 11) e.Value = RowStatus(row);
            else if (e.ColumnIndex == 12) e.Value = row.Snapshot == null ? "—" : "Yahoo · " + (row.Snapshot.Currency ?? "USD");
        }
        private void GridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= visibleRows.Count) return;
            StockRow row = visibleRows[e.RowIndex];
            if (e.ColumnIndex == 10)
            {
                double? change = PriceMath.Change(row, targetIndex, baselineIndex, Adjusted);
                e.CellStyle.ForeColor = !change.HasValue ? Color.FromArgb(143, 151, 165) : change.Value < 0 ? Color.FromArgb(180, 48, 66) : change.Value > 0 ? Color.FromArgb(10, 128, 99) : Navy;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
            else if (e.ColumnIndex == 11) { e.CellStyle.ForeColor = row.Error != null ? Color.FromArgb(180, 48, 66) : row.FromCache ? Amber : Color.FromArgb(86, 103, 125); e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor; }
            else if (e.ColumnIndex >= 3 && e.ColumnIndex < 10 && !PriceMath.Price(row, e.ColumnIndex - 3, Adjusted).HasValue) e.CellStyle.ForeColor = Color.FromArgb(143, 151, 165);
        }
        private string ObservationDetail(StockRow row, int index)
        {
            if (row.Snapshot == null) return PriceMath.Labels[index] + ": N/A; no snapshot loaded.";
            PriceObservation observation = row.Snapshot.Prices != null && index < row.Snapshot.Prices.Length ? row.Snapshot.Prices[index] : null;
            string actual = observation != null && observation.Date.HasValue ? observation.Date.Value.ToString("yyyy-MM-dd") : "not available";
            return PriceMath.Labels[index] + ": " + PriceText(PriceMath.Price(row, index, Adjusted)) + " " + (row.Snapshot.Currency ?? "USD") + " | requested " + PriceMath.TargetDates(row.Snapshot.AnchorDate)[index].ToString("yyyy-MM-dd") + " | actual session " + actual;
        }
        private void GridCellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= visibleRows.Count) return;
            StockRow row = visibleRows[e.RowIndex];
            if (e.ColumnIndex == 0) e.ToolTipText = "Search Google for " + row.Info.Symbol + " stock";
            else if (e.ColumnIndex == 1) e.ToolTipText = "Open " + row.Info.Company + " on Yahoo Finance";
            else if (e.ColumnIndex >= 3 && e.ColumnIndex < 10) e.ToolTipText = ObservationDetail(row, e.ColumnIndex - 3) + "\n" + basis.SelectedItem;
            else if (e.ColumnIndex == 11) e.ToolTipText = RowStatus(row) + (String.IsNullOrEmpty(row.Error) ? "" : "\n" + row.Error);
            else if (e.ColumnIndex == 12 && row.Snapshot != null) e.ToolTipText = row.Snapshot.SourceUrl;
            else if (e.ColumnIndex == 10) e.ToolTipText = ObservationDetail(row, targetIndex) + "\n" + ObservationDetail(row, baselineIndex) + "\n" + formula.Text;
            else e.ToolTipText = row.Info.Company;
        }
        private void UpdateSelection()
        {
            StockRow row = SelectedRow(); source.Enabled = row != null;
            if (row == null) { selectionTitle.Text = "No stocks to display"; selectionDetail.Text = "Choose a target and baseline above; left-click and right-click price headers also select them."; selectionSource.Text = "Try a different search or exchange filter."; return; }
            selectionTitle.Text = row.Info.Symbol + "  ·  " + row.Info.Company + "  ·  " + row.Info.Exchange;
            selectionDetail.Text = ObservationDetail(row, targetIndex) + "     |     " + ObservationDetail(row, baselineIndex);
            if (row.Snapshot == null) selectionSource.Text = String.IsNullOrEmpty(row.Error) ? "Not loaded. Refresh all stocks to retrieve prices. Missing and unavailable prices are shown as N/A." : row.Error;
            else
            {
                string quote = row.Snapshot.QuoteAtUtc.HasValue ? "Quote timestamp " + row.Snapshot.QuoteAtUtc.Value.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss 'UTC'") : "Today uses the available session closing bar; no intraday timestamp supplied";
                selectionSource.Text = (row.FromCache ? "CACHED · " : "") + "Fetched " + row.Snapshot.FetchedAtUtc.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss 'UTC'") + " · " + quote + (String.IsNullOrEmpty(row.Error) ? "" : " · " + row.Error);
            }
            tooltips.SetToolTip(selectionDetail, selectionDetail.Text); tooltips.SetToolTip(selectionSource, selectionSource.Text + (row.Snapshot == null ? "" : "\n" + row.Snapshot.SourceUrl));
        }
        private void OpenSelectedSource()
        {
            StockRow row = SelectedRow(); if (row == null) return;
            string url = "https://finance.yahoo.com/quote/" + Uri.EscapeDataString(PriceHistoryService.ProviderSymbol(row.Info.Symbol)) + "/history/";
            OpenUrl(url);
        }
        private void GridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= visibleRows.Count || (e.ColumnIndex != 0 && e.ColumnIndex != 1)) return;
            StockRow row = visibleRows[e.RowIndex];
            string url = e.ColumnIndex == 0
                ? "https://www.google.com/search?q=" + Uri.EscapeDataString(row.Info.Symbol + " stock")
                : "https://finance.yahoo.com/quote/" + Uri.EscapeDataString(PriceHistoryService.ProviderSymbol(row.Info.Symbol)) + "/";
            OpenUrl(url);
        }
        private void OpenUrl(string url)
        {
            try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); } catch (Exception ex) { ShowError("Could not open the link", ex); }
        }
        private void ShowError(string title, Exception exception)
        {
            status.Text = title + ": " + exception.Message;
            MessageBox.Show(this, exception.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
