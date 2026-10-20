namespace GROUP_PROJECT
{
    partial class LandingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Label lblSmallBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Label lblActionTitle;
        private System.Windows.Forms.Label lblActionText;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblSmallBrand = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.lblDivider = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lblActionText = new System.Windows.Forms.Label();
            this.lblActionTitle = new System.Windows.Forms.Label();
            this.pnlWelcome.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlWelcome
            //
            this.pnlWelcome.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.pnlWelcome.Controls.Add(this.lblStatus);
            this.pnlWelcome.Controls.Add(this.lblDescription);
            this.pnlWelcome.Controls.Add(this.lblTagline);
            this.pnlWelcome.Controls.Add(this.lblBrand);
            this.pnlWelcome.Controls.Add(this.lblSmallBrand);
            this.pnlWelcome.Location = new System.Drawing.Point(55, 55);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(480, 510);
            this.pnlWelcome.TabIndex = 0;
            //
            // lblStatus
            //
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(76, 105, 87);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(42, 406);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(210, 34);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "●  READY TO SERVE";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDescription
            //
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDescription.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDescription.Location = new System.Drawing.Point(43, 283);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(370, 76);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Fresh coffee, matcha, and refreshing drinks made for every kind of day.";
            //
            // lblTagline
            //
            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(216, 190, 143);
            this.lblTagline.Location = new System.Drawing.Point(42, 226);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(268, 31);
            this.lblTagline.TabIndex = 2;
            this.lblTagline.Text = "Good drinks. Good days.";
            //
            // lblBrand
            //
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(34, 105);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(253, 86);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "ADLAW";
            //
            // lblSmallBrand
            //
            this.lblSmallBrand.AutoSize = true;
            this.lblSmallBrand.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSmallBrand.ForeColor = System.Drawing.Color.Silver;
            this.lblSmallBrand.Location = new System.Drawing.Point(45, 55);
            this.lblSmallBrand.Name = "lblSmallBrand";
            this.lblSmallBrand.Size = new System.Drawing.Size(185, 19);
            this.lblSmallBrand.TabIndex = 0;
            this.lblSmallBrand.Text = "COFFEE  •  MATCHA  •  MORE";
            //
            // pnlActions
            //
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(244, 239, 230);
            this.pnlActions.Controls.Add(this.lblFooter);
            this.pnlActions.Controls.Add(this.btnAdmin);
            this.pnlActions.Controls.Add(this.lblDivider);
            this.pnlActions.Controls.Add(this.btnOrder);
            this.pnlActions.Controls.Add(this.lblActionText);
            this.pnlActions.Controls.Add(this.lblActionTitle);
            this.pnlActions.Location = new System.Drawing.Point(535, 95);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(410, 430);
            this.pnlActions.TabIndex = 1;
            //
            // lblFooter
            //
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(55, 379);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(300, 23);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = "Adlaw Point of Sale  •  Simple and reliable";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnAdmin
            //
            this.btnAdmin.BackColor = System.Drawing.Color.White;
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 69, 59);
            this.btnAdmin.FlatAppearance.BorderSize = 2;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdmin.ForeColor = System.Drawing.Color.FromArgb(52, 69, 59);
            this.btnAdmin.Location = new System.Drawing.Point(55, 302);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(300, 52);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "LOGIN AS ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.AdminLogin);
            //
            // lblDivider
            //
            this.lblDivider.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDivider.ForeColor = System.Drawing.Color.Gray;
            this.lblDivider.Location = new System.Drawing.Point(55, 257);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(300, 22);
            this.lblDivider.TabIndex = 3;
            this.lblDivider.Text = "──────────  OR  ──────────";
            this.lblDivider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnOrder
            //
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(76, 105, 87);
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(55, 184);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(300, 58);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "ORDER NOW  →";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.OrderNow);
            //
            // lblActionText
            //
            this.lblActionText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActionText.ForeColor = System.Drawing.Color.DimGray;
            this.lblActionText.Location = new System.Drawing.Point(55, 105);
            this.lblActionText.Name = "lblActionText";
            this.lblActionText.Size = new System.Drawing.Size(300, 48);
            this.lblActionText.TabIndex = 1;
            this.lblActionText.Text = "Browse the menu, add your favorites, and check out in a few simple steps.";
            this.lblActionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblActionTitle
            //
            this.lblActionTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblActionTitle.ForeColor = System.Drawing.Color.FromArgb(42, 48, 44);
            this.lblActionTitle.Location = new System.Drawing.Point(40, 42);
            this.lblActionTitle.Name = "lblActionTitle";
            this.lblActionTitle.Size = new System.Drawing.Size(330, 48);
            this.lblActionTitle.TabIndex = 0;
            this.lblActionTitle.Text = "Welcome!";
            this.lblActionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // LandingForm
            //
            this.AcceptButton = this.btnOrder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GROUP_PROJECT.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LandingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adlaw POS - Welcome";
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
