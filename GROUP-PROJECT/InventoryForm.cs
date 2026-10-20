using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class InventoryForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();

        public InventoryForm()
        {
            InitializeComponent();
            SetupImageColumn();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the global database context when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            // Load the current product inventory.
            try
            {
                RefreshInventory();
            }
            catch (Exception ex)
            {
                ShowError("Unable to load Inventory.", ex);
            }
        }

        private void RefreshInventory()
        {
            List<InventoryResult> inventory = db.Adlaw_RetrieveInventory().ToList();
            List<ProductResult> products = db.Adlaw_RetrieveProducts().ToList();

            // Create the readable product name used by the combo box.
            foreach (InventoryResult product in inventory)
            {
                product.DisplayName = product.ItemCode + " - " +
                    product.ItemName + " (" + product.Stock + ")";

                // Match the inventory item with its existing product image.
                foreach (ProductResult productDetails in products)
                {
                    if (productDetails.ProductID == product.ProductID)
                    {
                        product.ImagePath = productDetails.ImagePath;
                        break;
                    }
                }
            }

            gridInventory.DataSource = inventory;
            cboProduct.DataSource = inventory.ToList();
            gridInventory.Columns["ProductID"].Visible = false;
            gridInventory.Columns["DisplayName"].Visible = false;
            gridInventory.Columns["ImagePath"].Visible = false;
            gridInventory.Columns["ItemCode"].HeaderText = "ITEM CODE";
            gridInventory.Columns["ItemName"].HeaderText = "ITEM NAME";
            gridInventory.Columns["Stock"].HeaderText = "AVAILABLE STOCK";

            int lowStockCount = 0;
            foreach (InventoryResult product in inventory)
            {
                if (product.Stock <= 5)
                {
                    lowStockCount++;
                }
            }

            lblSummary.Text = inventory.Count + " product(s)   •   " +
                lowStockCount + " low stock";

            foreach (DataGridViewRow row in gridInventory.Rows)
            {
                InventoryResult product = row.DataBoundItem as InventoryResult;
                row.Cells["ProductImage"].Value = LoadProductImage(product);

                if (Convert.ToInt32(row.Cells["Stock"].Value) <= 5)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                }
            }

            gridInventory.ClearSelection();
            ProductChanged(null, EventArgs.Empty);
        }

        private void SetupImageColumn()
        {
            // Add one image column before the inventory information.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ProductImage";
            imageColumn.HeaderText = "IMAGE";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.FillWeight = 55;
            gridInventory.Columns.Add(imageColumn);
            gridInventory.RowTemplate.Height = 60;
        }

        private Image LoadProductImage(InventoryResult product)
        {
            // Load a small copy so the original image file is not locked.
            if (product == null || string.IsNullOrWhiteSpace(product.ImagePath))
            {
                return null;
            }

            string filePath;
            if (Path.IsPathRooted(product.ImagePath))
                filePath = product.ImagePath;
            else
                filePath = Path.Combine(Application.StartupPath, product.ImagePath);

            if (!File.Exists(filePath))
            {
                return null;
            }

            using (Image source = Image.FromFile(filePath))
            {
                return new Bitmap(source, new Size(50, 50));
            }
        }

        private void ProductChanged(object sender, EventArgs e)
        {
            // Show the selected product stock.
            InventoryResult product = cboProduct.SelectedItem as InventoryResult;
            if (product == null)
            {
                lblProductDetails.Text = "No product available.";
            }
            else
            {
                lblProductDetails.Text = "Current stock: " + product.Stock;
            }
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
            catch (SqlException ex)
            {
                ShowError("Unable to restock.", ex);
            }
        }

        private static void ShowError(string title, Exception ex)
        {
            MessageBox.Show(title + "\n\n" + ex.Message, "Adlaw POS",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
