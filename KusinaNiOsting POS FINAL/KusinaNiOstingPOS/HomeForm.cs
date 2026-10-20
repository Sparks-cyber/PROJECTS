using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MiniMartPOS
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            UiStyle.PolishForm(this);
            ConfigureRoundedCards();
            cmbPeriod.SelectedIndex = 0;
            cmbPeriod.SelectedIndexChanged += cmbPeriod_SelectedIndexChanged;
            LoadDashboardData();
        }

        private void ConfigureRoundedCards()
        {
            Panel[] cards = { panelSalesCard, panelProductsCard, panelTransactionsCard, panelStockCard,
                panelSalesOverview, panelPaymentMethods, panelRecentTransactions, panelLowStock };
            foreach (Panel card in cards) { UiStyle.RoundControl(card, 16); UiStyle.AddBorder(card, Color.FromArgb(73, 56, 46)); }
            UiStyle.RoundControl(lblCriticalBadge, 7); UiStyle.RoundControl(lblLowBadge1, 7); UiStyle.RoundControl(lblLowBadge2, 7); UiStyle.RoundControl(lblLowBadge3, 7);
        }

        private void LoadDashboardData()
        {
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);
                    var todaySales = DatabaseData.Sales.Where(s => s.SaleDate >= today && s.SaleDate < tomorrow);

                    decimal salesTotal = todaySales.Sum(s => (decimal?)s.TotalAmount) ?? 0m;
                    int transCount = todaySales.Count();
                    int menuCount = DatabaseData.MenuItems.Count(m => m.IsActive);
                    int lowCount = DatabaseData.MenuItems.Count(m => m.IsActive && m.Stock <= m.ReorderLevel);

                    lblSalesValue.Text = "₱" + salesTotal.ToString("N2");
                    lblProductsValue.Text = menuCount.ToString();
                    lblTransactionsValue.Text = transCount.ToString();
                    lblStockValue.Text = lowCount.ToString();
                    lblSalesTrend.Text = "Total sales recorded today";
                    lblProductsTrend.Text = "Active menu items";
                    lblTransactionsTrend.Text = "Completed today";
                    lblStockTrend.Text = lowCount > 0 ? "Attention needed" : "Stock levels are good";

                    LoadSalesChart(); LoadCategoryChart(); LoadRecentTransactions(); LoadLowStock();
        }

        // EVENT: cmbPeriod_SelectedIndexChanged - runs when the user interacts with this control.

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalesChart();
        }

        private void LoadSalesChart()
        {
            chartSales.Series.Clear();
            chartSales.ChartAreas.Clear();
            chartSales.Legends.Clear();

            ChartArea area = new ChartArea("SalesArea");
            area.BackColor = Color.Transparent;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(51, 65, 85);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(148, 163, 184);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(73, 56, 46);
            area.AxisY.LineColor = Color.FromArgb(51, 65, 85);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(148, 163, 184);
            chartSales.ChartAreas.Add(area);

            Series series = new Series("Sales");
            series.ChartType = SeriesChartType.SplineArea;
            series.Color = Color.FromArgb(245, 158, 11);
            series.BorderColor = Color.FromArgb(251, 191, 36);
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 6;
            series.MarkerColor = Color.White;

            int days = cmbPeriod.SelectedIndex == 1 ? 30 : 7;
            for (int i = days - 1; i >= 0; i--)
            {
                DateTime day = DateTime.Today.AddDays(-i);
                DateTime next = day.AddDays(1);
                decimal total = DatabaseData.Sales
                    .Where(x => x.SaleDate >= day && x.SaleDate < next)
                    .Sum(x => (decimal?)x.TotalAmount) ?? 0m;

                string label = days == 7 ? day.ToString("ddd") : day.ToString("MM/dd");
                series.Points.AddXY(label, total);
            }

            chartSales.Series.Add(series);
        }

        private void LoadCategoryChart()
        {
            chartPayment.Series.Clear(); chartPayment.ChartAreas.Clear(); chartPayment.Legends.Clear();
            ChartArea area = new ChartArea("CategoryArea"); area.BackColor = Color.Transparent; chartPayment.ChartAreas.Add(area);
            Series series = new Series("Categories"); series.ChartType = SeriesChartType.Doughnut; series["DoughnutRadius"] = "58";
            DateTime start = DateTime.Today.AddDays(-30);
            var data = (from si in DatabaseData.SaleItems
                        join s in DatabaseData.Sales on si.SaleID equals s.SaleID
                        join m in DatabaseData.MenuItems on si.MenuItemID equals m.MenuItemID
                        join c in DatabaseData.Categories on m.CategoryID equals c.CategoryID
                        where s.SaleDate >= start
                        group si by c.CategoryName into g
                        select new { Category = g.Key, Total = g.Sum(x => x.Subtotal) })
                        .OrderByDescending(x => x.Total).Take(4).ToList();

            if (data.Count == 0) series.Points.AddXY("No sales yet", 1);
            else foreach (var x in data) series.Points.AddXY(x.Category, x.Total);
            chartPayment.Series.Add(series);

            Label[] names = { lblCash, lblGcash, lblCard, lblOther };
            Label[] values = { lblCashValue, lblGcashValue, lblCardValue, lblOtherValue };
            decimal grand = data.Sum(x => x.Total);
            for (int i = 0; i < names.Length; i++)
            {
                if (i < data.Count)
                {
                    names[i].Text = "■ " + data[i].Category;
                    values[i].Text = grand == 0 ? "0%" : ((data[i].Total / grand) * 100m).ToString("0") + "%";
                    names[i].Visible = values[i].Visible = true;
                }
                else { names[i].Visible = values[i].Visible = false; }
            }
        }

        private void LoadRecentTransactions()
        {
            dgvRecent.Rows.Clear();
            var sales = DatabaseData.Sales.OrderByDescending(s => s.SaleDate).Take(5).ToList();
            foreach (Sale sale in sales)
            {
                var lines = (from si in DatabaseData.SaleItems join m in DatabaseData.MenuItems on si.MenuItemID equals m.MenuItemID where si.SaleID == sale.SaleID select new { m.ItemName, si.Quantity }).ToList();
                string items = string.Join(", ", lines.Select(x => x.ItemName + (x.Quantity > 1 ? " x" + x.Quantity : "")));
                int qty = lines.Sum(x => x.Quantity);
                dgvRecent.Rows.Add(sale.TransactionNo, items, qty, "₱" + sale.TotalAmount.ToString("N2"), sale.PaymentMethod, sale.SaleDate.ToString("h:mm tt"));
            }
        }

        private void LoadLowStock()
        {
            var low = DatabaseData.MenuItems.Where(m => m.IsActive && m.Stock <= m.ReorderLevel).OrderBy(m => m.Stock).Take(4).ToList();
            Label[] itemLabels = { lblLowItem1, lblLowItem2, lblLowItem3, lblLowItem4 };
            Label[] badges = { lblCriticalBadge, lblLowBadge1, lblLowBadge2, lblLowBadge3 };
            for (int i = 0; i < itemLabels.Length; i++)
            {
                if (i < low.Count)
                {
                    itemLabels[i].Text = low[i].ItemName + "   Stock: " + low[i].Stock;
                    badges[i].Text = low[i].Stock == 0 ? "OUT" : low[i].Stock <= Math.Max(1, low[i].ReorderLevel / 2) ? "CRITICAL" : "LOW";
                    itemLabels[i].Visible = badges[i].Visible = true;
                }
                else { itemLabels[i].Visible = badges[i].Visible = false; }
            }
        }
    }
}
