using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class PaymentForm : Form
    {
        private readonly decimal total;
        public string PaymentMethod { get { return cmbMethod.Text; } }
        public decimal AmountReceived { get; private set; }
        public decimal ChangeAmount { get; private set; }

        public PaymentForm() : this(0m) { }
        public PaymentForm(decimal amount)
        {
            total = amount;
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            UiStyle.PolishForm(this);
            UiStyle.RoundControl(btnConfirm, 10); UiStyle.RoundControl(btnCancel, 10);
            lblTotalValue.Text = "₱" + total.ToString("N2");
            cmbMethod.SelectedIndex = 0; numAmount.Value = total; UpdateChange();
            numAmount.ValueChanged += delegate { UpdateChange(); };
            cmbMethod.SelectedIndexChanged += delegate { UpdateMode(); };
        }
        private void UpdateMode(){bool cash=cmbMethod.Text==AppConstants.PaymentCash;lblAmount.Text=cash?"Cash Received":"Amount to Pay";numAmount.Enabled=cash;if(!cash)numAmount.Value=total;UpdateChange();}
        private void UpdateChange(){decimal received=numAmount.Value;decimal change=received-total;lblChangeValue.Text="₱"+(change<0?0:change).ToString("N2");}
        // EVENT: btnConfirm_Click - runs when the user interacts with this control.
        private void btnConfirm_Click(object sender,EventArgs e){decimal received=numAmount.Value;if(cmbMethod.Text==AppConstants.PaymentCash&&received<total){UiDialogs.Warning(this,"Payment","Cash received is not enough.");return;}AmountReceived=cmbMethod.Text==AppConstants.PaymentCash?received:total;ChangeAmount=cmbMethod.Text==AppConstants.PaymentCash?received-total:0;DialogResult=DialogResult.OK;Close();}
    }
}
