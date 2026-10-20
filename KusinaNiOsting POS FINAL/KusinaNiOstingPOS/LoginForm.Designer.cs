namespace MiniMartPOS
{
    partial class Form1
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
            this.panelBrand = new System.Windows.Forms.Panel();
            this.picLoginLogo = new System.Windows.Forms.PictureBox();
            this.lblBrandHeadline = new System.Windows.Forms.Label();
            this.lblBrandCopy = new System.Windows.Forms.Label();
            this.panelLoginCard = new System.Windows.Forms.Panel();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.panelPasswordInput = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panelUsernameInput = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblWelcomeAccent = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginLogo)).BeginInit();
            this.panelLoginCard.SuspendLayout();
            this.panelPasswordInput.SuspendLayout();
            this.panelUsernameInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBrand
            // 
            this.panelBrand.BackColor = System.Drawing.Color.FromArgb(5, 19, 40);
            this.panelBrand.BackgroundImage = global::MiniMartPOS.Properties.Resources.login_food_photo;
            this.panelBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBrand.Controls.Add(this.lblBrandCopy);
            this.panelBrand.Controls.Add(this.lblBrandHeadline);
            this.panelBrand.Controls.Add(this.picLoginLogo);
            this.panelBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBrand.Location = new System.Drawing.Point(0, 0);
            this.panelBrand.Name = "panelBrand";
            this.panelBrand.Size = new System.Drawing.Size(500, 760);
            this.panelBrand.TabIndex = 0;
            this.panelBrand.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBrand_Paint);
            //
            // picLoginLogo
            //
            this.picLoginLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLoginLogo.Image = global::MiniMartPOS.Properties.Resources.brand_logo;
            this.picLoginLogo.Location = new System.Drawing.Point(36, 28);
            this.picLoginLogo.Name = "picLoginLogo";
            this.picLoginLogo.Size = new System.Drawing.Size(330, 124);
            this.picLoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoginLogo.TabIndex = 0;
            this.picLoginLogo.TabStop = false;
            //
            // lblBrandHeadline
            //
            this.lblBrandHeadline.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandHeadline.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBrandHeadline.ForeColor = System.Drawing.Color.White;
            this.lblBrandHeadline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrandHeadline.Location = new System.Drawing.Point(40, 626);
            this.lblBrandHeadline.Name = "lblBrandHeadline";
            this.lblBrandHeadline.Size = new System.Drawing.Size(415, 52);
            this.lblBrandHeadline.TabIndex = 1;
            this.lblBrandHeadline.Text = "Lutong simple. Sarap Osting.";
            //
            // lblBrandCopy
            //
            this.lblBrandCopy.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandCopy.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblBrandCopy.ForeColor = System.Drawing.Color.FromArgb(235, 225, 218);
            this.lblBrandCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrandCopy.Location = new System.Drawing.Point(43, 679);
            this.lblBrandCopy.Name = "lblBrandCopy";
            this.lblBrandCopy.Size = new System.Drawing.Size(400, 50);
            this.lblBrandCopy.TabIndex = 2;
            this.lblBrandCopy.Text = "Secure access for the people who keep the kusina running.";
            // 
            // panelLoginCard
            // 
            this.panelLoginCard.BackColor = System.Drawing.Color.White;
            this.panelLoginCard.Controls.Add(this.lblSecurity);
            this.panelLoginCard.Controls.Add(this.btnLogin);
            this.panelLoginCard.Controls.Add(this.chkShowPassword);
            this.panelLoginCard.Controls.Add(this.chkRemember);
            this.panelLoginCard.Controls.Add(this.panelPasswordInput);
            this.panelLoginCard.Controls.Add(this.panelUsernameInput);
            this.panelLoginCard.Controls.Add(this.lblPassword);
            this.panelLoginCard.Controls.Add(this.lblUsername);
            this.panelLoginCard.Controls.Add(this.lblSubtitle);
            this.panelLoginCard.Controls.Add(this.lblWelcomeAccent);
            this.panelLoginCard.Controls.Add(this.lblWelcome);
            this.panelLoginCard.Location = new System.Drawing.Point(558, 47);
            this.panelLoginCard.Name = "panelLoginCard";
            this.panelLoginCard.Size = new System.Drawing.Size(570, 552);
            this.panelLoginCard.TabIndex = 1;
            // 
            // lblSecurity
            // 
            this.lblSecurity.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSecurity.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSecurity.Location = new System.Drawing.Point(62, 446);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(446, 22);
            this.lblSecurity.TabIndex = 10;
            this.lblSecurity.Text = "🔒  Admin access only";
            this.lblSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
                                                            this.btnLogin.Location = new System.Drawing.Point(62, 378);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(446, 54);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "LOGIN AS ADMIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkShowPassword.Location = new System.Drawing.Point(385, 339);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(123, 19);
            this.chkShowPassword.TabIndex = 3;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.chkRemember.Location = new System.Drawing.Point(63, 338);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(110, 21);
            this.chkRemember.TabIndex = 2;
            this.chkRemember.Text = "Remember me";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // panelPasswordInput
            // 
            this.panelPasswordInput.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelPasswordInput.Controls.Add(this.txtPassword);
            this.panelPasswordInput.Location = new System.Drawing.Point(62, 268);
            this.panelPasswordInput.Name = "panelPasswordInput";
            this.panelPasswordInput.Size = new System.Drawing.Size(446, 54);
            this.panelPasswordInput.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPassword.Location = new System.Drawing.Point(16, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(414, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // panelUsernameInput
            // 
            this.panelUsernameInput.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelUsernameInput.Controls.Add(this.txtUsername);
            this.panelUsernameInput.Location = new System.Drawing.Point(62, 181);
            this.panelUsernameInput.Name = "panelUsernameInput";
            this.panelUsernameInput.Size = new System.Drawing.Size(446, 54);
            this.panelUsernameInput.TabIndex = 7;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUsername.Location = new System.Drawing.Point(16, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(414, 21);
            this.txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPassword.Location = new System.Drawing.Point(60, 243);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUsername.Location = new System.Drawing.Point(60, 156);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(76, 19);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(65, 98);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(440, 28);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Sign in to continue to Kusina ni Osting POS";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeAccent
            // 
            this.lblWelcomeAccent.AutoSize = true;
            this.lblWelcomeAccent.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeAccent.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeAccent.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblWelcomeAccent.Location = new System.Drawing.Point(255, 47);
            this.lblWelcomeAccent.Name = "lblWelcomeAccent";
            this.lblWelcomeAccent.Size = new System.Drawing.Size(110, 46);
            this.lblWelcomeAccent.TabIndex = 1;
            this.lblWelcomeAccent.Text = "Back!";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblWelcome.Location = new System.Drawing.Point(88, 47);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(174, 46);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.panelLoginCard);
            this.Controls.Add(this.panelBrand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1296, 799);
            this.MinimumSize = new System.Drawing.Size(1296, 799);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kusina ni Osting POS - Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBrand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoginLogo)).EndInit();
            this.panelLoginCard.ResumeLayout(false);
            this.panelLoginCard.PerformLayout();
            this.panelPasswordInput.ResumeLayout(false);
            this.panelPasswordInput.PerformLayout();
            this.panelUsernameInput.ResumeLayout(false);
            this.panelUsernameInput.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.Panel panelLoginCard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeAccent;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel panelUsernameInput;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel panelPasswordInput;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.PictureBox picLoginLogo;
        private System.Windows.Forms.Label lblBrandHeadline;
        private System.Windows.Forms.Label lblBrandCopy;
    }
}
