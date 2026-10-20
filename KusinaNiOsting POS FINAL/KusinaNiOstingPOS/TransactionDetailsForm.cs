using System;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class TransactionDetailsForm : Form
    {
        private readonly int saleID;
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        public TransactionDetailsForm() : this(0) { }

        public TransactionDetailsForm(int id)
        {
            saleID = id;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            SaleDetailsRow sale = db.GetSaleDetails(saleID).FirstOrDefault();
            if (sale == null)
                return;

            lblTransaction.Text = sale.TransactionNo;
            lblInfo.Text = sale.SaleDate.ToString("MMM d, yyyy h:mm tt") +
                "   |   " + sale.PaymentMethod + "   |   " + sale.Cashier;
            lblTotal.Text = "Total: ₱" + sale.TotalAmount.ToString("N2") +
                "   Cash: ₱" + sale.CashReceived.ToString("N2") +
                "   Change: ₱" + sale.ChangeAmount.ToString("N2");

            foreach (SaleItemRow item in db.GetSaleItems(saleID))
            {
                dgvItems.Rows.Add(item.ItemName, item.Quantity,
                    "₱" + item.UnitPrice.ToString("N2"),
                    "₱" + item.Subtotal.ToString("N2"));
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
