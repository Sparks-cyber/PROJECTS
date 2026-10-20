namespace MiniMartPOS
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblTotal, lblTotalValue, lblMethod, lblAmount, lblChange, lblChangeValue;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Button btnConfirm, btnCancel;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label(); this.lblTotal = new System.Windows.Forms.Label(); this.lblTotalValue = new System.Windows.Forms.Label(); this.lblMethod = new System.Windows.Forms.Label(); this.cmbMethod = new System.Windows.Forms.ComboBox(); this.lblAmount = new System.Windows.Forms.Label(); this.numAmount = new System.Windows.Forms.NumericUpDown(); this.lblChange = new System.Windows.Forms.Label(); this.lblChangeValue = new System.Windows.Forms.Label(); this.btnConfirm = new System.Windows.Forms.Button(); this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit(); this.SuspendLayout();
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = System.Drawing.Color.White; this.lblTitle.Location = new System.Drawing.Point(24,18); this.lblTitle.Text = "Payment";
            this.lblTotal.AutoSize = true; this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblTotal.Location = new System.Drawing.Point(28,75); this.lblTotal.Text = "Total";
            this.lblTotalValue.AutoSize = true; this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI",20F,System.Drawing.FontStyle.Bold); this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(245,158,11); this.lblTotalValue.Location = new System.Drawing.Point(26,96);
            this.lblMethod.AutoSize = true; this.lblMethod.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblMethod.Location = new System.Drawing.Point(28,150); this.lblMethod.Text = "Payment Method";
            this.cmbMethod.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbMethod.ForeColor = System.Drawing.Color.White; this.cmbMethod.Items.AddRange(new object[] { AppConstants.PaymentCash, AppConstants.PaymentGCash }); this.cmbMethod.Location = new System.Drawing.Point(30,173); this.cmbMethod.Size = new System.Drawing.Size(330,30);
            this.lblAmount.AutoSize = true; this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblAmount.Location = new System.Drawing.Point(28,216); this.lblAmount.Text = "Cash Received";
            this.numAmount.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.numAmount.DecimalPlaces = 2; this.numAmount.ForeColor = System.Drawing.Color.White; this.numAmount.Maximum = 1000000; this.numAmount.Location = new System.Drawing.Point(30,239); this.numAmount.Size = new System.Drawing.Size(330,27);
            this.lblChange.AutoSize = true; this.lblChange.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblChange.Location = new System.Drawing.Point(28,284); this.lblChange.Text = "Change";
            this.lblChangeValue.AutoSize = true; this.lblChangeValue.Font = new System.Drawing.Font("Segoe UI",16F,System.Drawing.FontStyle.Bold); this.lblChangeValue.ForeColor = System.Drawing.Color.White; this.lblChangeValue.Location = new System.Drawing.Point(28,306);
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(234,88,12); this.btnConfirm.FlatAppearance.BorderSize = 0; this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnConfirm.ForeColor = System.Drawing.Color.White; this.btnConfirm.Location = new System.Drawing.Point(250,365); this.btnConfirm.Size = new System.Drawing.Size(110,40); this.btnConfirm.Text = "CONFIRM"; this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(73,56,46); this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel; this.btnCancel.FlatAppearance.BorderSize = 0; this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCancel.ForeColor = System.Drawing.Color.White; this.btnCancel.Location = new System.Drawing.Point(130,365); this.btnCancel.Size = new System.Drawing.Size(110,40); this.btnCancel.Text = "CANCEL";
            this.AcceptButton = this.btnConfirm; this.CancelButton = this.btnCancel; this.BackColor = System.Drawing.Color.FromArgb(28,22,19); this.ClientSize = new System.Drawing.Size(390,435); this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblTitle,this.lblTotal,this.lblTotalValue,this.lblMethod,this.cmbMethod,this.lblAmount,this.numAmount,this.lblChange,this.lblChangeValue,this.btnConfirm,this.btnCancel }); this.Font = new System.Drawing.Font("Segoe UI",9F); this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.MinimizeBox = false; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
