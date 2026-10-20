using System;
using System.ComponentModel;
using System.Data.SqlClient;
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
            if (string.IsNullOrWhiteSpace(search))
                gridMenu.DataSource = db.Adlaw_RetrieveProducts().ToList();
            else
                gridMenu.DataSource = db.Adlaw_SearchProducts(search).ToList();
            HideMenuColumns();
        }

        private void HideMenuColumns()
        {
            string[] hidden = { "ProductID", "CategoryID", "ImagePath", "IsDeleted" };
            foreach (string name in hidden)
            {
                if (gridMenu.Columns[name] != null)
                {
                    gridMenu.Columns[name].Visible = false;
                }
            }

            if (gridMenu.Columns["ItemCode"] != null)
            {
                gridMenu.Columns["ItemCode"].HeaderText = "CODE";
            }

            if (gridMenu.Columns["ItemName"] != null)
            {
                gridMenu.Columns["ItemName"].HeaderText = "MENU ITEM";
            }

            if (gridMenu.Columns["Price"] != null)
            {
                gridMenu.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
            }

            gridMenu.ClearSelection();
        }

        private void SetupCartColumns()
        {
            if (gridCart.Columns["ProductID"] != null)
            {
                gridCart.Columns["ProductID"].Visible = false;
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
                product = gridMenu.CurrentRow.DataBoundItem as ProductResult;
            }

            int quantity = (int)numQuantity.Value;
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
                    ItemName = product.ItemName, UnitPrice = product.Price, Quantity = quantity });
            }
            else
            {
                existing.Quantity = newQuantity;
            }

            gridCart.Refresh();
            UpdateTotals();
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
                numQuantity.Value = 1;
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
