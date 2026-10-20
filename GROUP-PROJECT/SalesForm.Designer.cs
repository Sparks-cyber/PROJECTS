namespace GROUP_PROJECT
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView gridSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.gridSales = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 96;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "SALES / POS";
            this.lblTitle.Location = new System.Drawing.Point(28, 15);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Text = "Complete orders and review recent sales.";
            this.lblSubtitle.Location = new System.Drawing.Point(31, 61);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.pnlOrder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlOrder.BackColor = System.Drawing.Color.White;
            this.pnlOrder.Location = new System.Drawing.Point(24, 118);
            this.pnlOrder.Size = new System.Drawing.Size(956, 142);
            this.lblProduct.AutoSize = true;
            this.lblProduct.Text = "PRODUCT";
            this.lblProduct.Location = new System.Drawing.Point(22, 20);
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProduct.ForeColor = System.Drawing.Color.DimGray;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Text = "QUANTITY";
            this.lblQuantity.Location = new System.Drawing.Point(402, 20);
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.Color.DimGray;
            this.pnlOrder.Controls.Add(this.lblProduct);
            this.pnlOrder.Controls.Add(this.lblQuantity);

            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProduct.Location = new System.Drawing.Point(22, 44);
            this.cboProduct.Size = new System.Drawing.Size(355, 25);
            this.cboProduct.DisplayMember = "ItemName";
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.ProductChanged);
            this.pnlOrder.Controls.Add(this.cboProduct);

            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numQuantity.Location = new System.Drawing.Point(402, 44);
            this.numQuantity.Size = new System.Drawing.Size(120, 25);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Maximum = 1000;
            this.numQuantity.Value = 1;
            this.numQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pnlOrder.Controls.Add(this.numQuantity);

            this.btnCompleteSale.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSale.FlatAppearance.BorderSize = 0;
            this.btnCompleteSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(548, 39);
            this.btnCompleteSale.Size = new System.Drawing.Size(170, 38);
            this.btnCompleteSale.Text = "COMPLETE SALE";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.CompleteSale);
            this.pnlOrder.Controls.Add(this.btnCompleteSale);

            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetails.ForeColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.lblDetails.Location = new System.Drawing.Point(22, 94);
            this.lblDetails.Text = "Select a product.";
            this.pnlOrder.Controls.Add(this.lblDetails);

            this.lblSummary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSummary.ForeColor = System.Drawing.Color.DimGray;
            this.lblSummary.Location = new System.Drawing.Point(604, 284);
            this.lblSummary.Size = new System.Drawing.Size(376, 25);
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.gridSales.AllowUserToAddRows = false;
            this.gridSales.AllowUserToDeleteRows = false;
            this.gridSales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.gridSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSales.BackgroundColor = System.Drawing.Color.White;
            this.gridSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSales.ColumnHeadersHeight = 42;
            this.gridSales.EnableHeadersVisualStyles = false;
            this.gridSales.MultiSelect = false;
            this.gridSales.ReadOnly = true;
            this.gridSales.RowHeadersVisible = false;
            this.gridSales.RowTemplate.Height = 38;
            this.gridSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.gridSales.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.gridSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 237, 229);
            this.gridSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.gridSales.Location = new System.Drawing.Point(24, 318);
            this.gridSales.Size = new System.Drawing.Size(956, 316);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(1004, 656);
            this.Controls.Add(this.gridSales);
            this.Controls.Add(this.lblSummary);
            this.lblHistory.AutoSize = true;
            this.lblHistory.Text = "SALES HISTORY";
            this.lblHistory.Location = new System.Drawing.Point(24, 286);
            this.lblHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistory.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adlaw POS - Sales";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
