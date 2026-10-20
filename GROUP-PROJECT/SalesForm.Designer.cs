namespace GROUP_PROJECT
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView gridSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing) { if (components != null) components.Dispose(); db.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlOrder = new System.Windows.Forms.Panel();
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
            this.pnlHeader.Controls.Add(MakeLabel("SALES / POS", 28, 15, 21F, true));
            this.pnlHeader.Controls.Add(MakeLabel("Complete orders and review recent sales.", 31, 61, 9F, false));

            this.pnlOrder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlOrder.BackColor = System.Drawing.Color.White;
            this.pnlOrder.Location = new System.Drawing.Point(24, 118);
            this.pnlOrder.Size = new System.Drawing.Size(956, 142);
            this.pnlOrder.Controls.Add(MakeLabel("PRODUCT", 22, 20, 8F, true));
            this.pnlOrder.Controls.Add(MakeLabel("QUANTITY", 402, 20, 8F, true));

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

            SetupGrid(this.gridSales);
            this.gridSales.Location = new System.Drawing.Point(24, 318);
            this.gridSales.Size = new System.Drawing.Size(956, 316);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(1004, 656);
            this.Controls.Add(this.gridSales);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(MakeLabel("SALES HISTORY", 24, 286, 11F, true));
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

        private static System.Windows.Forms.Label MakeLabel(string text, int x, int y, float size, bool bold)
        {
            return new System.Windows.Forms.Label { AutoSize = true, Text = text,
                Location = new System.Drawing.Point(x, y),
                Font = new System.Drawing.Font("Segoe UI", size, bold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular),
                ForeColor = bold ? System.Drawing.Color.FromArgb(48, 70, 57) : System.Drawing.Color.DimGray };
        }

        private static void SetupGrid(System.Windows.Forms.DataGridView grid)
        {
            grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false;
            grid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = System.Drawing.Color.White; grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grid.ColumnHeadersHeight = 42; grid.EnableHeadersVisualStyles = false; grid.MultiSelect = false;
            grid.ReadOnly = true; grid.RowHeadersVisible = false; grid.RowTemplate.Height = 38;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 237, 229);
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
        }
        #endregion
    }
}
