using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class SalesForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();

        public SalesForm()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the database context when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            // Load the sales report when the form opens.
            LoadSalesReport();
        }

        private void RefreshReport(object sender, EventArgs e)
        {
            // Reload the latest completed orders.
            LoadSalesReport();
        }

        private void LoadSalesReport()
        {
            try
            {
                List<SaleResult> sales = db.Adlaw_RetrieveSales().ToList();
                gridSales.DataSource = sales;

                gridSales.Columns["SaleID"].HeaderText = "SALE #";
                gridSales.Columns["SaleDate"].HeaderText = "DATE / TIME";
                gridSales.Columns["ItemCode"].HeaderText = "ITEM CODE";
                gridSales.Columns["ItemName"].HeaderText = "ITEM NAME";
                gridSales.Columns["UnitPrice"].HeaderText = "UNIT PRICE";
                gridSales.Columns["UnitPrice"].DefaultCellStyle.Format = "₱#,##0.00";
                gridSales.Columns["Subtotal"].DefaultCellStyle.Format = "₱#,##0.00";
                gridSales.Columns["SaleDate"].DefaultCellStyle.Format = "MMM dd, yyyy  h:mm tt";

                int orderCount = sales.Select(sale => sale.SaleID).Distinct().Count();
                decimal totalSales = sales.Sum(sale => sale.Subtotal);
                lblOrdersValue.Text = orderCount.ToString();
                lblItemsValue.Text = sales.Sum(sale => sale.Quantity).ToString();
                lblRevenueValue.Text = "₱" + totalSales.ToString("N2");
                lblSummary.Text = sales.Count + " sale item(s) recorded";
                gridSales.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the sales report.\n\n" + ex.Message,
                    "Adlaw POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
