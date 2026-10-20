using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class LoginForm : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();

        public AuthenticationResult LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            db.CommandTimeout = 10;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the global database context when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // Show the entered password.
            if (txtPassword.PasswordChar == '•')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            // Hide the entered password.
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '•';
            }
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            // Validate the administrator login.
            string username = textBox1.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnlogin.Enabled = false;

            try
            {
                string passwordHash = PasswordSecurity.GetHashSha256(password);

                AuthenticationResult user = await Task.Run(() =>
                {
                    return db.Adlaw_Authenticate(username, passwordHash)
                        .FirstOrDefault();
                });

                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.", "Adlaw POS",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (user.Role != "Admin")
                {
                    MessageBox.Show("This account does not have administrator access.",
                        "Adlaw POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoggedInUser = user;
                Products products = new Products();
                // Close the login after the admin dashboard closes.
                products.FormClosed += Products_FormClosed;
                products.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                    btnlogin.Enabled = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Submit the login when Enter is pressed.
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnlogin.PerformClick();
            }
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Close the login after the dashboard closes.
            txtPassword.Clear();
            this.Close();
        }
    }
}
