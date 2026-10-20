using System;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
        }

        public ReceiptForm(string receipt)
            : this()
        {
            txtReceipt.Text = receipt;
        }

        private void CloseReceipt(object sender, EventArgs e)
        {
            // Close the completed order receipt.
            Close();
        }
    }
}
