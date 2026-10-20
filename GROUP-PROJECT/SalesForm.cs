using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public class SalesForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();
        private readonly ComboBox cboProduct = new ComboBox();
        private readonly NumericUpDown numQuantity = new NumericUpDown();
        private readonly Label lblDetails = new Label();
        private readonly DataGridView gridSales = new DataGridView();

        public SalesForm()
        {
            Text = "Adlaw POS - Sales";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(900, 620);
            Font = new Font("Segoe UI", 9F);

            Label title = NewLabel("SALES / POS", 25, 20);
            title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(48, 70, 57);

            Controls.Add(title);
            Controls.Add(NewLabel("PRODUCT", 30, 82));
            Controls.Add(NewLabel("QUANTITY", 380, 82));

            cboProduct.SetBounds(30, 105, 330, 25);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.DisplayMember = "ItemName";
            cboProduct.SelectedIndexChanged += ProductChanged;
            Controls.Add(cboProduct);

            numQuantity.SetBounds(380, 105, 110, 25);
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;
            Controls.Add(numQuantity);

            Button checkout = new Button
            {
                Text = "COMPLETE SALE",
                BackColor = Color.FromArgb(77, 108, 88),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            checkout.SetBounds(510, 98, 150, 38);
            checkout.Click += CompleteSale;
            Controls.Add(checkout);

            lblDetails.SetBounds(30, 143, 600, 25);
            Controls.Add(lblDetails);

            gridSales.SetBounds(30, 180, 820, 355);
            gridSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                               AnchorStyles.Left | AnchorStyles.Right;
            gridSales.ReadOnly = true;
            gridSales.AllowUserToAddRows = false;
            gridSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Controls.Add(gridSales);

            Load += SalesForm_Load;
        }

        private static Label NewLabel(string text, int x, int y)
        {
            return new Label { Text = text, AutoSize = true, Location = new Point(x, y) };
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            cboProduct.DataSource = db.Adlaw_RetrieveProducts().ToList();
            gridSales.DataSource = db.Adlaw_RetrieveSales().ToList();
            gridSales.Columns["UnitPrice"].DefaultCellStyle.Format = "₱#,##0.00";
            gridSales.Columns["Subtotal"].DefaultCellStyle.Format = "₱#,##0.00";
        }

        private void ProductChanged(object sender, EventArgs e)
        {
            ProductResult product = cboProduct.SelectedItem as ProductResult;
            lblDetails.Text = product == null ? "No product available."
                : "Price: ₱" + product.Price.ToString("N2") +
                  "   Stock: " + product.Stock;
        }

        private void CompleteSale(object sender, EventArgs e)
        {
            ProductResult product = cboProduct.SelectedItem as ProductResult;
            int quantity = (int)numQuantity.Value;

            if (product == null || quantity > product.Stock)
            {
                MessageBox.Show("Select a product with enough stock.", "Adlaw POS");
                return;
            }

            try
            {
                // Save the sale and let SQL verify the current stock.
                int saleID = db.Adlaw_CreateSale(product.ProductID, quantity);
                if (saleID == 0)
                {
                    MessageBox.Show("Product is unavailable or has insufficient stock.",
                        "Unable to complete sale", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    RefreshData();
                    return;
                }

                MessageBox.Show("Sale completed successfully.", "Adlaw POS");
                RefreshData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Unable to complete sale",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshData();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
