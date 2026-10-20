namespace MiniMartPOS
{
    partial class CustomersForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPrimary = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = System.Drawing.Color.White; this.lblTitle.Location = new System.Drawing.Point(14, 12); this.lblTitle.Text = "Suppliers";
            this.lblSubtitle.AutoSize = true; this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F); this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184); this.lblSubtitle.Location = new System.Drawing.Point(16, 49); this.lblSubtitle.Text = "Supply contacts for food and kitchen stocks";
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(39, 32, 28); this.panelToolbar.Controls.Add(this.btnPrimary); this.panelToolbar.Controls.Add(this.btnEdit); this.panelToolbar.Controls.Add(this.btnDelete); this.panelToolbar.Controls.Add(this.txtSearch); this.panelToolbar.Location = new System.Drawing.Point(18, 84); this.panelToolbar.Size = new System.Drawing.Size(974, 72);
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(54, 43, 36); this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F); this.txtSearch.ForeColor = System.Drawing.Color.White; this.txtSearch.Location = new System.Drawing.Point(18, 20); this.txtSearch.Size = new System.Drawing.Size(420, 25);
            this.btnPrimary.BackColor = System.Drawing.Color.FromArgb(234, 88, 12); this.btnPrimary.FlatAppearance.BorderSize = 0; this.btnPrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPrimary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.btnPrimary.ForeColor = System.Drawing.Color.White; this.btnPrimary.Location = new System.Drawing.Point(808, 15); this.btnPrimary.Size = new System.Drawing.Size(148, 42); this.btnPrimary.Text = "+  Add"; this.btnPrimary.UseVisualStyleBackColor = false; this.btnPrimary.Click += new System.EventHandler(this.btnPrimary_Click);
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(101,60,37); this.btnEdit.FlatAppearance.BorderSize=0; this.btnEdit.FlatStyle=System.Windows.Forms.FlatStyle.Flat; this.btnEdit.ForeColor=System.Drawing.Color.White; this.btnEdit.Location=new System.Drawing.Point(624,15); this.btnEdit.Size=new System.Drawing.Size(84,42); this.btnEdit.Text="Edit"; this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(73,56,46); this.btnDelete.FlatAppearance.BorderSize=0; this.btnDelete.FlatStyle=System.Windows.Forms.FlatStyle.Flat; this.btnDelete.ForeColor=System.Drawing.Color.White; this.btnDelete.Location=new System.Drawing.Point(716,15); this.btnDelete.Size=new System.Drawing.Size(84,42); this.btnDelete.Text="Deactivate"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.dgvData.AllowUserToAddRows = false; this.dgvData.AllowUserToDeleteRows = false; this.dgvData.AllowUserToResizeRows = false; this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(39, 32, 28); this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None; this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(54, 43, 36); this.dgvData.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225); this.dgvData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.dgvData.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(39, 32, 28); this.dgvData.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240); this.dgvData.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(101, 60, 37); this.dgvData.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White; this.dgvData.EnableHeadersVisualStyles = false; this.dgvData.GridColor = System.Drawing.Color.FromArgb(73, 56, 46); this.dgvData.Location = new System.Drawing.Point(18, 174); this.dgvData.ReadOnly = true; this.dgvData.RowHeadersVisible = false; this.dgvData.RowTemplate.Height = 38; this.dgvData.Size = new System.Drawing.Size(974, 450); this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.col1, this.col2, this.col3, this.col4, this.col5, this.col6 });
            this.col1.HeaderText = "Supplier ID"; this.col1.Name = "col1"; this.col1.Width = 110;
            this.col2.HeaderText = "Supplier Name"; this.col2.Name = "col2"; this.col2.Width = 190;
            this.col3.HeaderText = "Contact"; this.col3.Name = "col3"; this.col3.Width = 110;
            this.col4.HeaderText = "Supplies"; this.col4.Name = "col4"; this.col4.Width = 110;
            this.col5.HeaderText = "Last Delivery"; this.col5.Name = "col5"; this.col5.Width = 110;
            this.col6.HeaderText = "Status"; this.col6.Name = "col6"; this.col6.Width = 110;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.BackColor = System.Drawing.Color.FromArgb(28,22,19); this.ClientSize = new System.Drawing.Size(1010,646); this.Controls.Add(this.dgvData); this.Controls.Add(this.panelToolbar); this.Controls.Add(this.lblSubtitle); this.Controls.Add(this.lblTitle); this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; this.Name = "CustomersForm"; this.Text = "Suppliers";
            this.panelToolbar.ResumeLayout(false); this.panelToolbar.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblTitle; private System.Windows.Forms.Label lblSubtitle; private System.Windows.Forms.Panel panelToolbar; private System.Windows.Forms.TextBox txtSearch; private System.Windows.Forms.Button btnPrimary; private System.Windows.Forms.Button btnEdit; private System.Windows.Forms.Button btnDelete; private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
    }
}
