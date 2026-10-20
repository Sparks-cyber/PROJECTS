namespace MiniMartPOS
{
    partial class MenuItemEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.lblReorder = new System.Windows.Forms.Label();
            this.numReorder = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lblImageHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = System.Drawing.Color.White; this.lblTitle.Location = new System.Drawing.Point(24, 18); this.lblTitle.Text = "Menu Item";
            this.lblCode.AutoSize = true; this.lblCode.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblCode.Location = new System.Drawing.Point(26,72); this.lblCode.Text = "Item Code";
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.txtCode.ForeColor = System.Drawing.Color.White; this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtCode.Location = new System.Drawing.Point(150,69); this.txtCode.Size = new System.Drawing.Size(210,26);
            this.lblName.AutoSize = true; this.lblName.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblName.Location = new System.Drawing.Point(26,116); this.lblName.Text = "Item Name";
            this.txtName.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.txtName.ForeColor = System.Drawing.Color.White; this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtName.Location = new System.Drawing.Point(150,113); this.txtName.Size = new System.Drawing.Size(210,26);
            this.lblCategory.AutoSize = true; this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblCategory.Location = new System.Drawing.Point(26,160); this.lblCategory.Text = "Category";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.cmbCategory.ForeColor = System.Drawing.Color.White; this.cmbCategory.Location = new System.Drawing.Point(150,157); this.cmbCategory.Size = new System.Drawing.Size(210,30);
            this.lblSupplier.AutoSize = true; this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblSupplier.Location = new System.Drawing.Point(26,204); this.lblSupplier.Text = "Supplier";
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbSupplier.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.cmbSupplier.ForeColor = System.Drawing.Color.White; this.cmbSupplier.Location = new System.Drawing.Point(150,201); this.cmbSupplier.Size = new System.Drawing.Size(210,30);
            this.lblPrice.AutoSize = true; this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblPrice.Location = new System.Drawing.Point(26,248); this.lblPrice.Text = "Price";
            this.numPrice.DecimalPlaces = 2; this.numPrice.Maximum = 999999; this.numPrice.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.numPrice.ForeColor = System.Drawing.Color.White; this.numPrice.Location = new System.Drawing.Point(150,245); this.numPrice.Size = new System.Drawing.Size(210,26);
            this.lblStock.AutoSize = true; this.lblStock.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblStock.Location = new System.Drawing.Point(26,292); this.lblStock.Text = "Stock";
            this.numStock.Maximum = 999999; this.numStock.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.numStock.ForeColor = System.Drawing.Color.White; this.numStock.Location = new System.Drawing.Point(150,289); this.numStock.Size = new System.Drawing.Size(210,26);
            this.lblReorder.AutoSize = true; this.lblReorder.ForeColor = System.Drawing.Color.FromArgb(203,213,225); this.lblReorder.Location = new System.Drawing.Point(26,336); this.lblReorder.Text = "Reorder Level";
            this.numReorder.Maximum = 999999; this.numReorder.BackColor = System.Drawing.Color.FromArgb(54,43,36); this.numReorder.ForeColor = System.Drawing.Color.White; this.numReorder.Location = new System.Drawing.Point(150,333); this.numReorder.Size = new System.Drawing.Size(210,26);
            this.chkActive.AutoSize = true; this.chkActive.Checked = true; this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked; this.chkActive.ForeColor = System.Drawing.Color.White; this.chkActive.Location = new System.Drawing.Point(150,382); this.chkActive.Text = "Active";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(234,88,12); this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSave.FlatAppearance.BorderSize = 0; this.btnSave.ForeColor = System.Drawing.Color.White; this.btnSave.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnSave.Location = new System.Drawing.Point(250,425); this.btnSave.Size = new System.Drawing.Size(110,38); this.btnSave.Text = "SAVE"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(73,56,46); this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCancel.FlatAppearance.BorderSize = 0; this.btnCancel.ForeColor = System.Drawing.Color.White; this.btnCancel.Location = new System.Drawing.Point(130,425); this.btnCancel.Size = new System.Drawing.Size(110,38); this.btnCancel.Text = "CANCEL"; this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.lblImage.AutoSize=true; this.lblImage.Font=new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold); this.lblImage.ForeColor=System.Drawing.Color.White; this.lblImage.Location=new System.Drawing.Point(390,72); this.lblImage.Text="Product Image";
            this.picPreview.BackColor=System.Drawing.Color.FromArgb(39,32,28); this.picPreview.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle; this.picPreview.Location=new System.Drawing.Point(390,100); this.picPreview.Size=new System.Drawing.Size(200,200); this.picPreview.SizeMode=System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBrowseImage.BackColor=System.Drawing.Color.FromArgb(101,60,37); this.btnBrowseImage.FlatStyle=System.Windows.Forms.FlatStyle.Flat; this.btnBrowseImage.FlatAppearance.BorderSize=0; this.btnBrowseImage.ForeColor=System.Drawing.Color.White; this.btnBrowseImage.Font=new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnBrowseImage.Location=new System.Drawing.Point(390,312); this.btnBrowseImage.Size=new System.Drawing.Size(200,38); this.btnBrowseImage.Text="UPLOAD / CHANGE IMAGE"; this.btnBrowseImage.Click+=new System.EventHandler(this.btnBrowseImage_Click);
            this.lblImageHint.ForeColor=System.Drawing.Color.FromArgb(160,148,140); this.lblImageHint.Location=new System.Drawing.Point(390,360); this.lblImageHint.Size=new System.Drawing.Size(200,44); this.lblImageHint.Text="PNG or JPG • Square transparent images look best.";
            this.btnSave.Location=new System.Drawing.Point(480,425); this.btnCancel.Location=new System.Drawing.Point(360,425);
            this.AcceptButton = this.btnSave; this.CancelButton = this.btnCancel; this.BackColor = System.Drawing.Color.FromArgb(28,22,19); this.ClientSize = new System.Drawing.Size(620,490); this.Controls.Add(this.lblImage); this.Controls.Add(this.picPreview); this.Controls.Add(this.btnBrowseImage); this.Controls.Add(this.lblImageHint); this.Controls.Add(this.lblTitle); this.Controls.Add(this.lblCode); this.Controls.Add(this.txtCode); this.Controls.Add(this.lblName); this.Controls.Add(this.txtName); this.Controls.Add(this.lblCategory); this.Controls.Add(this.cmbCategory); this.Controls.Add(this.lblSupplier); this.Controls.Add(this.cmbSupplier); this.Controls.Add(this.lblPrice); this.Controls.Add(this.numPrice); this.Controls.Add(this.lblStock); this.Controls.Add(this.numStock); this.Controls.Add(this.lblReorder); this.Controls.Add(this.numReorder); this.Controls.Add(this.chkActive); this.Controls.Add(this.btnSave); this.Controls.Add(this.btnCancel); this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.MinimizeBox = false; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; this.Text = "Menu Item";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.numReorder)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTitle, lblCode, lblName, lblCategory, lblSupplier, lblPrice, lblStock, lblReorder;
        private System.Windows.Forms.TextBox txtCode, txtName;
        private System.Windows.Forms.ComboBox cmbCategory, cmbSupplier;
        private System.Windows.Forms.NumericUpDown numPrice, numStock, numReorder;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.Label lblImage, lblImageHint;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnBrowseImage;
    }
}
