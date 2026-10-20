using System;
using System.Collections.Generic;
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
        private readonly DataGridView gridInventory = new DataGridView();

        public InventoryForm()
        {
            Text = "Adlaw POS - Inventory";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(800, 580);
            Font = new Font("Segoe UI", 9F);

            Label title = new Label
            {
                Text = "INVENTORY",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(48, 70, 57),
                AutoSize = true,
                Location = new Point(25, 20)
            };
            Controls.Add(title);
            Controls.Add(new Label { Text = "PRODUCT", AutoSize = true, Location = new Point(30, 82) });
            Controls.Add(new Label { Text = "ADD STOCK", AutoSize = true, Location = new Point(380, 82) });

            cboProduct.SetBounds(30, 105, 330, 25);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.DisplayMember = "DisplayName";
            Controls.Add(cboProduct);

            numQuantity.SetBounds(380, 105, 110, 25);
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 10000;
            Controls.Add(numQuantity);

            Button restock = new Button
            {
                Text = "RESTOCK",
                BackColor = Color.FromArgb(77, 108, 88),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            restock.SetBounds(510, 98, 130, 38);
            restock.Click += RestockProduct;
            Controls.Add(restock);

            gridInventory.SetBounds(30, 160, 720, 350);
            gridInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                                   AnchorStyles.Left | AnchorStyles.Right;
            gridInventory.ReadOnly = true;
            gridInventory.AllowUserToAddRows = false;
            gridInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Controls.Add(gridInventory);

            Load += InventoryForm_Load;
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            RefreshInventory();
        }

        private void RefreshInventory()
        {
            List<InventoryResult> inventory = db.Adlaw_RetrieveInventory().ToList();
            gridInventory.DataSource = inventory;
            cboProduct.DataSource = inventory.ToList();
            gridInventory.Columns["ProductID"].Visible = false;
            gridInventory.Columns["DisplayName"].Visible = false;

            foreach (DataGridViewRow row in gridInventory.Rows)
            {
                if (Convert.ToInt32(row.Cells["Stock"].Value) <= 5)
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }

        private void RestockProduct(object sender, EventArgs e)
        {
            InventoryResult product = cboProduct.SelectedItem as InventoryResult;
            if (product == null) return;

            db.Adlaw_RestockProduct(product.ProductID, (int)numQuantity.Value);
            MessageBox.Show("Stock updated successfully.", "Adlaw POS");
            RefreshInventory();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
