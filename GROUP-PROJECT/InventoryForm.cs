using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public class InventoryForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();
        private readonly ComboBox cboProduct = new ComboBox();
        private readonly NumericUpDown numQuantity = new NumericUpDown();
        private readonly Label lblProductDetails = new Label();
        private readonly Label lblSummary = new Label();
        private readonly DataGridView gridInventory = new DataGridView();

        public InventoryForm()
        {
            Text = "Adlaw POS - Inventory";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(980, 660);
            MinimumSize = new Size(860, 580);
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 247, 245);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 96,
                BackColor = Color.White
            };
            Label title = NewLabel("INVENTORY", 28, 17);
            title.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(48, 70, 57);
            Label subtitle = NewLabel("Monitor stock levels and restock products.", 31, 59);
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
            header.BringToFront();

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

            Panel restockCard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            layout.Controls.Add(restockCard, 0, 0);
            Label restockTitle = NewLabel("RESTOCK PRODUCT", 22, 15);
            restockTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            restockTitle.ForeColor = Color.FromArgb(48, 70, 57);
            restockCard.Controls.Add(restockTitle);
            Label productLabel = NewLabel("PRODUCT", 22, 49);
            productLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            productLabel.ForeColor = Color.DimGray;
            restockCard.Controls.Add(productLabel);
            Label quantityLabel = NewLabel("ADD STOCK", 402, 49);
            quantityLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            quantityLabel.ForeColor = Color.DimGray;
            restockCard.Controls.Add(quantityLabel);

            cboProduct.SetBounds(22, 70, 355, 29);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.DisplayMember = "DisplayName";
            cboProduct.Font = new Font("Segoe UI", 10F);
            cboProduct.SelectedIndexChanged += ProductChanged;
            restockCard.Controls.Add(cboProduct);

            numQuantity.SetBounds(402, 70, 120, 29);
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 10000;
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.TextAlign = HorizontalAlignment.Center;
            restockCard.Controls.Add(numQuantity);

            Button restock = new Button
            {
                Text = "RESTOCK",
                BackColor = Color.FromArgb(77, 108, 88),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            restock.FlatAppearance.BorderSize = 0;
            restock.SetBounds(548, 65, 150, 40);
            restock.Click += RestockProduct;
            restockCard.Controls.Add(restock);

            lblProductDetails.SetBounds(22, 111, 700, 24);
            lblProductDetails.ForeColor = Color.FromArgb(77, 108, 88);
            lblProductDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            restockCard.Controls.Add(lblProductDetails);

            Panel inventoryHeader = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 245)
            };
            layout.Controls.Add(inventoryHeader, 0, 1);
            Label inventoryTitle = NewLabel("CURRENT STOCK", 4, 23);
            inventoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            inventoryTitle.ForeColor = Color.FromArgb(48, 70, 57);
            inventoryHeader.Controls.Add(inventoryTitle);
            lblSummary.AutoSize = false;
            lblSummary.TextAlign = ContentAlignment.MiddleRight;
            lblSummary.ForeColor = Color.DimGray;
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSummary.SetBounds(520, 19, 360, 30);
            inventoryHeader.Controls.Add(lblSummary);

            gridInventory.Dock = DockStyle.Fill;
            gridInventory.ReadOnly = true;
            gridInventory.AllowUserToAddRows = false;
            gridInventory.AllowUserToDeleteRows = false;
            gridInventory.AllowUserToResizeRows = false;
            gridInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridInventory.BackgroundColor = Color.White;
            gridInventory.BorderStyle = BorderStyle.None;
            gridInventory.RowHeadersVisible = false;
            gridInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridInventory.MultiSelect = false;
            gridInventory.EnableHeadersVisualStyles = false;
            gridInventory.ColumnHeadersHeight = 42;
            gridInventory.RowTemplate.Height = 38;
            gridInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(77, 108, 88);
            gridInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridInventory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridInventory.DefaultCellStyle.BackColor = Color.White;
            gridInventory.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 48);
            gridInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 237, 229);
            gridInventory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(48, 70, 57);
            gridInventory.DefaultCellStyle.Padding = new Padding(5);
            gridInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 248);
            layout.Controls.Add(gridInventory, 0, 2);

            Load += InventoryForm_Load;
        }

        private static Label NewLabel(string text, int x, int y)
        {
            return new Label { Text = text, AutoSize = true, Location = new Point(x, y) };
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load Inventory.\n\n" + ex.Message,
                    "Adlaw POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshInventory()
        {
            List<InventoryResult> inventory = db.Adlaw_RetrieveInventory().ToList();
            gridInventory.DataSource = inventory;
            cboProduct.DataSource = inventory.ToList();
            gridInventory.Columns["ProductID"].Visible = false;
            gridInventory.Columns["DisplayName"].Visible = false;
            gridInventory.Columns["ItemCode"].HeaderText = "ITEM CODE";
            gridInventory.Columns["ItemName"].HeaderText = "ITEM NAME";
            gridInventory.Columns["Stock"].HeaderText = "AVAILABLE STOCK";
            lblSummary.Text = inventory.Count + " product(s)   •   " +
                inventory.Count(product => product.Stock <= 5) + " low stock";

            foreach (DataGridViewRow row in gridInventory.Rows)
            {
                if (Convert.ToInt32(row.Cells["Stock"].Value) <= 5)
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
            }

            gridInventory.ClearSelection();
            ProductChanged(null, EventArgs.Empty);
        }

        private void ProductChanged(object sender, EventArgs e)
        {
            InventoryResult product = cboProduct.SelectedItem as InventoryResult;
            lblProductDetails.Text = product == null
                ? "No product available."
                : "Current stock: " + product.Stock;
        }

        private void RestockProduct(object sender, EventArgs e)
        {
            InventoryResult product = cboProduct.SelectedItem as InventoryResult;
            if (product == null)
            {
                MessageBox.Show("Select a product to restock.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Add stock only to an active product.
                int updated = db.Adlaw_RestockProduct(
                    product.ProductID, (int)numQuantity.Value);
                if (updated == 0)
                {
                    MessageBox.Show("The product is no longer available.",
                        "Unable to restock", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Stock updated successfully.", "Adlaw POS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                RefreshInventory();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Unable to restock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshInventory();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
