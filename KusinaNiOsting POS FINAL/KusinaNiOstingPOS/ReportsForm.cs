using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace MiniMartPOS
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            UiStyle.PolishForm(this);
            Panel[] cards = { panelDaily, panelWeekly, panelMonthly, panelTopProducts };
            foreach (Panel p in cards) { UiStyle.RoundControl(p,16); UiStyle.AddBorder(p,Color.FromArgb(73,56,46)); }
            LoadReport();
        }

        private void LoadReport()
        {
                    DateTime today = DateTime.Today;
                    DateTime week = today.AddDays(-(((int)today.DayOfWeek + 6) % 7));
                    DateTime month = new DateTime(today.Year, today.Month, 1);
                    lblDailyValue.Text = "₱" + (DatabaseData.Sales.Where(s => s.SaleDate >= today).Sum(s => (decimal?)s.TotalAmount) ?? 0m).ToString("N2");
                    lblWeeklyValue.Text = "₱" + (DatabaseData.Sales.Where(s => s.SaleDate >= week).Sum(s => (decimal?)s.TotalAmount) ?? 0m).ToString("N2");
                    lblMonthlyValue.Text = "₱" + (DatabaseData.Sales.Where(s => s.SaleDate >= month).Sum(s => (decimal?)s.TotalAmount) ?? 0m).ToString("N2");

                    var top = (from si in DatabaseData.SaleItems
                               join s in DatabaseData.Sales on si.SaleID equals s.SaleID
                               join m in DatabaseData.MenuItems on si.MenuItemID equals m.MenuItemID
                               where s.SaleDate >= month
                               group si by m.ItemName into g
                               orderby g.Sum(x => x.Quantity) descending
                               select new { Name = g.Key, MenuItemID = g.First().MenuItemID, Qty = g.Sum(x => x.Quantity), Sales = g.Sum(x => x.Subtotal) }).Take(8).ToList();

                    dgvTopProducts.Rows.Clear();
                    for (int i = 0; i < top.Count; i++)
                    {
                        var item = top[i];
                        MenuItem menuItem = DatabaseData.MenuItems.FirstOrDefault(m => m.MenuItemID == item.MenuItemID);
                        dgvTopProducts.Rows.Add(i + 1, item.Name,
                            menuItem == null ? "Uncategorized" : DatabaseData.CategoryName(menuItem.CategoryID),
                            item.Qty, "₱" + item.Sales.ToString("N2"));
                    }
                    if (top.Count == 0)
                    {
                        int row = dgvTopProducts.Rows.Add("—", "No sales recorded this month", "—", "—", "—");
                        dgvTopProducts.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);
                    }
                    int transactions = DatabaseData.Sales.Count(s => s.SaleDate >= month);
                    int itemsSold = (from si in DatabaseData.SaleItems
                                     join s in DatabaseData.Sales on si.SaleID equals s.SaleID
                                     where s.SaleDate >= month
                                     select si.Quantity).DefaultIfEmpty(0).Sum();
                    lblReportSummary.Text = transactions + (transactions == 1 ? " transaction" : " transactions") + "  •  " + itemsSold + " items sold this month";
                    dgvTopProducts.ClearSelection();
        }
    }
}
