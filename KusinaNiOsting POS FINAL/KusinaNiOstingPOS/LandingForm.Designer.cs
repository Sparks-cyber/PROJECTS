namespace MiniMartPOS
{
    partial class LandingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel hero;
        private System.Windows.Forms.Panel card;
        private System.Windows.Forms.PictureBox picBrandLogo;
        private System.Windows.Forms.Label lblEyebrow;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnAdmin;

        protected override void Dispose(bool disposing)
        {
            if (disposing) { if (heroImage != null) heroImage.Dispose(); if (components != null) components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.hero = new System.Windows.Forms.Panel();
            this.loading = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.card = new System.Windows.Forms.Panel();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEyebrow = new System.Windows.Forms.Label();
            this.picBrandLogo = new System.Windows.Forms.PictureBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.hero.SuspendLayout();
            this.card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // hero
            // 
            this.hero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.hero.BackgroundImage = global::MiniMartPOS.Properties.Resources.landing_food_hero;
            this.hero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hero.Controls.Add(this.loading);
            this.hero.Controls.Add(this.lblLocation);
            this.hero.Controls.Add(this.card);
            this.hero.Controls.Add(this.btnAdmin);
            this.hero.Controls.Add(this.picBrandLogo);
            this.hero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hero.Location = new System.Drawing.Point(0, 0);
            this.hero.Name = "hero";
            this.hero.Size = new System.Drawing.Size(1280, 760);
            this.hero.TabIndex = 0;
            this.hero.Paint += new System.Windows.Forms.PaintEventHandler(this.hero_Paint);
            // 
            // loading
            // 
            this.loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(43)))), ((int)(((byte)(36)))));
            this.loading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.loading.ForeColor = System.Drawing.Color.White;
            this.loading.Location = new System.Drawing.Point(500, 650);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(240, 42);
            this.loading.TabIndex = 3;
            this.loading.Text = "Preparing the menu…";
            this.loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loading.Visible = false;
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.lblLocation.Location = new System.Drawing.Point(94, 632);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(336, 17);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "⚲  F. Ramos St., across Velez Hospital, Cebu City 6000";
            // 
            // card
            // 
            this.card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(24)))), ((int)(((byte)(20)))));
            this.card.Controls.Add(this.lblFeatures);
            this.card.Controls.Add(this.btnOrder);
            this.card.Controls.Add(this.lblDescription);
            this.card.Controls.Add(this.lblTitle);
            this.card.Controls.Add(this.lblEyebrow);
            this.card.Location = new System.Drawing.Point(60, 160);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(590, 430);
            this.card.TabIndex = 2;
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFeatures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(169)))), ((int)(((byte)(159)))));
            this.lblFeatures.Location = new System.Drawing.Point(48, 376);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(309, 17);
            this.lblFeatures.TabIndex = 4;
            this.lblFeatures.Text = "✓ Live menu     ✓ Secure checkout     ✓ Fast service";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.lblDescription.Location = new System.Drawing.Point(48, 210);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(490, 58);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Browse the menu, build your order, and check out in just a few taps.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 31F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(42, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(427, 114);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Comfort food,\r\nready when you are.";
            // 
            // lblEyebrow
            // 
            this.lblEyebrow.AutoSize = true;
            this.lblEyebrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEyebrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblEyebrow.Location = new System.Drawing.Point(48, 42);
            this.lblEyebrow.Name = "lblEyebrow";
            this.lblEyebrow.Size = new System.Drawing.Size(223, 15);
            this.lblEyebrow.TabIndex = 0;
            this.lblEyebrow.Text = "FRESHLY PREPARED • MADE TO ORDER";
            // 
            // picBrandLogo
            // 
            this.picBrandLogo.BackColor = System.Drawing.Color.Transparent;
            this.picBrandLogo.Image = global::MiniMartPOS.Properties.Resources.brand_logo;
            this.picBrandLogo.Location = new System.Drawing.Point(42, 20);
            this.picBrandLogo.Name = "picBrandLogo";
            this.picBrandLogo.Size = new System.Drawing.Size(350, 120);
            this.picBrandLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBrandLogo.TabIndex = 0;
            this.picBrandLogo.TabStop = false;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));

            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(48, 292);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(250, 58);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "ORDER NOW";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(38)))), ((int)(((byte)(32)))));

            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(1070, 26);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(166, 42);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "ADMIN LOGIN";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // LandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.hero);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1296, 799);
            this.MinimumSize = new System.Drawing.Size(1296, 799);
            this.Name = "LandingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kusina ni Osting | Order";
            this.Resize += new System.EventHandler(this.LandingForm_Resize);
            this.hero.ResumeLayout(false);
            this.hero.PerformLayout();
            this.card.ResumeLayout(false);
            this.card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
