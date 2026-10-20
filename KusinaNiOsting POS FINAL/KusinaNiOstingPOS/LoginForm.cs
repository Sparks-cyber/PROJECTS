using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniMartPOS
{
    // LAB ACTIVITY 1 - POS (AUTHENTICATION)
    public partial class Form1 : Form
    {
        // ONE DATABASE CONTEXT FOR THIS FORM.
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        public Form1()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            AcceptButton = btnLogin;
            ApplyModernStyling();
        }

        private void ApplyModernStyling()
        {
            Image foodPhoto = UiStyle.LoadAsset("Images/login_food_photo.png");
            if (foodPhoto != null)
            {
                Image previous = panelBrand.BackgroundImage;
                panelBrand.BackgroundImage = foodPhoto;
                // Fill the photo panel.
                panelBrand.BackgroundImageLayout = ImageLayout.Stretch;
                if (previous != null && previous != Properties.Resources.login_brand_panel) previous.Dispose();
            }
            UiStyle.RoundControl(panelLoginCard, 22);
            UiStyle.RoundControl(panelUsernameInput, 11);
            UiStyle.RoundControl(panelPasswordInput, 11);
            UiStyle.RoundControl(btnLogin, 12);
            UiStyle.AddHover(btnLogin, Color.FromArgb(234, 88, 12), Color.FromArgb(249, 115, 22));
            UiStyle.AddBorder(panelUsernameInput, Color.FromArgb(203, 213, 225));
            UiStyle.AddBorder(panelPasswordInput, Color.FromArgb(203, 213, 225));
            UiStyle.SetCueBanner(txtUsername, "Enter your username");
            UiStyle.SetCueBanner(txtPassword, "Enter your password");
            UiStyle.PolishForm(this);
        }

        // EVENT: panelBrand_Paint - runs when the user interacts with this control.

        private void panelBrand_Paint(object sender, PaintEventArgs e)
        {
            // Darken the caption area.
            int fadeTop = (int)(panelBrand.ClientSize.Height * .50f);
            Rectangle fadeArea = new Rectangle(0, fadeTop, panelBrand.ClientSize.Width,
                panelBrand.ClientSize.Height - fadeTop);
            using (LinearGradientBrush fade = new LinearGradientBrush(fadeArea,
                Color.FromArgb(0, 7, 4, 2), Color.FromArgb(220, 7, 4, 2), 90f))
                e.Graphics.FillRectangle(fade, fadeArea);

            // Blend the photo edge.
            using (LinearGradientBrush edgeFade = new LinearGradientBrush(panelBrand.ClientRectangle,
                Color.FromArgb(22, 5, 3, 2), Color.FromArgb(72, 5, 3, 2), 0f))
                e.Graphics.FillRectangle(edgeFade, panelBrand.ClientRectangle);
        }

        // EVENT: Form1_Load - runs when the user interacts with this control.

        private void Form1_Load(object sender, EventArgs e)
        {
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
            if (panelLoginCard == null || panelBrand == null) return;
            int availableWidth = ClientSize.Width - panelBrand.Width;
            panelLoginCard.Left = panelBrand.Width + Math.Max(20, (availableWidth - panelLoginCard.Width) / 2);
            panelLoginCard.Top = Math.Max(20, (ClientSize.Height - panelLoginCard.Height) / 2);
        }

        // EVENT: chkShowPassword_CheckedChanged - runs when the user interacts with this control.

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                UiDialogs.Warning(this, "Missing Information", "Please enter your username and password.");
                return;
            }

            LoginRow user;
            string passwordHash = PasswordHelper.Hash(password);

            { // Shared form DataContext

                user = db.LoginUserSimple(username, passwordHash);
            }
            if (user != null && user.Role == AppConstants.AdminRole)
            {
                Session.CurrentUserID = user.UserID;
                Session.CurrentUserName = user.FullName;
                Session.CurrentRole = user.Role;
                OpenDashboard(user.FullName);
            }
            else
            {
                UiDialogs.Error(this, "Login Failed", "Incorrect username or password.");
                txtPassword.Clear();
                txtPassword.Focus();
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
            if (!chkRemember.Checked) txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        // RELEASE THE DATABASE CONTEXT WHEN THE FORM CLOSES.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
