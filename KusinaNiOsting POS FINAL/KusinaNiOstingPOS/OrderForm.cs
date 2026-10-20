using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class OrderForm : Form
    {
        private readonly List<CartLine> cart = new List<CartLine>();

        public bool HasActiveOrder { get { return cart.Count > 0; } }

        public OrderForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
            RefreshCart();
        }

        private void LoadCategories()
        {
            List<CategoryChoice> categories = new List<CategoryChoice>();
            categories.Add(new CategoryChoice(AppConstants.AllCategoriesID, AppConstants.AllCategoriesText));

            foreach (Category category in DatabaseData.Categories.OrderBy(x => x.CategoryName))
                categories.Add(new CategoryChoice(category.CategoryID, category.CategoryName));

            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ID";
            cmbCategory.DataSource = categories;
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            int categoryID = cmbCategory.SelectedValue == null
                ? AppConstants.AllCategoriesID : Convert.ToInt32(cmbCategory.SelectedValue);
            string search = txtSearch.Text.Trim();

            IEnumerable<MenuItem> products = DatabaseData.MenuItems.Where(item =>
                item.IsActive && item.Stock > 0 &&
                (categoryID == AppConstants.AllCategoriesID || item.CategoryID == categoryID) &&
                (search == "" || item.ItemName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 item.ItemCode.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0));

            if (cmbSort.SelectedIndex == AppConstants.SortPriceLowToHigh)
                products = products.OrderBy(item => item.Price);
            else if (cmbSort.SelectedIndex == AppConstants.SortPriceHighToLow)
                products = products.OrderByDescending(item => item.Price);
            else
                products = products.OrderBy(item => item.ItemName);

            foreach (MenuItem product in products)
                dgvProducts.Rows.Add(product.MenuItemID, product.ItemCode, product.ItemName,
                    DatabaseData.CategoryName(product.CategoryID), product.Price.ToString("N2"),
                    product.Stock, "Add");

            dgvProducts.ClearSelection();
        }

        private void ProductFilterChanged(object sender, EventArgs e)
        {
            // Refresh the menu using the selected filter.
            LoadProducts();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add the selected product or increase its quantity.
            if (e.RowIndex < 0 || e.ColumnIndex != colAdd.Index)
                return;

            int productID = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells[colProductID.Index].Value);
            MenuItem product = DatabaseData.MenuItems.FirstOrDefault(item =>
                item.MenuItemID == productID && item.IsActive);

            if (product == null || product.Stock <= 0)
            {
                UiDialogs.Warning(this, "Out of Stock", "This item is currently out of stock.");
                LoadProducts();
                return;
            }

            CartLine line = cart.FirstOrDefault(item => item.MenuItemID == productID);
            if (line == null)
            {
                cart.Add(new CartLine
                {
                    MenuItemID = product.MenuItemID,
                    ItemName = product.ItemName,
                    Price = product.Price,
                    Quantity = 1,
                    AvailableStock = product.Stock
                });
            }
            else if (line.Quantity < product.Stock)
                line.Quantity++;
            else
                UiDialogs.Warning(this, "Stock Limit", "You cannot add more than the available stock.");

            RefreshCart();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Decrease the selected cart quantity.
            if (e.RowIndex < 0 || e.RowIndex >= cart.Count || e.ColumnIndex != colDecrease.Index)
                return;

            cart[e.RowIndex].Quantity--;
            if (cart[e.RowIndex].Quantity == 0)
                cart.RemoveAt(e.RowIndex);
            RefreshCart();
        }

        private void RefreshCart()
        {
            dgvCart.Rows.Clear();
            foreach (CartLine line in cart)
                dgvCart.Rows.Add(line.ItemName, line.Quantity, line.Price.ToString("N2"),
                    line.Total.ToString("N2"), "Remove");

            decimal total = cart.Sum(item => item.Total);
            lblSubtotal.Text = "Subtotal: ₱" + total.ToString("N2");
            lblTax.Text = "Tax: ₱0.00";
            lblTotal.Text = "Total: ₱" + total.ToString("N2");
            dgvCart.ClearSelection();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Validate the cart before opening the payment form.
            if (cart.Count == 0)
            {
                UiDialogs.Warning(this, "Empty Order", "Choose at least one menu item.");
                return;
            }

            decimal total = cart.Sum(item => item.Total);
            using (PaymentForm payment = new PaymentForm(total))
            {
                if (payment.ShowDialog() != DialogResult.OK)
                    return;

                foreach (CartLine line in cart)
                {
                    MenuItem product = DatabaseData.MenuItems.First(item => item.MenuItemID == line.MenuItemID);
                    if (product.Stock < line.Quantity)
                    {
                        UiDialogs.Warning(this, "Stock Updated",
                            product.ItemName + " now has only " + product.Stock + " left.");
                        LoadProducts();
                        return;
                    }
                }
                SaveOrder(payment, total);
            }
        }

        private void SaveOrder(PaymentForm payment, decimal total)
        {
            int userID = Session.CurrentUserID;
            if (userID == 0)
                userID = DatabaseData.Users.First(user => user.IsActive).UserID;

            Sale sale = new Sale
            {
                TransactionNo = AppConstants.TransactionPrefix + DateTime.Now.ToString(AppConstants.TransactionDateFormat),
                SaleDate = DateTime.Now,
                UserID = userID,
                PaymentMethod = payment.PaymentMethod,
                Subtotal = total,
                TotalAmount = total,
                CashReceived = payment.AmountReceived,
                ChangeAmount = payment.ChangeAmount
            };

            List<SaleItem> items = cart.Select(line => new SaleItem
            {
                MenuItemID = line.MenuItemID,
                Quantity = line.Quantity,
                UnitPrice = line.Price,
                Subtotal = line.Total
            }).ToList();

            DatabaseData.SaveSale(sale, items);
            ShowReceipt(sale, payment.ChangeAmount);
            cart.Clear();
            txtSearch.Clear();
            RefreshCart();
            LoadProducts();
        }

        private void ShowReceipt(Sale sale, decimal change)
        {
            if (DatabaseData.Settings == null || DatabaseData.Settings.PrintReceipt)
            {
                using (ReceiptForm receipt = new ReceiptForm(sale))
                    receipt.ShowDialog(this);
            }
            else
            {
                UiDialogs.Info(this, "Order Confirmed",
                    "Payment received successfully.\n\nTransaction: " + sale.TransactionNo +
                    "\nTotal: ₱" + sale.TotalAmount.ToString("N2") +
                    "\nChange: ₱" + change.ToString("N2"));
            }
        }

        private class CategoryChoice
        {
            public int ID { get; private set; }
            public string Name { get; private set; }

            public CategoryChoice(int id, string name)
            {
                ID = id;
                Name = name;
            }
        }
    }
}
