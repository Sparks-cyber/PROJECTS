using System;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class LandingForm : Form
    {
        public LandingForm() { InitializeComponent(); }

        private void OrderNow(object sender, EventArgs e)
        {
            using (CustomerOrderForm order = new CustomerOrderForm())
                order.ShowDialog(this);
        }

        private void AdminLogin(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.FormClosed += delegate { this.Show(); };
            login.Show();
            this.Hide();
        }
    }
}
