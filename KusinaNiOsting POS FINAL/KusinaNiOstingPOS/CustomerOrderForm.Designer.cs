namespace MiniMartPOS
{
    partial class CustomerOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblOrderTitle;
        private System.Windows.Forms.Label lblOrderSubtitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel(); this.btnBack = new System.Windows.Forms.Button(); this.lblOrderSubtitle = new System.Windows.Forms.Label(); this.lblOrderTitle = new System.Windows.Forms.Label(); this.panelContent = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout(); this.SuspendLayout();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(24,18,15); this.panelHeader.Controls.Add(this.btnBack); this.panelHeader.Controls.Add(this.lblOrderSubtitle); this.panelHeader.Controls.Add(this.lblOrderTitle); this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top; this.panelHeader.Location = new System.Drawing.Point(0,0); this.panelHeader.Name = "panelHeader"; this.panelHeader.Padding = new System.Windows.Forms.Padding(28,0,28,0); this.panelHeader.Size = new System.Drawing.Size(1180,82); this.panelHeader.TabIndex = 0;
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right; this.btnBack.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.btnBack.FlatAppearance.BorderSize = 0; this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnBack.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnBack.ForeColor = System.Drawing.Color.White; this.btnBack.Location = new System.Drawing.Point(982,20); this.btnBack.Name = "btnBack"; this.btnBack.Size = new System.Drawing.Size(168,42); this.btnBack.TabIndex = 2; this.btnBack.Text = "✕  CLOSE ORDER"; this.btnBack.UseVisualStyleBackColor = false; this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.lblOrderSubtitle.AutoSize = true; this.lblOrderSubtitle.Font = new System.Drawing.Font("Segoe UI",9.5F); this.lblOrderSubtitle.ForeColor = System.Drawing.Color.FromArgb(180,167,159); this.lblOrderSubtitle.Location = new System.Drawing.Point(32,49); this.lblOrderSubtitle.Name = "lblOrderSubtitle"; this.lblOrderSubtitle.Size = new System.Drawing.Size(401,17); this.lblOrderSubtitle.TabIndex = 1; this.lblOrderSubtitle.Text = "Choose your favorites. Use the minus button to reduce quantity.";
            this.lblOrderTitle.AutoSize = true; this.lblOrderTitle.Font = new System.Drawing.Font("Segoe UI",20F,System.Drawing.FontStyle.Bold); this.lblOrderTitle.ForeColor = System.Drawing.Color.White; this.lblOrderTitle.Location = new System.Drawing.Point(30,14); this.lblOrderTitle.Name = "lblOrderTitle"; this.lblOrderTitle.Size = new System.Drawing.Size(225,37); this.lblOrderTitle.TabIndex = 0; this.lblOrderTitle.Text = "Build your order";
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(28,22,19); this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill; this.panelContent.Location = new System.Drawing.Point(0,82); this.panelContent.Name = "panelContent"; this.panelContent.Padding = new System.Windows.Forms.Padding(20); this.panelContent.Size = new System.Drawing.Size(1180,678); this.panelContent.TabIndex = 1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F,96F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi; this.BackColor = System.Drawing.Color.FromArgb(28,22,19); this.ClientSize = new System.Drawing.Size(1280,760); this.Controls.Add(this.panelContent); this.Controls.Add(this.panelHeader); this.Font = new System.Drawing.Font("Segoe UI",10F); this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; this.MaximizeBox = false; this.MaximumSize = new System.Drawing.Size(1296,799); this.MinimumSize = new System.Drawing.Size(1296,799); this.Name = "CustomerOrderForm"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "Kusina ni Osting | Customer Order";
            this.panelHeader.ResumeLayout(false); this.panelHeader.PerformLayout(); this.ResumeLayout(false);
        }
    }
}
