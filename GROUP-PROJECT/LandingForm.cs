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
            login.FormClosed += LoginClosed;
            login.Show();
            this.Hide();
        }

        private void LoginClosed(object sender, FormClosedEventArgs e)
        {
            // Show the landing page after the login closes.
            this.Show();
        }
    }
}
