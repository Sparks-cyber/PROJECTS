namespace GROUP_PROJECT
{
    partial class LandingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnAdmin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblBrand.Location = new System.Drawing.Point(135, 72);
            this.lblBrand.Text = "ADLAW";
            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTagline.ForeColor = System.Drawing.Color.DimGray;
            this.lblTagline.Location = new System.Drawing.Point(127, 142);
            this.lblTagline.Text = "Coffee, matcha and good days.";
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(125, 215);
            this.btnOrder.Size = new System.Drawing.Size(260, 58);
            this.btnOrder.Text = "ORDER NOW";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.OrderNow);
            this.btnAdmin.BackColor = System.Drawing.Color.White;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdmin.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.btnAdmin.Location = new System.Drawing.Point(125, 288);
            this.btnAdmin.Size = new System.Drawing.Size(260, 48);
            this.btnAdmin.Text = "LOGIN AS ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.AdminLogin);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(510, 420);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblTagline);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LandingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adlaw POS";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
