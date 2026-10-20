using System;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class PaymentForm : Form
    {
        private decimal orderTotal;

        public decimal AmountPaid { get; private set; }
        public string PaymentMethod { get; private set; }

        public PaymentForm()
        {
            InitializeComponent();
        }

        public PaymentForm(decimal total)
            : this()
        {
            orderTotal = total;
            lblTotalValue.Text = "₱" + total.ToString("N2");
            cboPaymentMethod.SelectedIndex = 0;
            UpdatePaymentDetails();
        }

        private void PaymentMethodChanged(object sender, EventArgs e)
        {
            // Update the amount field for the selected payment method.
            UpdatePaymentDetails();
        }

        private void AmountChanged(object sender, EventArgs e)
        {
            // Recalculate the customer's change.
            UpdateChange();
        }

        private void UpdatePaymentDetails()
        {
            if (cboPaymentMethod.Text == "GCash")
            {
                lblAmount.Text = "AMOUNT PAID";
                numAmount.Value = orderTotal;
                numAmount.Enabled = false;
            }
            else
            {
                lblAmount.Text = "CASH PAYMENT";
                numAmount.Enabled = true;
            }

            UpdateChange();
        }

        private void UpdateChange()
        {
            decimal change = numAmount.Value - orderTotal;
            if (change < 0)
            {
                change = 0;
            }

            lblChangeValue.Text = "₱" + change.ToString("N2");
        }

        private void CompletePayment(object sender, EventArgs e)
        {
            // Validate and confirm the customer payment.
            if (numAmount.Value < orderTotal)
            {
                MessageBox.Show("Payment is not enough.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AmountPaid = numAmount.Value;
            PaymentMethod = cboPaymentMethod.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelPayment(object sender, EventArgs e)
        {
            // Return to the customer cart without paying.
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
