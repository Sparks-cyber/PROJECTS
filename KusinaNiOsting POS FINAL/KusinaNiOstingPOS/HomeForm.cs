using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MiniMartPOS
{
    public partial class HomeForm : Form
    {
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();
        public HomeForm()
        {
            InitializeComponent();
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
                    DashboardSummaryRow summary = db.GetDashboardSummary().FirstOrDefault();
                    if (summary == null)
                        return;

                    lblSalesValue.Text = "₱" + summary.TodaySales.ToString("N2");
                    lblProductsValue.Text = summary.ActiveProducts.ToString();
                    lblTransactionsValue.Text = summary.TodayTransactions.ToString();
                    lblStockValue.Text = summary.LowStockCount.ToString();
                    lblSalesTrend.Text = "Total sales recorded today";
                    lblProductsTrend.Text = "Active menu items";
                    lblTransactionsTrend.Text = "Completed today";
                    lblStockTrend.Text = summary.LowStockCount > 0 ? "Attention needed" : "Stock levels are good";

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
            foreach (DailySalesRow sale in db.GetDailySales(days))
            {
                string label = days == 7
                    ? sale.SaleDay.ToString("ddd") : sale.SaleDay.ToString("MM/dd");
                series.Points.AddXY(label, sale.TotalSales);
            }

            chartSales.Series.Add(series);
        }

        private void LoadCategoryChart()
        {
            chartPayment.Series.Clear(); chartPayment.ChartAreas.Clear(); chartPayment.Legends.Clear();
            ChartArea area = new ChartArea("CategoryArea"); area.BackColor = Color.Transparent; chartPayment.ChartAreas.Add(area);
            Series series = new Series("Categories"); series.ChartType = SeriesChartType.Doughnut; series["DoughnutRadius"] = "58";
            var data = db.GetCategorySales().ToList();

            if (data.Count == 0) series.Points.AddXY("No sales yet", 1);
            else foreach (CategorySalesRow item in data)
                series.Points.AddXY(item.CategoryName, item.TotalSales);
            chartPayment.Series.Add(series);

            Label[] names = { lblCash, lblGcash, lblCard, lblOther };
            Label[] values = { lblCashValue, lblGcashValue, lblCardValue, lblOtherValue };
            decimal grand = data.Sum(x => x.TotalSales);
            for (int i = 0; i < names.Length; i++)
            {
                if (i < data.Count)
                {
                    names[i].Text = "■ " + data[i].CategoryName;
                    values[i].Text = grand == 0 ? "0%" : ((data[i].TotalSales / grand) * 100m).ToString("0") + "%";
                    names[i].Visible = values[i].Visible = true;
                }
                else { names[i].Visible = values[i].Visible = false; }
            }
        }

        private void LoadRecentTransactions()
        {
            dgvRecent.Rows.Clear();
            foreach (GetRecentTransactionsResult sale in db.GetRecentTransactions())
            {
                var lines = db.GetSaleItems(sale.SaleID).ToList();
                string items = string.Join(", ", lines.Select(x => x.ItemName + (x.Quantity > 1 ? " x" + x.Quantity : "")));
                int qty = lines.Sum(x => x.Quantity);
                dgvRecent.Rows.Add(sale.TransactionNo, items, qty, "₱" + sale.TotalAmount.ToString("N2"), sale.PaymentMethod, sale.SaleDate.ToString("h:mm tt"));
            }
        }

        private void LoadLowStock()
        {
            var low = db.GetLowStockItems().ToList();
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
