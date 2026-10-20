using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class SalesForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();

        public SalesForm() { InitializeComponent(); }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the database context when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            // Load products and sales history.
            try { RefreshData(); }
            catch (Exception ex) { ShowError("Unable to load Sales.", ex); }
        }

        private void RefreshData()
        {
            cboProduct.DataSource = db.Adlaw_RetrieveProducts().ToList();
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
            lblSummary.Text = sales.Count + " sale(s)   •   Total: ₱" +
                sales.Sum(sale => sale.Subtotal).ToString("N2");
            gridSales.ClearSelection();
            ProductChanged(null, EventArgs.Empty);
        }

        private void ProductChanged(object sender, EventArgs e)
        {
            // Show the selected product details.
            ProductResult product = cboProduct.SelectedItem as ProductResult;
            if (product == null)
                lblDetails.Text = "No product available.";
            else
                lblDetails.Text = "Price: ₱" + product.Price.ToString("N2") +
                    "   •   Available stock: " + product.Stock;
        }

        private void CompleteSale(object sender, EventArgs e)
        {
            // Save a sale and reduce its product stock.
            ProductResult product = cboProduct.SelectedItem as ProductResult;
            int quantity = (int)numQuantity.Value;
            if (product == null || quantity > product.Stock)
            {
                MessageBox.Show("Select a product with enough stock.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int saleID = db.Adlaw_CreateSale(product.ProductID, quantity);
                if (saleID == 0)
                    MessageBox.Show("Product is unavailable or has insufficient stock.",
                        "Adlaw POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Sale completed successfully.", "Adlaw POS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                numQuantity.Value = 1;
                RefreshData();
            }
            catch (SqlException ex) { ShowError("Unable to complete sale.", ex); }
        }

        private static void ShowError(string title, Exception ex)
        {
            MessageBox.Show(title + "\n\n" + ex.Message, "Adlaw POS",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
