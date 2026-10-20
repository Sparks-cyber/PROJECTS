namespace GROUP_PROJECT
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlRestock;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblStockTitle;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.Label lblProductDetails;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView gridInventory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlRestock = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnRestock = new System.Windows.Forms.Button();
            this.lblProductDetails = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.gridInventory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 96;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "INVENTORY";
            this.lblTitle.Location = new System.Drawing.Point(28, 15);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Text = "Monitor stock levels and restock products.";
            this.lblSubtitle.Location = new System.Drawing.Point(31, 61);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.pnlRestock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlRestock.BackColor = System.Drawing.Color.White;
            this.pnlRestock.Location = new System.Drawing.Point(24, 118);
            this.pnlRestock.Size = new System.Drawing.Size(942, 142);
            this.lblProduct.AutoSize = true;
            this.lblProduct.Text = "PRODUCT";
            this.lblProduct.Location = new System.Drawing.Point(22, 20);
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProduct.ForeColor = System.Drawing.Color.DimGray;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Text = "ADD STOCK";
            this.lblQuantity.Location = new System.Drawing.Point(402, 20);
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.Color.DimGray;
            this.pnlRestock.Controls.Add(this.lblProduct);
            this.pnlRestock.Controls.Add(this.lblQuantity);

            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProduct.Location = new System.Drawing.Point(22, 44);
            this.cboProduct.Size = new System.Drawing.Size(355, 25);
            this.cboProduct.DisplayMember = "DisplayName";
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.ProductChanged);
            this.pnlRestock.Controls.Add(this.cboProduct);

            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numQuantity.Location = new System.Drawing.Point(402, 44);
            this.numQuantity.Size = new System.Drawing.Size(120, 25);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Maximum = 10000;
            this.numQuantity.Value = 1;
            this.numQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pnlRestock.Controls.Add(this.numQuantity);

            this.btnRestock.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnRestock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestock.FlatAppearance.BorderSize = 0;
            this.btnRestock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestock.ForeColor = System.Drawing.Color.White;
            this.btnRestock.Location = new System.Drawing.Point(548, 39);
            this.btnRestock.Size = new System.Drawing.Size(150, 38);
            this.btnRestock.Text = "RESTOCK";
            this.btnRestock.UseVisualStyleBackColor = false;
            this.btnRestock.Click += new System.EventHandler(this.RestockProduct);
            this.pnlRestock.Controls.Add(this.btnRestock);

            this.lblProductDetails.AutoSize = true;
            this.lblProductDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductDetails.ForeColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.lblProductDetails.Location = new System.Drawing.Point(22, 94);
            this.lblProductDetails.Text = "Select a product.";
            this.pnlRestock.Controls.Add(this.lblProductDetails);

            this.lblSummary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSummary.ForeColor = System.Drawing.Color.DimGray;
            this.lblSummary.Location = new System.Drawing.Point(590, 284);
            this.lblSummary.Size = new System.Drawing.Size(376, 25);
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.gridInventory.AllowUserToAddRows = false;
            this.gridInventory.AllowUserToDeleteRows = false;
            this.gridInventory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.gridInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInventory.BackgroundColor = System.Drawing.Color.White;
            this.gridInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInventory.ColumnHeadersHeight = 42;
            this.gridInventory.EnableHeadersVisualStyles = false;
            this.gridInventory.MultiSelect = false;
            this.gridInventory.ReadOnly = true;
            this.gridInventory.RowHeadersVisible = false;
            this.gridInventory.RowTemplate.Height = 38;
            this.gridInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInventory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.gridInventory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.gridInventory.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 237, 229);
            this.gridInventory.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.gridInventory.Location = new System.Drawing.Point(24, 318);
            this.gridInventory.Size = new System.Drawing.Size(942, 358);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(990, 700);
            this.Controls.Add(this.gridInventory);
            this.Controls.Add(this.lblSummary);
            this.lblStockTitle.AutoSize = true;
            this.lblStockTitle.Text = "CURRENT STOCK";
            this.lblStockTitle.Location = new System.Drawing.Point(24, 286);
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStockTitle.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.Controls.Add(this.lblStockTitle);
            this.Controls.Add(this.pnlRestock);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adlaw POS - Inventory";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
