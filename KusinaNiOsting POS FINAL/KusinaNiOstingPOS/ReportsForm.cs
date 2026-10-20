using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace MiniMartPOS
{
    public partial class ReportsForm : Form
    {
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();
        public ReportsForm()
        {
            InitializeComponent();
            Panel[] cards = { panelDaily, panelWeekly, panelMonthly, panelTopProducts };
            foreach (Panel p in cards) { UiStyle.RoundControl(p,16); UiStyle.AddBorder(p,Color.FromArgb(73,56,46)); }
            LoadReport();
        }

        private void LoadReport()
        {
                    ReportSummaryRow summary = db.GetReportSummary().FirstOrDefault();
                    if (summary == null)
                        return;

                    lblDailyValue.Text = "₱" + summary.DailySales.ToString("N2");
                    lblWeeklyValue.Text = "₱" + summary.WeeklySales.ToString("N2");
                    lblMonthlyValue.Text = "₱" + summary.MonthlySales.ToString("N2");
                    var top = db.GetTopProducts().ToList();

                    dgvTopProducts.Rows.Clear();
                    for (int i = 0; i < top.Count; i++)
                    {
                        TopProductRow item = top[i];
                        dgvTopProducts.Rows.Add(i + 1, item.ItemName,
                            item.CategoryName, item.Quantity,
                            "₱" + item.TotalSales.ToString("N2"));
                    }
                    if (top.Count == 0)
                    {
                        int row = dgvTopProducts.Rows.Add("—", "No sales recorded this month", "—", "—", "—");
                        dgvTopProducts.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);
                    }
                    lblReportSummary.Text = summary.TransactionCount +
                        (summary.TransactionCount == 1 ? " transaction" : " transactions") +
                        "  •  " + summary.ItemsSold + " items sold this month";
                    dgvTopProducts.ClearSelection();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
