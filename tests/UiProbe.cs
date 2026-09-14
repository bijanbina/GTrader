using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTrader;

// An in-process component test of our own form; no desktop input or OS automation.
internal static class UiProbe
{
    [STAThread]
    private static int Main(string[] args)
    {
        int result = 1;
        string project = Path.GetFullPath(args[0]);
        bool fullUniverse = args.Length > 1 && args[1] == "--full";
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MainForm form = new MainForm(new StockRepository(fullUniverse ? project : Path.Combine(project, "tests", "ui-smoke")));
        form.Shown += async delegate
        {
            try
            {
                if (fullUniverse)
                    await (Task)typeof(MainForm).GetMethod("EnsureInitializedAsync", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(form, null);
                else await form.RefreshAllAsync();
                DataGridView grid = (DataGridView)typeof(MainForm).GetField("grid", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(form);
                ToolStripStatusLabel status = (ToolStripStatusLabel)typeof(MainForm).GetField("status", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(form);
                if (fullUniverse)
                {
                    if (grid.RowCount != new StockRepository(project).LoadSymbols().Count) throw new Exception("The full universe was not displayed.");
                    double previous = Double.NegativeInfinity;
                    bool missing = false;
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        string value = Convert.ToString(row.Cells[10].Value);
                        if (value == "N/A") { missing = true; continue; }
                        double percent = Double.Parse(value.TrimEnd('%'), System.Globalization.CultureInfo.InvariantCulture);
                        if (missing || percent < previous) throw new Exception("Displayed comparisons are out of ascending order.");
                        previous = percent;
                    }
                }
                else
                {
                    if (grid.RowCount != 4) throw new Exception("Expected four live smoke symbols.");
                    if (!status.Text.StartsWith("Refresh complete.") || !status.Text.Contains("0 errors")) throw new Exception(status.Text);
                    double previous = Double.NegativeInfinity;
                    bool missing = false;
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        StockSnapshot snapshot = new StockRepository(project).LoadCache(Convert.ToString(row.Cells[0].Value));
                        string value = Convert.ToString(row.Cells[10].Value);
                        double? current = snapshot.Prices[0].Close, earlier = snapshot.Prices[4].Close;
                        if (!current.HasValue || !earlier.HasValue)
                        {
                            if (value != "N/A") throw new Exception("Missing history must display N/A.");
                            missing = true; continue;
                        }
                        double expected = 100 * (current.Value - earlier.Value) / earlier.Value;
                        double displayed = Double.Parse(value.TrimEnd('%'), System.Globalization.CultureInfo.InvariantCulture);
                        if (Math.Abs(expected - displayed) > 0.005001) throw new Exception("Displayed percentage does not match the fetched prices.");
                        if (missing || displayed < previous) throw new Exception("Displayed comparisons are not sorted.");
                        previous = displayed;
                    }
                }
                string previewPath = Path.Combine(project, "tests", "ui-smoke", fullUniverse ? "full-preview.png" : "preview.png");
                using (Bitmap bitmap = new Bitmap(form.Width, form.Height))
                {
                    form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
                    bitmap.Save(previewPath, ImageFormat.Png);
                }
                Console.WriteLine(fullUniverse ? "PASS the complete cached universe displays sorted percentages and N/A and renders successfully." : "PASS native form initializes, refreshes four real symbols, displays sorted percentages and N/A, and renders successfully.");
                Console.WriteLine(status.Text);
                Console.WriteLine("Preview: " + previewPath);
                result = 0;
            }
            catch (Exception ex) { Console.Error.WriteLine(ex); }
            finally { form.Close(); }
        };
        Application.Run(form);
        return result;
    }
}
