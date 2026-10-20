using System;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class TransactionDetailsForm : Form
    {
        private readonly int saleID;

        public TransactionDetailsForm() : this(0) { }

        public TransactionDetailsForm(int id)
        {
            saleID = id;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Sale sale = DatabaseData.Sales.First(x => x.SaleID == saleID);
            User user = DatabaseData.Users.First(x => x.UserID == sale.UserID);

            lblTransaction.Text = sale.TransactionNo;
            lblInfo.Text = sale.SaleDate.ToString("MMM d, yyyy h:mm tt") +
                "   |   " + sale.PaymentMethod + "   |   " + user.FullName;
            lblTotal.Text = "Total: ₱" + sale.TotalAmount.ToString("N2") +
                "   Cash: ₱" + sale.CashReceived.ToString("N2") +
                "   Change: ₱" + sale.ChangeAmount.ToString("N2");

            var items = from saleItem in DatabaseData.SaleItems
                        join menuItem in DatabaseData.MenuItems
                            on saleItem.MenuItemID equals menuItem.MenuItemID
                        where saleItem.SaleID == saleID
                        select new
                        {
                            menuItem.ItemName,
                            saleItem.Quantity,
                            saleItem.UnitPrice,
                            saleItem.Subtotal
                        };

            foreach (var item in items)
            {
                dgvItems.Rows.Add(item.ItemName, item.Quantity,
                    "₱" + item.UnitPrice.ToString("N2"),
                    "₱" + item.Subtotal.ToString("N2"));
            }
        }
    }
}
