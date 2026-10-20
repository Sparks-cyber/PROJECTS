namespace MiniMartPOS
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.lblProfileStatus = new System.Windows.Forms.Label();
            this.lblProfileRole = new System.Windows.Forms.Label();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblHeaderUser = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.panelSidebar.SuspendLayout();
            this.panelProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(39, 24, 18);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.panelProfile);
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnCustomers);
            this.panelSidebar.Controls.Add(this.btnTransactions);
            this.panelSidebar.Controls.Add(this.btnInventory);
            this.panelSidebar.Controls.Add(this.btnProducts);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.picLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 760);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(76, 44, 30);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(18, 699);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(184, 42);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "↪  Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelProfile
            // 
            this.panelProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelProfile.BackColor = System.Drawing.Color.FromArgb(70, 39, 27);
            this.panelProfile.Controls.Add(this.lblProfileStatus);
            this.panelProfile.Controls.Add(this.lblProfileRole);
            this.panelProfile.Controls.Add(this.lblProfileName);
            this.panelProfile.Controls.Add(this.lblAvatar);
            this.panelProfile.Location = new System.Drawing.Point(18, 607);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(184, 78);
            this.panelProfile.TabIndex = 9;
            // 
            // lblProfileStatus
            // 
            this.lblProfileStatus.AutoSize = true;
            this.lblProfileStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblProfileStatus.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            this.lblProfileStatus.Location = new System.Drawing.Point(57, 52);
            this.lblProfileStatus.Name = "lblProfileStatus";
            this.lblProfileStatus.Size = new System.Drawing.Size(53, 13);
            this.lblProfileStatus.TabIndex = 3;
            this.lblProfileStatus.Text = "● Online";
            // 
            // lblProfileRole
            // 
            this.lblProfileRole.AutoSize = true;
            this.lblProfileRole.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProfileRole.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblProfileRole.Location = new System.Drawing.Point(57, 35);
            this.lblProfileRole.Name = "lblProfileRole";
            this.lblProfileRole.Size = new System.Drawing.Size(79, 15);
            this.lblProfileRole.TabIndex = 2;
            this.lblProfileRole.Text = "Administrator";
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.ForeColor = System.Drawing.Color.White;
            this.lblProfileName.Location = new System.Drawing.Point(57, 16);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(48, 17);
            this.lblProfileName.TabIndex = 1;
            this.lblProfileName.Text = "Admin";
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(13, 18);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(34, 34);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "A";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(18, 418);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(184, 43);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "⚙   Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(18, 367);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(184, 43);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "↗   Sales Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(18, 316);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCustomers.Size = new System.Drawing.Size(184, 43);
            this.btnCustomers.TabIndex = 6;
            this.btnCustomers.Text = "◉   Suppliers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Location = new System.Drawing.Point(18, 265);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(184, 43);
            this.btnTransactions.TabIndex = 5;
            this.btnTransactions.Text = "≡   Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(18, 214);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(184, 43);
            this.btnInventory.TabIndex = 4;
            this.btnInventory.Text = "▤   Inventory";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(18, 163);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(184, 43);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "▣   Menu Items";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Location = new System.Drawing.Point(18, 112);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(184, 43);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "⌂   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(39, 24, 18);
            this.picLogo.Image = global::MiniMartPOS.Properties.Resources.brand_logo;
            this.picLogo.Location = new System.Drawing.Point(18, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(184, 70);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(28, 22, 19);
            this.panelHeader.Controls.Add(this.lblDateTime);
            this.panelHeader.Controls.Add(this.lblHeaderUser);
            this.panelHeader.Controls.Add(this.lblPageSubtitle);
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1060, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblDateTime.Location = new System.Drawing.Point(805, 25);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(225, 20);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "August 19, 2026 | 12:00 AM";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeaderUser
            // 
            this.lblHeaderUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderUser.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderUser.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderUser.Location = new System.Drawing.Point(800, 48);
            this.lblHeaderUser.Name = "lblHeaderUser";
            this.lblHeaderUser.Size = new System.Drawing.Size(230, 18);
            this.lblHeaderUser.TabIndex = 2;
            this.lblHeaderUser.Text = "Welcome, Admin";
            this.lblHeaderUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblPageSubtitle.Location = new System.Drawing.Point(28, 47);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(208, 15);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Overview of today’s sales and kitchen activity";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(24, 12);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(147, 36);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Dashboard";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(28, 22, 19);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(18);
            this.panelContent.Size = new System.Drawing.Size(1060, 680);
            this.panelContent.TabIndex = 2;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(28, 22, 19);
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1296, 799);
            this.MinimumSize = new System.Drawing.Size(1296, 799);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kusina ni Osting POS - Dashboard";
            this.panelSidebar.ResumeLayout(false);
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblProfileStatus;
        private System.Windows.Forms.Label lblProfileRole;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblHeaderUser;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Timer timerClock;
    }
}
