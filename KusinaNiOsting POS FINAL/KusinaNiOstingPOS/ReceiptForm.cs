using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class ReceiptForm : Form
    {
        private readonly Sale sale;
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        public ReceiptForm() : this(null) { }
        public ReceiptForm(Sale completedSale)
        {
            sale = completedSale;
            InitializeComponent();
            UiStyle.RoundControl(panelReceipt, 14);
            UiStyle.AddBorder(panelReceipt, Color.FromArgb(73, 56, 46));
            UiStyle.RoundControl(btnDone, 9);
            LoadReceipt();
        }

        private void LoadReceipt()
        {
            StoreSetting settings = DatabaseData.Settings;
            lblStore.Text = settings == null || string.IsNullOrWhiteSpace(settings.StoreName) ? AppConstants.DefaultStoreName : settings.StoreName;
            lblTransaction.Text = sale.TransactionNo + "  •  " + sale.SaleDate.ToString("MMM d, yyyy  h:mm tt");
            dgvItems.Rows.Clear();
            foreach (SaleItemRow line in db.GetSaleItems(sale.SaleID))
                dgvItems.Rows.Add(line.ItemName, line.Quantity, "₱" + line.UnitPrice.ToString("N2"), "₱" + line.Subtotal.ToString("N2"));
            dgvItems.ClearSelection();
            lblPayment.Text = "Payment method: " + sale.PaymentMethod;
            lblTotalValue.Text = "₱" + sale.TotalAmount.ToString("N2");
            lblReceivedValue.Text = "₱" + sale.CashReceived.ToString("N2");
            lblChangeValue.Text = "₱" + sale.ChangeAmount.ToString("N2");
            lblReceived.Visible = sale.PaymentMethod == AppConstants.PaymentCash;
            lblChange.Visible = sale.PaymentMethod == AppConstants.PaymentCash;
            lblReceivedValue.Visible = sale.PaymentMethod == AppConstants.PaymentCash;
            lblChangeValue.Visible = sale.PaymentMethod == AppConstants.PaymentCash;
            lblFooter.Text = settings == null || string.IsNullOrWhiteSpace(settings.ReceiptFooter) ? AppConstants.DefaultReceiptFooter : settings.ReceiptFooter;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
