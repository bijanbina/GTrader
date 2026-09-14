using System;
using System.Linq;
using System.Windows.Forms;

namespace GTrader
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                MainForm form = new MainForm(new StockRepository(AppDomain.CurrentDomain.BaseDirectory));
                if (args.Any(a => a.Equals("--refresh", StringComparison.OrdinalIgnoreCase)))
                    form.Shown += async delegate { await form.RefreshAllAsync(); };
                Application.Run(form);
            }
            catch (Exception error)
            {
                MessageBox.Show("GTrader could not start.\r\n\r\n" + error.Message, "GTrader", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
