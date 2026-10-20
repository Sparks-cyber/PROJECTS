using System;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '•')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '•';
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" &&
     txtPassword.Text == "admin123")
            {
                Products products = new Products();

                // Return to this login form when the main form closes.
                products.FormClosed += Products_FormClosed;
                products.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Invalid username or password."
                );
            }
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtPassword.Clear();
            this.Show();
        }
    }
}
