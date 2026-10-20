namespace GROUP_PROJECT
{
    partial class ReceiptForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlReceipt;
        private System.Windows.Forms.RichTextBox txtReceipt;
        private System.Windows.Forms.Button btnDone;

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
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlReceipt = new System.Windows.Forms.Panel();
            this.txtReceipt = new System.Windows.Forms.RichTextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlReceipt.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.pnlHeader.Controls.Add(this.lblMessage);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblBrand);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(430, 130);
            this.pnlHeader.TabIndex = 0;
            //
            // lblBrand
            //
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(216, 190, 143);
            this.lblBrand.Location = new System.Drawing.Point(30, 23);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(72, 15);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "ADLAW POS";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "RECEIPT";
            //
            // lblMessage
            //
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMessage.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMessage.Location = new System.Drawing.Point(30, 96);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(199, 15);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Your order was completed successfully.";
            //
            // pnlReceipt
            //
            this.pnlReceipt.BackColor = System.Drawing.Color.White;
            this.pnlReceipt.Controls.Add(this.txtReceipt);
            this.pnlReceipt.Location = new System.Drawing.Point(22, 151);
            this.pnlReceipt.Name = "pnlReceipt";
            this.pnlReceipt.Padding = new System.Windows.Forms.Padding(22);
            this.pnlReceipt.Size = new System.Drawing.Size(386, 401);
            this.pnlReceipt.TabIndex = 1;
            //
            // txtReceipt
            //
            this.txtReceipt.BackColor = System.Drawing.Color.White;
            this.txtReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceipt.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtReceipt.ForeColor = System.Drawing.Color.FromArgb(45, 55, 48);
            this.txtReceipt.Location = new System.Drawing.Point(22, 22);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.Size = new System.Drawing.Size(342, 357);
            this.txtReceipt.TabIndex = 0;
            this.txtReceipt.Text = "             ADLAW\n          OFFICIAL RECEIPT\n--------------------------------\nReceipt details will appear here.";
            //
            // btnDone
            //
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(22, 573);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(386, 50);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "DONE";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.CloseReceipt);
            //
            // ReceiptForm
            //
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 239, 236);
            this.ClientSize = new System.Drawing.Size(430, 645);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.pnlReceipt);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adlaw POS - Receipt";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlReceipt.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
