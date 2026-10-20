using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();
            DesignLandingForm();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // Open the customer ordering page.
            ShowLoading("Preparing the menu...");
            Hide();

            using (CustomerOrderForm order = new CustomerOrderForm())
            {
                order.ShowDialog();
            }

            Show();
            loading.Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // Open the administrator login page.
            ShowLoading("Opening secure admin login...");
            Hide();

            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }

            Show();
            loading.Visible = false;
        }

        private void ShowLoading(string message)
        {
            loading.Text = message;
            loading.Visible = true;
            loading.BringToFront();
            loading.Refresh();
        }

        private void hero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (hero.BackgroundImage != null)
            {
                UiStyle.DrawImageCover(e.Graphics, hero.BackgroundImage, hero.ClientRectangle);
            }

            using (LinearGradientBrush shade = new LinearGradientBrush(
                hero.ClientRectangle, Color.FromArgb(205, 12, 9, 8),
                Color.FromArgb(75, 30, 18, 12), 0f))
            {
                e.Graphics.FillRectangle(shade, hero.ClientRectangle);
            }
        }

        private void DesignLandingForm()
        {
            UiStyle.RoundControl(card, 24);
            UiStyle.RoundControl(btnOrder, 12);
            UiStyle.RoundControl(btnAdmin, 10);
            UiStyle.AddHover(btnOrder, Color.FromArgb(234, 88, 12),
                Color.FromArgb(249, 115, 22));
            UiStyle.AddHover(btnAdmin, Color.FromArgb(48, 38, 32),
                Color.FromArgb(70, 53, 43));
            UiStyle.AddBorder(card, Color.FromArgb(93, 69, 55));
        }
    }
}
