using System;
using System.Collections.Generic;
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
        private readonly Label lblSummary = new Label();
        private readonly DataGridView gridSales = new DataGridView();

        public SalesForm()
        {
            Text = "Adlaw POS - Sales";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(1020, 680);
            MinimumSize = new Size(900, 600);
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 247, 245);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 96,
                BackColor = Color.White,
                Padding = new Padding(28, 16, 28, 12)
            };
            Label title = NewLabel("SALES / POS", 28, 17);
            title.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(48, 70, 57);
            Label subtitle = NewLabel("Complete orders and review recent sales.", 31, 59);
            subtitle.ForeColor = Color.DimGray;
            header.Controls.Add(title);
            header.Controls.Add(subtitle);
            Controls.Add(header);

            Panel content = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24, 22, 24, 24),
                BackColor = Color.FromArgb(245, 247, 245)
            };
            Controls.Add(content);

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Controls.Add(layout);

            Panel orderCard = new Panel
            {
                Dock = DockStyle.Top,
                Height = 152,
                BackColor = Color.White,
                Padding = new Padding(22)
            };
            layout.Controls.Add(orderCard, 0, 0);

            Label orderTitle = NewLabel("NEW ORDER", 22, 15);
            orderTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            orderTitle.ForeColor = Color.FromArgb(48, 70, 57);
            orderCard.Controls.Add(orderTitle);
            Label productLabel = NewLabel("PRODUCT", 22, 49);
            productLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            productLabel.ForeColor = Color.DimGray;
            orderCard.Controls.Add(productLabel);
            Label quantityLabel = NewLabel("QUANTITY", 402, 49);
            quantityLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            quantityLabel.ForeColor = Color.DimGray;
            orderCard.Controls.Add(quantityLabel);

            cboProduct.SetBounds(22, 70, 355, 29);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.DisplayMember = "ItemName";
            cboProduct.Font = new Font("Segoe UI", 10F);
            cboProduct.SelectedIndexChanged += ProductChanged;
            orderCard.Controls.Add(cboProduct);

            numQuantity.SetBounds(402, 70, 120, 29);
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.TextAlign = HorizontalAlignment.Center;
            orderCard.Controls.Add(numQuantity);

            Button checkout = new Button
            {
                Text = "COMPLETE SALE",
                BackColor = Color.FromArgb(77, 108, 88),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            checkout.FlatAppearance.BorderSize = 0;
            checkout.SetBounds(548, 65, 170, 40);
            checkout.Click += CompleteSale;
            orderCard.Controls.Add(checkout);

            lblDetails.SetBounds(22, 111, 700, 24);
            lblDetails.ForeColor = Color.FromArgb(77, 108, 88);
            lblDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderCard.Controls.Add(lblDetails);

            Panel historyHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                Padding = new Padding(4, 22, 4, 8),
                BackColor = Color.FromArgb(245, 247, 245)
            };
            layout.Controls.Add(historyHeader, 0, 1);
            Label historyTitle = NewLabel("SALES HISTORY", 4, 23);
            historyTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            historyTitle.ForeColor = Color.FromArgb(48, 70, 57);
            historyHeader.Controls.Add(historyTitle);
            lblSummary.AutoSize = false;
            lblSummary.TextAlign = ContentAlignment.MiddleRight;
            lblSummary.ForeColor = Color.DimGray;
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSummary.SetBounds(560, 19, 360, 30);
            historyHeader.Controls.Add(lblSummary);

            gridSales.Dock = DockStyle.Fill;
            gridSales.ReadOnly = true;
            gridSales.AllowUserToAddRows = false;
            gridSales.AllowUserToDeleteRows = false;
            gridSales.AllowUserToResizeRows = false;
            gridSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSales.BackgroundColor = Color.White;
            gridSales.BorderStyle = BorderStyle.None;
            gridSales.RowHeadersVisible = false;
            gridSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSales.MultiSelect = false;
            gridSales.EnableHeadersVisualStyles = false;
            gridSales.ColumnHeadersHeight = 42;
            gridSales.RowTemplate.Height = 38;
            gridSales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(77, 108, 88);
            gridSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridSales.DefaultCellStyle.BackColor = Color.White;
            gridSales.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 48);
            gridSales.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 237, 229);
            gridSales.DefaultCellStyle.SelectionForeColor = Color.FromArgb(48, 70, 57);
            gridSales.DefaultCellStyle.Padding = new Padding(5);
            gridSales.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 248);
            layout.Controls.Add(gridSales, 0, 2);

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
