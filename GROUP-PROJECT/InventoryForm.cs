using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class InventoryForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();

        public InventoryForm() { InitializeComponent(); }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the global database context when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            // Load the current product inventory.
            try { RefreshInventory(); }
            catch (Exception ex) { ShowError("Unable to load Inventory.", ex); }
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
                if (Convert.ToInt32(row.Cells["Stock"].Value) <= 5)
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
            gridInventory.ClearSelection();
            ProductChanged(null, EventArgs.Empty);
        }

        private void ProductChanged(object sender, EventArgs e)
        {
            // Show the selected product stock.
            InventoryResult product = cboProduct.SelectedItem as InventoryResult;
            if (product == null)
                lblProductDetails.Text = "No product available.";
            else
                lblProductDetails.Text = "Current stock: " + product.Stock;
        }

        private void RestockProduct(object sender, EventArgs e)
        {
            // Add stock to the selected product.
            InventoryResult product = cboProduct.SelectedItem as InventoryResult;
            if (product == null)
            {
                MessageBox.Show("Select a product to restock.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                db.Adlaw_RestockProduct(
                    product.ProductID, (int)numQuantity.Value);
                MessageBox.Show("Stock updated successfully.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                numQuantity.Value = 1;
                RefreshInventory();
            }
            catch (SqlException ex) { ShowError("Unable to restock.", ex); }
        }

        private static void ShowError(string title, Exception ex)
        {
            MessageBox.Show(title + "\n\n" + ex.Message, "Adlaw POS",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
