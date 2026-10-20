using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class CustomerOrderForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();
        private readonly BindingList<CartItem> cart = new BindingList<CartItem>();

        public CustomerOrderForm()
        {
            InitializeComponent();
            SetupMenuColumns();
            gridCart.AutoGenerateColumns = true;
            gridCart.DataSource = cart;
            SetupCartColumns();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the global database context when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void CustomerOrderForm_Load(object sender, EventArgs e)
        {
            // Load the customer menu.
            LoadMenu();
        }

        private void SearchMenu(object sender, EventArgs e)
        {
            // Refresh the menu using the search text.
            LoadMenu();
        }

        private void LoadMenu()
        {
            string search = txtSearch.Text.Trim();
            List<ProductResult> products;

            if (string.IsNullOrWhiteSpace(search))
            {
                products = db.Adlaw_RetrieveProducts().ToList();
            }
            else
            {
                products = db.Adlaw_SearchProducts(search).ToList();
            }

            DisplayMenu(products);
        }

        private void SetupMenuColumns()
        {
            gridMenu.AutoGenerateColumns = false;
            gridMenu.Columns.Clear();

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ProductImage";
            imageColumn.HeaderText = "IMAGE";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.Width = 62;
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            gridMenu.Columns.Add(imageColumn);

            gridMenu.Columns.Add("ItemName", "MENU ITEM");
            gridMenu.Columns.Add("Category", "CATEGORY");
            gridMenu.Columns.Add("Price", "PRICE");
            gridMenu.Columns.Add("Stock", "STOCK");
            gridMenu.Columns["ItemName"].FillWeight = 135;
            gridMenu.Columns["Category"].FillWeight = 75;
            gridMenu.Columns["Price"].FillWeight = 60;
            gridMenu.Columns["Stock"].FillWeight = 45;
        }

        private void DisplayMenu(List<ProductResult> products)
        {
            gridMenu.Rows.Clear();

            foreach (ProductResult product in products)
            {
                Image productImage = null;
                string imagePath = product.ImagePath;

                if (imagePath == null)
                {
                    imagePath = "";
                }

                string filePath = imagePath;
                if (!Path.IsPathRooted(filePath))
                {
                    filePath = Path.Combine(Application.StartupPath, imagePath);
                }

                if (File.Exists(filePath))
                {
                    using (Image source = Image.FromFile(filePath))
                    {
                        productImage = new Bitmap(source, new Size(45, 45));
                    }
                }

                int rowIndex = gridMenu.Rows.Add(
                    productImage,
                    product.ItemName,
                    GetCategoryName(product.CategoryID),
                    "₱" + product.Price.ToString("N2"),
                    product.Stock
                );

                gridMenu.Rows[rowIndex].Tag = product;
            }

            gridMenu.ClearSelection();
        }

        private string GetCategoryName(int categoryID)
        {
            if (categoryID == 1)
            {
                return "Coffee";
            }
            else if (categoryID == 2)
            {
                return "Matcha";
            }
            else if (categoryID == 3)
            {
                return "Non Coffee";
            }
            else
            {
                return "Refresher";
            }
        }

        private void SetupCartColumns()
        {
            if (gridCart.Columns["ProductID"] != null)
            {
                gridCart.Columns["ProductID"].Visible = false;
            }

            if (gridCart.Columns["AvailableStock"] != null)
            {
                gridCart.Columns["AvailableStock"].Visible = false;
            }

            if (gridCart.Columns["ItemCode"] != null)
            {
                gridCart.Columns["ItemCode"].HeaderText = "CODE";
            }

            if (gridCart.Columns["ItemName"] != null)
            {
                gridCart.Columns["ItemName"].HeaderText = "ITEM";
            }

            if (gridCart.Columns["UnitPrice"] != null)
            {
                gridCart.Columns["UnitPrice"].HeaderText = "PRICE";
                gridCart.Columns["UnitPrice"].DefaultCellStyle.Format = "₱#,##0.00";
            }
            if (gridCart.Columns["Subtotal"] != null)
            {
                gridCart.Columns["Subtotal"].DefaultCellStyle.Format = "₱#,##0.00";
            }
        }

        private void AddToCart(object sender, EventArgs e)
        {
            // Add the selected menu item to the cart.
            ProductResult product = null;
            if (gridMenu.CurrentRow != null)
            {
                product = gridMenu.CurrentRow.Tag as ProductResult;
            }

            // Every Add to Cart click adds one item.
            int quantity = 1;
            if (product == null)
            {
                Warn("Select a menu item first.");
                return;
            }

            CartItem existing = null;
            foreach (CartItem item in cart)
            {
                if (item.ProductID == product.ProductID)
                {
                    existing = item;
                    break;
                }
            }
            int newQuantity = quantity;
            if (existing != null)
            {
                newQuantity += existing.Quantity;
            }

            if (newQuantity > product.Stock)
            {
                Warn("Only " + product.Stock + " item(s) are available.");
                return;
            }

            if (existing == null)
            {
                cart.Add(new CartItem { ProductID = product.ProductID, ItemCode = product.ItemCode,
                    ItemName = product.ItemName, UnitPrice = product.Price, Quantity = quantity,
                    AvailableStock = product.Stock });
            }
            else
            {
                existing.Quantity = newQuantity;
            }

            gridCart.Refresh();
            UpdateTotals();
        }

        private void DecreaseCartQuantity(object sender, EventArgs e)
        {
            // Decrease the selected cart quantity.
            CartItem item = GetSelectedCartItem();
            if (item == null)
            {
                Warn("Select a cart item first.");
                return;
            }

            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                cart.Remove(item);
            }

            gridCart.Refresh();
            UpdateTotals();
        }

        private void IncreaseCartQuantity(object sender, EventArgs e)
        {
            // Increase the selected cart quantity.
            CartItem item = GetSelectedCartItem();
            if (item == null)
            {
                Warn("Select a cart item first.");
                return;
            }

            if (item.Quantity >= item.AvailableStock)
            {
                Warn("Only " + item.AvailableStock + " item(s) are available.");
                return;
            }

            item.Quantity++;
            gridCart.Refresh();
            UpdateTotals();
        }

        private CartItem GetSelectedCartItem()
        {
            if (gridCart.CurrentRow == null)
            {
                return null;
            }

            return gridCart.CurrentRow.DataBoundItem as CartItem;
        }

        private void RemoveCartItem(object sender, EventArgs e)
        {
            // Remove the selected item from the cart.
            CartItem item = null;
            if (gridCart.CurrentRow != null)
            {
                item = gridCart.CurrentRow.DataBoundItem as CartItem;
            }

            if (item != null)
            {
                cart.Remove(item);
            }

            UpdateTotals();
        }

        private void CashChanged(object sender, EventArgs e)
        {
            // Recalculate the customer's change.
            UpdateTotals();
        }

        private decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (CartItem item in cart)
                {
                    total += item.Subtotal;
                }

                return total;
            }
        }

        private void UpdateTotals()
        {
            lblTotal.Text = "TOTAL: ₱" + Total.ToString("N2");
            decimal change = numCash.Value - Total;
            if (change < 0)
            {
                change = 0;
            }

            lblChange.Text = "CHANGE: ₱" + change.ToString("N2");
        }

        private void Checkout(object sender, EventArgs e)
        {
            // Save the order and display its receipt.
            if (cart.Count == 0)
            {
                Warn("Add at least one item to the cart.");
                return;
            }

            if (numCash.Value < Total)
            {
                Warn("Cash received is not enough.");
                return;
            }

            decimal change = numCash.Value - Total;
            DialogResult confirmation = MessageBox.Show(
                "TOTAL PAYMENT: ₱" + Total.ToString("N2") +
                "\nCASH: ₱" + numCash.Value.ToString("N2") +
                "\nCHANGE: ₱" + change.ToString("N2") +
                "\n\nConfirm this order?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation == DialogResult.No)
            {
                return;
            }

            try
            {
                int saleID;
                // Save all cart items as one complete transaction.
                using (TransactionScope transaction = new TransactionScope())
                {
                    saleID = db.Adlaw_CreateSaleHeader();
                    foreach (CartItem item in cart)
                    {
                        if (db.Adlaw_AddSaleItem(saleID, item.ProductID, item.Quantity) == 0)
                        {
                            throw new InvalidOperationException(item.ItemName + " has insufficient stock.");
                        }
                    }

                    transaction.Complete();
                }

                decimal paid = numCash.Value;
                string receipt = BuildReceipt(saleID, paid);
                cart.Clear();
                numCash.Value = 0;
                UpdateTotals();
                LoadMenu();

                using (ReceiptForm form = new ReceiptForm(receipt))
                {
                    form.ShowDialog(this);
                }
            }
            catch (SqlException ex)
            {
                Warn(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Warn(ex.Message);
                LoadMenu();
            }
        }

        private string BuildReceipt(int saleID, decimal paid)
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("             ADLAW");
            text.AppendLine("          OFFICIAL RECEIPT");
            text.AppendLine("--------------------------------");
            text.AppendLine("Receipt #: " + saleID);
            text.AppendLine("Date: " + DateTime.Now.ToString("MMM dd, yyyy h:mm tt"));
            text.AppendLine("--------------------------------");
            foreach (CartItem item in cart)
            {
                text.AppendLine(item.ItemName + "\n  " + item.Quantity + " x ₱" +
                    item.UnitPrice.ToString("N2") + " = ₱" + item.Subtotal.ToString("N2"));
            }

            text.AppendLine("--------------------------------");
            text.AppendLine("TOTAL:  ₱" + Total.ToString("N2"));
            text.AppendLine("CASH:   ₱" + paid.ToString("N2"));
            text.AppendLine("CHANGE: ₱" + (paid - Total).ToString("N2"));
            text.AppendLine("--------------------------------");
            text.AppendLine("       Thank you!");
            return text.ToString();
        }

        private static void Warn(string message)
        {
            MessageBox.Show(message, "Adlaw POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
