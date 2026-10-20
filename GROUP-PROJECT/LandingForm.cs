using System;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class LandingForm : Form
    {
        public LandingForm() { InitializeComponent(); }

        private void OrderNow(object sender, EventArgs e)
        {
            // Open the customer ordering screen.
            using (CustomerOrderForm order = new CustomerOrderForm())
                order.ShowDialog(this);
        }

        private void AdminLogin(object sender, EventArgs e)
        {
            // Open the administrator login screen.
            LoginForm login = new LoginForm();
            login.FormClosed += delegate { this.Show(); };
            login.Show();
            this.Hide();
        }
    }
}
