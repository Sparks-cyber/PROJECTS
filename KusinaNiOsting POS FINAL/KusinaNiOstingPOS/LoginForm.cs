using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class LoginForm : Form
    {
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        public LoginForm()
        {
            InitializeComponent();
            db.CommandTimeout = 10;

            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            AcceptButton = btnLogin;
            DesignLoginForm();
        }

        private void panelBrand_Paint(object sender, PaintEventArgs e)
        {
            int fadeTop = (int)(panelBrand.ClientSize.Height * .50f);
            Rectangle fadeArea = new Rectangle(0, fadeTop, panelBrand.ClientSize.Width,
                panelBrand.ClientSize.Height - fadeTop);
            using (LinearGradientBrush fade = new LinearGradientBrush(fadeArea,
                Color.FromArgb(0, 7, 4, 2), Color.FromArgb(220, 7, 4, 2), 90f))
                e.Graphics.FillRectangle(fade, fadeArea);

            using (LinearGradientBrush edgeFade = new LinearGradientBrush(panelBrand.ClientRectangle,
                Color.FromArgb(22, 5, 3, 2), Color.FromArgb(72, 5, 3, 2), 0f))
                e.Graphics.FillRectangle(edgeFade, panelBrand.ClientRectangle);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Center the login controls when the form opens.
            CenterLoginCard();
            txtUsername.Focus();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLoginCard();
        }

        private void CenterLoginCard()
        {
            if (panelLoginCard == null || panelBrand == null)
                return;

            int availableWidth = ClientSize.Width - panelBrand.Width;
            panelLoginCard.Left = panelBrand.Width + Math.Max(20, (availableWidth - panelLoginCard.Width) / 2);
            panelLoginCard.Top = Math.Max(20, (ClientSize.Height - panelLoginCard.Height) / 2);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Show or hide the entered password.
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate the administrator login.
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                UiDialogs.Warning(this, "Missing Information", "Please enter your username and password.");
                return;
            }

            btnLogin.Enabled = false;

            try
            {
                string passwordHash = PasswordHelper.Hash(password);
                LoginUserResult user = db.LoginUser(username, passwordHash).FirstOrDefault();

                if (user == null)
                {
                    UiDialogs.Error(this, "Login Failed", "Incorrect username or password.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                if (user.Role != AppConstants.AdminRole)
                {
                    UiDialogs.Error(this, "Access Denied", "This account is not an administrator.");
                    return;
                }

                Session.CurrentUserID = user.UserID;
                Session.CurrentUserName = user.FullName;
                Session.CurrentRole = user.Role;
                OpenDashboard(user.FullName);
            }
            catch (Exception ex)
            {
                UiDialogs.Error(this, "Login Error", ex.Message);
            }
            finally
            {
                if (!IsDisposed)
                    btnLogin.Enabled = true;
            }
        }

        private void OpenDashboard(string displayName)
        {
            Hide();
            using (DashboardForm dashboard = new DashboardForm(displayName))
            {
                dashboard.ShowDialog();
            }
            Session.Clear();
            Show();
            if (!chkRemember.Checked)
                txtUsername.Clear();

            txtPassword.Clear();
            txtUsername.Focus();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the database connection when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void DesignLoginForm()
        {
            Image foodPhoto = UiStyle.LoadAsset("Images/login_food_photo.png");

            if (foodPhoto != null)
            {
                Image oldImage = panelBrand.BackgroundImage;
                panelBrand.BackgroundImage = foodPhoto;
                panelBrand.BackgroundImageLayout = ImageLayout.Stretch;

                if (oldImage != null && oldImage != Properties.Resources.login_brand_panel)
                    oldImage.Dispose();
            }

            UiStyle.RoundControl(panelLoginCard, 22);
            UiStyle.RoundControl(panelUsernameInput, 11);
            UiStyle.RoundControl(panelPasswordInput, 11);
            UiStyle.RoundControl(btnLogin, 12);
            UiStyle.AddHover(btnLogin, Color.FromArgb(234, 88, 12),
                Color.FromArgb(249, 115, 22));
            UiStyle.AddBorder(panelUsernameInput, Color.FromArgb(203, 213, 225));
            UiStyle.AddBorder(panelPasswordInput, Color.FromArgb(203, 213, 225));
            UiStyle.SetCueBanner(txtUsername, "Enter your username");
            UiStyle.SetCueBanner(txtPassword, "Enter your password");
            UiStyle.PolishForm(this);
        }
    }
}
