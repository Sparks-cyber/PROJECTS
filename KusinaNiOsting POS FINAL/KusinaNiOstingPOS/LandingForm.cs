using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class LandingForm : Form
    {
        private Image heroImage;

        public LandingForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            heroImage = UiStyle.LoadAsset("Images/landing_food_hero.png");
            UiStyle.RoundControl(card, 24);
            UiStyle.RoundControl(btnOrder, 12);
            UiStyle.RoundControl(btnAdmin, 10);
            UiStyle.AddHover(btnOrder, Color.FromArgb(234, 88, 12), Color.FromArgb(249, 115, 22));
            UiStyle.AddHover(btnAdmin, Color.FromArgb(48, 38, 32), Color.FromArgb(70, 53, 43));
            UiStyle.AddBorder(card, Color.FromArgb(93, 69, 55));
            PositionCard();
        }

        // EVENT: LandingForm_Resize - runs when the user interacts with this control.

        private void LandingForm_Resize(object sender, EventArgs e) { PositionCard(); hero.Invalidate(); }

        private void PositionCard()
        {
            card.Location = new Point(Math.Max(48, (ClientSize.Width - 1120) / 2), Math.Max(105, (ClientSize.Height - card.Height) / 2 + 15));
        }

        // EVENT: hero_Paint - runs when the user interacts with this control.

        private void hero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (heroImage != null) UiStyle.DrawImageCover(e.Graphics, heroImage, hero.ClientRectangle);
            else if (hero.BackgroundImage == null) using (LinearGradientBrush bg = new LinearGradientBrush(hero.ClientRectangle, Color.FromArgb(18, 13, 11), Color.FromArgb(76, 35, 18), 25f))
                e.Graphics.FillRectangle(bg, hero.ClientRectangle);
            using (LinearGradientBrush shade = new LinearGradientBrush(hero.ClientRectangle, Color.FromArgb(205, 12, 9, 8), Color.FromArgb(75, 30, 18, 12), 0f))
                e.Graphics.FillRectangle(shade, hero.ClientRectangle);
        }

        // EVENT: btnOrder_Click - runs when the user interacts with this control.

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ShowLoading("Preparing the menu…"); Hide();
            using (CustomerOrderForm order = new CustomerOrderForm()) order.ShowDialog();
            Show(); loading.Visible = false;
        }

        // EVENT: btnAdmin_Click - runs when the user interacts with this control.

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ShowLoading("Opening secure admin login…"); Hide();
            using (Form1 login = new Form1()) login.ShowDialog();
            Show(); loading.Visible = false;
        }

        private void ShowLoading(string message)
        {
            loading.Dock = DockStyle.Fill;
            loading.BackColor = Color.FromArgb(225, 22, 16, 13);
            loading.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            loading.Text = message; loading.Visible = true; loading.BringToFront(); loading.Refresh();
        }
    }
}
