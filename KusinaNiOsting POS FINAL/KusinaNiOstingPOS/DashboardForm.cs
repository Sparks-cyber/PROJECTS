using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class DashboardForm : Form
    {
        private Form currentChildForm;
        private readonly string displayName;
        private readonly Color navNormal = Color.FromArgb(39, 24, 18);
        private readonly Color navActive = Color.FromArgb(234, 88, 12);
        private bool isNavigating;
        private Panel loadingOverlay;

        public DashboardForm() : this(AppConstants.DefaultAdminName) { }

        public DashboardForm(string displayName)
        {
            this.displayName = string.IsNullOrWhiteSpace(displayName) ?
                AppConstants.DefaultAdminName : displayName;
            InitializeComponent();
            UiStyle.PolishForm(this);
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            DoubleBuffered = true;
            // KEEP ALL SIDEBAR BUTTONS VISIBLE.
            ConfigureNavigation();
            ConfigureRoundedStyling();
            UpdateUserLabels();
            UpdateDateTime();
            CreateLoadingOverlay();
            OpenPage(new HomeForm(), btnDashboard, "Dashboard", "Overview of today’s sales and kitchen activity");
        }

        private void CreateLoadingOverlay()
        {
            loadingOverlay = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(28, 22, 19), Visible = false };
            Label message = new Label
            {
                Dock = DockStyle.Fill, Text = "Loading page…", TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(251, 146, 60), Font = new Font("Segoe UI", 12f, FontStyle.Bold)
            };
            loadingOverlay.Controls.Add(message);
            panelContent.Controls.Add(loadingOverlay);
        }

        private async void Navigate(Func<Form> pageFactory, Button activeButton, string title, string subtitle)
        {
            if (isNavigating) return;
            isNavigating = true;
            try
            {
                loadingOverlay.Visible = true; loadingOverlay.BringToFront();
                await Task.Delay(90);
                if (IsDisposed || Disposing) return;
                Form childForm = pageFactory();
                OpenPage(childForm, activeButton, title, subtitle);
                loadingOverlay.BringToFront();
                await Task.Delay(60);
            }
            catch (Exception ex)
            {
                if (!IsDisposed) UiDialogs.Error(this, "Navigation", "The page could not be opened.\n\n" + ex.Message);
            }
            finally
            {
                if (!IsDisposed && loadingOverlay != null) loadingOverlay.Visible = false;
                isNavigating = false;
            }
        }

        private void ConfigureNavigation()
        {
            Button[] buttons =
            {
                btnDashboard, btnProducts, btnInventory,
                btnTransactions, btnCustomers, btnReports, btnSettings
            };

            foreach (Button button in buttons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(92, 51, 30);
                button.UseVisualStyleBackColor = false;
                button.BackColor = navNormal;
                button.ForeColor = Color.FromArgb(226, 232, 240);
                button.Cursor = Cursors.Hand;
            }
        }

        private void ConfigureRoundedStyling()
        {
            UiStyle.RoundControl(panelProfile, 12);
            UiStyle.AddBorder(panelProfile, Color.FromArgb(120, 67, 38));
            UiStyle.RoundControl(btnLogout, 10);
            UiStyle.AddHover(btnLogout, Color.FromArgb(76, 44, 30), Color.FromArgb(101, 60, 37));
            UiStyle.RoundControl(lblAvatar, 17);

            Button[] buttons =
            {
                btnDashboard, btnProducts, btnInventory,
                btnTransactions, btnCustomers, btnReports, btnSettings
            };
            foreach (Button button in buttons)
                UiStyle.RoundControl(button, 10);
        }

        private void UpdateUserLabels()
        {
            lblProfileName.Text = displayName;
            lblHeaderUser.Text = "Welcome, " + displayName;
            lblProfileRole.Text = "Administrator";
            lblAvatar.Text = displayName.Substring(0, 1).ToUpper();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = DateTime.Now.ToString("MMMM d, yyyy | h:mm:ss tt");
        }

        // EVENT: timerClock_Tick - runs when the user interacts with this control.

        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void SetActiveNav(Button active)
        {
            Button[] buttons =
            {
                btnDashboard, btnProducts, btnInventory,
                btnTransactions, btnCustomers, btnReports, btnSettings
            };

            foreach (Button button in buttons)
            {
                bool isActive = button == active;
                button.BackColor = isActive ? navActive : navNormal;
                button.Font = new Font("Segoe UI", 9.5F, isActive ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void OpenPage(Form childForm, Button activeButton, string title, string subtitle)
        {
            if (currentChildForm != null)
            {
                panelContent.Controls.Remove(currentChildForm);
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            UiStyle.PrepareEmbeddedPage(childForm);

            panelContent.SuspendLayout();
            panelContent.Controls.Add(childForm);
            childForm.Show();
            childForm.BringToFront();

            lblPageTitle.Text = title;
            lblPageSubtitle.Text = subtitle;
            SetActiveNav(activeButton);
            panelContent.ResumeLayout(true);
        }

        // EVENT: btnDashboard_Click - runs when the user interacts with this control.

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Navigate(() => new HomeForm(), btnDashboard, "Dashboard", "Overview of today’s sales and kitchen activity");
        }

        // EVENT: btnProducts_Click - runs when the user interacts with this control.

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Navigate(() => new ProductsForm(), btnProducts, "Menu Items", "Manage menu items and selling prices");
        }

        // EVENT: btnInventory_Click - runs when the user interacts with this control.

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Navigate(() => new InventoryForm(), btnInventory, "Inventory", "Monitor food and supply stock levels");
        }

        // EVENT: btnTransactions_Click - runs when the user interacts with this control.

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            Navigate(() => new TransactionsForm(), btnTransactions, "Transactions", "Review recent sales transactions");
        }

        // EVENT: btnCustomers_Click - runs when the user interacts with this control.

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Navigate(() => new CustomersForm(), btnCustomers,
                "Suppliers", "Manage supplier information and delivery records");
        }

        // EVENT: btnReports_Click - runs when the user interacts with this control.

        private void btnReports_Click(object sender, EventArgs e)
        {
            Navigate(() => new ReportsForm(), btnReports,
                "Sales Reports", "Review sales totals and top-selling menu items");
        }

        // EVENT: btnSettings_Click - runs when the user interacts with this control.

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Navigate(() => new SettingsForm(), btnSettings,
                "Settings", "Update store and receipt preferences");
        }

        // EVENT: btnLogout_Click - runs when the user interacts with this control.

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (UiDialogs.Confirm(this, "Log Out", "End the current admin session and return to the login page?","LOG OUT"))
            {
                Close();
            }
        }
    }
}
