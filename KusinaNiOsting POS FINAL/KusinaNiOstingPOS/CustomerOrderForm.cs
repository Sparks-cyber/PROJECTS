using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class CustomerOrderForm : Form
    {
        private OrderForm orderForm;
        private bool closeApproved;

        public CustomerOrderForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            UiStyle.RoundControl(btnBack, 10);
            UiStyle.AddHover(btnBack, btnBack.BackColor, Color.FromArgb(76, 58, 47));
            orderForm = new OrderForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };
            panelContent.Controls.Add(orderForm);
            orderForm.Show();
            FormClosing += CustomerOrderForm_FormClosing;
        }

        // EVENT: btnBack_Click - runs when the user interacts with this control.

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!ConfirmCloseOrder()) return;
            closeApproved = true;
            Close();
        }

        private bool ConfirmCloseOrder()
        {
            return orderForm == null || !orderForm.HasActiveOrder ||
                UiDialogs.Confirm(this, "Close Order", "Discard the current order and return to the landing page?", "DISCARD");
        }

        // EVENT: CustomerOrderForm_FormClosing - runs when the user interacts with this control.

        private void CustomerOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeApproved || e.CloseReason == CloseReason.ApplicationExitCall) return;
            if (!ConfirmCloseOrder()) e.Cancel = true;
            else closeApproved = true;
        }
    }
}
