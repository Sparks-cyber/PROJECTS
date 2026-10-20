namespace GROUP_PROJECT
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlOrders;
        private System.Windows.Forms.Label lblOrdersCaption;
        private System.Windows.Forms.Label lblOrdersValue;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.Label lblItemsCaption;
        private System.Windows.Forms.Label lblItemsValue;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Label lblRevenueCaption;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView gridSales;

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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlOrders = new System.Windows.Forms.Panel();
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.lblOrdersCaption = new System.Windows.Forms.Label();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.lblItemsValue = new System.Windows.Forms.Label();
            this.lblItemsCaption = new System.Windows.Forms.Label();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueCaption = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.gridSales = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.pnlRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(990, 100);
            this.pnlHeader.TabIndex = 0;
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(826, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 40);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "REFRESH REPORT";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshReport);
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(31, 62);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(279, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Review completed customer orders and total revenue.";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblTitle.Location = new System.Drawing.Point(27, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SALES REPORT";
            //
            // pnlOrders
            //
            this.pnlOrders.BackColor = System.Drawing.Color.White;
            this.pnlOrders.Controls.Add(this.lblOrdersValue);
            this.pnlOrders.Controls.Add(this.lblOrdersCaption);
            this.pnlOrders.Location = new System.Drawing.Point(24, 122);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(300, 105);
            this.pnlOrders.TabIndex = 1;
            //
            // lblOrdersValue
            //
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblOrdersValue.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblOrdersValue.Location = new System.Drawing.Point(20, 38);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Size = new System.Drawing.Size(250, 50);
            this.lblOrdersValue.TabIndex = 1;
            this.lblOrdersValue.Text = "0";
            //
            // lblOrdersCaption
            //
            this.lblOrdersCaption.AutoSize = true;
            this.lblOrdersCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblOrdersCaption.Location = new System.Drawing.Point(22, 17);
            this.lblOrdersCaption.Name = "lblOrdersCaption";
            this.lblOrdersCaption.Size = new System.Drawing.Size(124, 15);
            this.lblOrdersCaption.TabIndex = 0;
            this.lblOrdersCaption.Text = "COMPLETED ORDERS";
            //
            // pnlItems
            //
            this.pnlItems.BackColor = System.Drawing.Color.White;
            this.pnlItems.Controls.Add(this.lblItemsValue);
            this.pnlItems.Controls.Add(this.lblItemsCaption);
            this.pnlItems.Location = new System.Drawing.Point(342, 122);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(300, 105);
            this.pnlItems.TabIndex = 2;
            //
            // lblItemsValue
            //
            this.lblItemsValue.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblItemsValue.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblItemsValue.Location = new System.Drawing.Point(20, 38);
            this.lblItemsValue.Name = "lblItemsValue";
            this.lblItemsValue.Size = new System.Drawing.Size(250, 50);
            this.lblItemsValue.TabIndex = 1;
            this.lblItemsValue.Text = "0";
            //
            // lblItemsCaption
            //
            this.lblItemsCaption.AutoSize = true;
            this.lblItemsCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblItemsCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblItemsCaption.Location = new System.Drawing.Point(22, 17);
            this.lblItemsCaption.Name = "lblItemsCaption";
            this.lblItemsCaption.Size = new System.Drawing.Size(72, 15);
            this.lblItemsCaption.TabIndex = 0;
            this.lblItemsCaption.Text = "ITEMS SOLD";
            //
            // pnlRevenue
            //
            this.pnlRevenue.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.pnlRevenue.Controls.Add(this.lblRevenueValue);
            this.pnlRevenue.Controls.Add(this.lblRevenueCaption);
            this.pnlRevenue.Location = new System.Drawing.Point(660, 122);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(306, 105);
            this.pnlRevenue.TabIndex = 3;
            //
            // lblRevenueValue
            //
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblRevenueValue.Location = new System.Drawing.Point(20, 40);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(280, 46);
            this.lblRevenueValue.TabIndex = 1;
            this.lblRevenueValue.Text = "₱0.00";
            //
            // lblRevenueCaption
            //
            this.lblRevenueCaption.AutoSize = true;
            this.lblRevenueCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevenueCaption.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRevenueCaption.Location = new System.Drawing.Point(22, 17);
            this.lblRevenueCaption.Name = "lblRevenueCaption";
            this.lblRevenueCaption.Size = new System.Drawing.Size(94, 15);
            this.lblRevenueCaption.TabIndex = 0;
            this.lblRevenueCaption.Text = "TOTAL REVENUE";
            //
            // lblHistory
            //
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistory.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblHistory.Location = new System.Drawing.Point(24, 256);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(115, 20);
            this.lblHistory.TabIndex = 4;
            this.lblHistory.Text = "ORDER DETAILS";
            //
            // lblSummary
            //
            this.lblSummary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblSummary.ForeColor = System.Drawing.Color.DimGray;
            this.lblSummary.Location = new System.Drawing.Point(590, 252);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(376, 25);
            this.lblSummary.TabIndex = 5;
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // gridSales
            //
            this.gridSales.AllowUserToAddRows = false;
            this.gridSales.AllowUserToDeleteRows = false;
            this.gridSales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.gridSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSales.BackgroundColor = System.Drawing.Color.White;
            this.gridSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.gridSales.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.gridSales.ColumnHeadersHeight = 42;
            this.gridSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 237, 229);
            this.gridSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.gridSales.EnableHeadersVisualStyles = false;
            this.gridSales.Location = new System.Drawing.Point(24, 286);
            this.gridSales.MultiSelect = false;
            this.gridSales.Name = "gridSales";
            this.gridSales.ReadOnly = true;
            this.gridSales.RowHeadersVisible = false;
            this.gridSales.RowTemplate.Height = 38;
            this.gridSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSales.Size = new System.Drawing.Size(942, 390);
            this.gridSales.TabIndex = 6;
            //
            // SalesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(990, 700);
            this.Controls.Add(this.gridSales);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.pnlRevenue);
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.pnlOrders);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adlaw POS - Sales Report";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlOrders.ResumeLayout(false);
            this.pnlOrders.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.pnlRevenue.ResumeLayout(false);
            this.pnlRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
