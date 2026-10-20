namespace GROUP_PROJECT
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblChangeValue;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblChangeValue = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(430, 105);
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 18);
            this.lblTitle.Text = "PAYMENT";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(30, 66);
            this.lblSubtitle.Text = "Review the total and complete your payment.";
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblTotal.Location = new System.Drawing.Point(30, 132);
            this.lblTotal.Text = "TOTAL PRICE";
            //
            // lblTotalValue
            //
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblTotalValue.Location = new System.Drawing.Point(26, 151);
            this.lblTotalValue.Text = "₱0.00";
            //
            // lblMethod
            //
            this.lblMethod.AutoSize = true;
            this.lblMethod.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblMethod.ForeColor = System.Drawing.Color.Gray;
            this.lblMethod.Location = new System.Drawing.Point(30, 220);
            this.lblMethod.Text = "PAYMENT METHOD";
            //
            // cboPaymentMethod
            //
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboPaymentMethod.Items.AddRange(new object[] { "Cash", "GCash" });
            this.cboPaymentMethod.Location = new System.Drawing.Point(32, 241);
            this.cboPaymentMethod.Size = new System.Drawing.Size(366, 28);
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.PaymentMethodChanged);
            //
            // lblAmount
            //
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblAmount.Location = new System.Drawing.Point(30, 292);
            this.lblAmount.Text = "CASH PAYMENT";
            //
            // numAmount
            //
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.numAmount.Location = new System.Drawing.Point(32, 313);
            this.numAmount.Maximum = 1000000;
            this.numAmount.Size = new System.Drawing.Size(366, 29);
            this.numAmount.ValueChanged += new System.EventHandler(this.AmountChanged);
            //
            // lblChange
            //
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.Gray;
            this.lblChange.Location = new System.Drawing.Point(30, 365);
            this.lblChange.Text = "CHANGE";
            //
            // lblChangeValue
            //
            this.lblChangeValue.AutoSize = true;
            this.lblChangeValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblChangeValue.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblChangeValue.Location = new System.Drawing.Point(27, 383);
            this.lblChangeValue.Text = "₱0.00";
            //
            // btnPay
            //
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(184, 445);
            this.btnPay.Size = new System.Drawing.Size(214, 48);
            this.btnPay.Text = "COMPLETE PAYMENT";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.CompletePayment);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.btnCancel.Location = new System.Drawing.Point(32, 445);
            this.btnCancel.Size = new System.Drawing.Size(140, 48);
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.CancelPayment);
            //
            // PaymentForm
            //
            this.AcceptButton = this.btnPay;
            this.CancelButton = this.btnCancel;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(430, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblChangeValue);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cboPaymentMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adlaw POS - Payment";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
