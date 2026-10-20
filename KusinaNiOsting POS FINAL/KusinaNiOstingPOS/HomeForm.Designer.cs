namespace MiniMartPOS
{
    partial class HomeForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.panelSalesCard = new System.Windows.Forms.Panel();
            this.lblSalesTrend = new System.Windows.Forms.Label();
            this.lblSalesValue = new System.Windows.Forms.Label();
            this.lblSalesTitle = new System.Windows.Forms.Label();
            this.panelProductsCard = new System.Windows.Forms.Panel();
            this.lblProductsTrend = new System.Windows.Forms.Label();
            this.lblProductsValue = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.panelTransactionsCard = new System.Windows.Forms.Panel();
            this.lblTransactionsTrend = new System.Windows.Forms.Label();
            this.lblTransactionsValue = new System.Windows.Forms.Label();
            this.lblTransactionsTitle = new System.Windows.Forms.Label();
            this.panelStockCard = new System.Windows.Forms.Panel();
            this.lblStockTrend = new System.Windows.Forms.Label();
            this.lblStockValue = new System.Windows.Forms.Label();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.panelSalesOverview = new System.Windows.Forms.Panel();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSalesOverviewTitle = new System.Windows.Forms.Label();
            this.panelPaymentMethods = new System.Windows.Forms.Panel();
            this.lblOtherValue = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblCardValue = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblGcashValue = new System.Windows.Forms.Label();
            this.lblGcash = new System.Windows.Forms.Label();
            this.lblCashValue = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.chartPayment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.panelRecentTransactions = new System.Windows.Forms.Panel();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.panelLowStock = new System.Windows.Forms.Panel();
            this.lblLowBadge3 = new System.Windows.Forms.Label();
            this.lblLowItem4 = new System.Windows.Forms.Label();
            this.lblLowBadge2 = new System.Windows.Forms.Label();
            this.lblLowItem3 = new System.Windows.Forms.Label();
            this.lblLowBadge1 = new System.Windows.Forms.Label();
            this.lblLowItem2 = new System.Windows.Forms.Label();
            this.lblCriticalBadge = new System.Windows.Forms.Label();
            this.lblLowItem1 = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelSalesCard.SuspendLayout();
            this.panelProductsCard.SuspendLayout();
            this.panelTransactionsCard.SuspendLayout();
            this.panelStockCard.SuspendLayout();
            this.panelSalesOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            this.panelPaymentMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPayment)).BeginInit();
            this.panelRecentTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            this.panelLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSalesCard
            // 
            this.panelSalesCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelSalesCard.Controls.Add(this.pictureBox1);
            this.panelSalesCard.Controls.Add(this.lblSalesTrend);
            this.panelSalesCard.Controls.Add(this.lblSalesValue);
            this.panelSalesCard.Controls.Add(this.lblSalesTitle);
            this.panelSalesCard.Location = new System.Drawing.Point(8, 8);
            this.panelSalesCard.Name = "panelSalesCard";
            this.panelSalesCard.Size = new System.Drawing.Size(238, 116);
            this.panelSalesCard.TabIndex = 7;
            // 
            // lblSalesTrend
            // 
            this.lblSalesTrend.AutoSize = true;
            this.lblSalesTrend.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSalesTrend.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSalesTrend.Location = new System.Drawing.Point(16, 88);
            this.lblSalesTrend.Name = "lblSalesTrend";
            this.lblSalesTrend.Size = new System.Drawing.Size(113, 13);
            this.lblSalesTrend.TabIndex = 0;
            this.lblSalesTrend.Text = "▲ 12.5% vs yesterday";
            // 
            // lblSalesValue
            // 
            this.lblSalesValue.AutoSize = true;
            this.lblSalesValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSalesValue.ForeColor = System.Drawing.Color.White;
            this.lblSalesValue.Location = new System.Drawing.Point(72, 39);
            this.lblSalesValue.Name = "lblSalesValue";
            this.lblSalesValue.Size = new System.Drawing.Size(117, 30);
            this.lblSalesValue.TabIndex = 1;
            this.lblSalesValue.Text = "₱3,850.00";
            // 
            // lblSalesTitle
            // 
            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSalesTitle.Location = new System.Drawing.Point(74, 18);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Size = new System.Drawing.Size(76, 15);
            this.lblSalesTitle.TabIndex = 2;
            this.lblSalesTitle.Text = "Today\'s Sales";
            // 
            // panelProductsCard
            // 
            this.panelProductsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelProductsCard.Controls.Add(this.pictureBox2);
            this.panelProductsCard.Controls.Add(this.lblProductsTrend);
            this.panelProductsCard.Controls.Add(this.lblProductsValue);
            this.panelProductsCard.Controls.Add(this.lblProductsTitle);
            this.panelProductsCard.Location = new System.Drawing.Point(260, 8);
            this.panelProductsCard.Name = "panelProductsCard";
            this.panelProductsCard.Size = new System.Drawing.Size(238, 116);
            this.panelProductsCard.TabIndex = 6;
            // 
            // lblProductsTrend
            // 
            this.lblProductsTrend.AutoSize = true;
            this.lblProductsTrend.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblProductsTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblProductsTrend.Location = new System.Drawing.Point(16, 88);
            this.lblProductsTrend.Name = "lblProductsTrend";
            this.lblProductsTrend.Size = new System.Drawing.Size(102, 13);
            this.lblProductsTrend.TabIndex = 0;
            this.lblProductsTrend.Text = "▲ 8.3% this month";
            // 
            // lblProductsValue
            // 
            this.lblProductsValue.AutoSize = true;
            this.lblProductsValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProductsValue.ForeColor = System.Drawing.Color.White;
            this.lblProductsValue.Location = new System.Drawing.Point(72, 39);
            this.lblProductsValue.Name = "lblProductsValue";
            this.lblProductsValue.Size = new System.Drawing.Size(52, 30);
            this.lblProductsValue.TabIndex = 1;
            this.lblProductsValue.Text = "18";
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(74, 18);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(83, 15);
            this.lblProductsTitle.TabIndex = 2;
            this.lblProductsTitle.Text = "Menu Items";
            // 
            // panelTransactionsCard
            // 
            this.panelTransactionsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelTransactionsCard.Controls.Add(this.pictureBox3);
            this.panelTransactionsCard.Controls.Add(this.lblTransactionsTrend);
            this.panelTransactionsCard.Controls.Add(this.lblTransactionsValue);
            this.panelTransactionsCard.Controls.Add(this.lblTransactionsTitle);
            this.panelTransactionsCard.Location = new System.Drawing.Point(512, 8);
            this.panelTransactionsCard.Name = "panelTransactionsCard";
            this.panelTransactionsCard.Size = new System.Drawing.Size(238, 116);
            this.panelTransactionsCard.TabIndex = 5;
            // 
            // lblTransactionsTrend
            // 
            this.lblTransactionsTrend.AutoSize = true;
            this.lblTransactionsTrend.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTransactionsTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTransactionsTrend.Location = new System.Drawing.Point(16, 88);
            this.lblTransactionsTrend.Name = "lblTransactionsTrend";
            this.lblTransactionsTrend.Size = new System.Drawing.Size(113, 13);
            this.lblTransactionsTrend.TabIndex = 0;
            this.lblTransactionsTrend.Text = "▲ 16.7% vs yesterday";
            // 
            // lblTransactionsValue
            // 
            this.lblTransactionsValue.AutoSize = true;
            this.lblTransactionsValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTransactionsValue.ForeColor = System.Drawing.Color.White;
            this.lblTransactionsValue.Location = new System.Drawing.Point(72, 39);
            this.lblTransactionsValue.Name = "lblTransactionsValue";
            this.lblTransactionsValue.Size = new System.Drawing.Size(39, 30);
            this.lblTransactionsValue.TabIndex = 1;
            this.lblTransactionsValue.Text = "24";
            // 
            // lblTransactionsTitle
            // 
            this.lblTransactionsTitle.AutoSize = true;
            this.lblTransactionsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransactionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTransactionsTitle.Location = new System.Drawing.Point(74, 18);
            this.lblTransactionsTitle.Name = "lblTransactionsTitle";
            this.lblTransactionsTitle.Size = new System.Drawing.Size(73, 15);
            this.lblTransactionsTitle.TabIndex = 2;
            this.lblTransactionsTitle.Text = "Transactions";
            // 
            // panelStockCard
            // 
            this.panelStockCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelStockCard.Controls.Add(this.pictureBox4);
            this.panelStockCard.Controls.Add(this.lblStockTrend);
            this.panelStockCard.Controls.Add(this.lblStockValue);
            this.panelStockCard.Controls.Add(this.lblStockTitle);
            this.panelStockCard.Location = new System.Drawing.Point(764, 8);
            this.panelStockCard.Name = "panelStockCard";
            this.panelStockCard.Size = new System.Drawing.Size(238, 116);
            this.panelStockCard.TabIndex = 4;
            // 
            // lblStockTrend
            // 
            this.lblStockTrend.AutoSize = true;
            this.lblStockTrend.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStockTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblStockTrend.Location = new System.Drawing.Point(16, 88);
            this.lblStockTrend.Name = "lblStockTrend";
            this.lblStockTrend.Size = new System.Drawing.Size(98, 13);
            this.lblStockTrend.TabIndex = 0;
            this.lblStockTrend.Text = "Attention needed";
            // 
            // lblStockValue
            // 
            this.lblStockValue.AutoSize = true;
            this.lblStockValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStockValue.ForeColor = System.Drawing.Color.White;
            this.lblStockValue.Location = new System.Drawing.Point(72, 39);
            this.lblStockValue.Name = "lblStockValue";
            this.lblStockValue.Size = new System.Drawing.Size(26, 30);
            this.lblStockValue.TabIndex = 1;
            this.lblStockValue.Text = "4";
            // 
            // lblStockTitle
            // 
            this.lblStockTitle.AutoSize = true;
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblStockTitle.Location = new System.Drawing.Point(74, 18);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new System.Drawing.Size(93, 15);
            this.lblStockTitle.TabIndex = 2;
            this.lblStockTitle.Text = "Low Stock Items";
            // 
            // panelSalesOverview
            // 
            this.panelSalesOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelSalesOverview.Controls.Add(this.cmbPeriod);
            this.panelSalesOverview.Controls.Add(this.chartSales);
            this.panelSalesOverview.Controls.Add(this.lblSalesOverviewTitle);
            this.panelSalesOverview.Location = new System.Drawing.Point(8, 138);
            this.panelSalesOverview.Name = "panelSalesOverview";
            this.panelSalesOverview.Size = new System.Drawing.Size(642, 264);
            this.panelSalesOverview.TabIndex = 3;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(43)))), ((int)(((byte)(36)))));


            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriod.ForeColor = System.Drawing.Color.White;
            this.cmbPeriod.Items.AddRange(new object[] {
            "This Week",
            "This Month",
            "This Year"});
            this.cmbPeriod.Location = new System.Drawing.Point(508, 13);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(112, 21);
            this.cmbPeriod.TabIndex = 0;
            // 
            // chartSales
            // 
            this.chartSales.BackColor = System.Drawing.Color.Transparent;
            this.chartSales.Location = new System.Drawing.Point(16, 47);
            this.chartSales.Name = "chartSales";
            this.chartSales.Size = new System.Drawing.Size(610, 201);
            this.chartSales.TabIndex = 2;
            // 
            // lblSalesOverviewTitle
            // 
            this.lblSalesOverviewTitle.AutoSize = true;
            this.lblSalesOverviewTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSalesOverviewTitle.ForeColor = System.Drawing.Color.White;
            this.lblSalesOverviewTitle.Location = new System.Drawing.Point(18, 14);
            this.lblSalesOverviewTitle.Name = "lblSalesOverviewTitle";
            this.lblSalesOverviewTitle.Size = new System.Drawing.Size(114, 20);
            this.lblSalesOverviewTitle.TabIndex = 3;
            this.lblSalesOverviewTitle.Text = "Sales Overview";
            // 
            // panelPaymentMethods
            // 
            this.panelPaymentMethods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelPaymentMethods.Controls.Add(this.lblOtherValue);
            this.panelPaymentMethods.Controls.Add(this.lblOther);
            this.panelPaymentMethods.Controls.Add(this.lblCardValue);
            this.panelPaymentMethods.Controls.Add(this.lblCard);
            this.panelPaymentMethods.Controls.Add(this.lblGcashValue);
            this.panelPaymentMethods.Controls.Add(this.lblGcash);
            this.panelPaymentMethods.Controls.Add(this.lblCashValue);
            this.panelPaymentMethods.Controls.Add(this.lblCash);
            this.panelPaymentMethods.Controls.Add(this.chartPayment);
            this.panelPaymentMethods.Controls.Add(this.lblPaymentTitle);
            this.panelPaymentMethods.Location = new System.Drawing.Point(664, 138);
            this.panelPaymentMethods.Name = "panelPaymentMethods";
            this.panelPaymentMethods.Size = new System.Drawing.Size(338, 264);
            this.panelPaymentMethods.TabIndex = 2;
            // 
            // lblOtherValue
            // 
            this.lblOtherValue.AutoSize = true;
            this.lblOtherValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblOtherValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblOtherValue.Location = new System.Drawing.Point(180, 216);
            this.lblOtherValue.Name = "lblOtherValue";
            this.lblOtherValue.Size = new System.Drawing.Size(55, 13);
            this.lblOtherValue.TabIndex = 0;
            this.lblOtherValue.Text = "8%";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblOther.Location = new System.Drawing.Point(180, 198);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(58, 15);
            this.lblOther.TabIndex = 1;
            this.lblOther.Text = "■ Drinks";
            // 
            // lblCardValue
            // 
            this.lblCardValue.AutoSize = true;
            this.lblCardValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblCardValue.Location = new System.Drawing.Point(180, 173);
            this.lblCardValue.Name = "lblCardValue";
            this.lblCardValue.Size = new System.Drawing.Size(61, 13);
            this.lblCardValue.TabIndex = 2;
            this.lblCardValue.Text = "20%";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblCard.Location = new System.Drawing.Point(180, 155);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(45, 15);
            this.lblCard.TabIndex = 3;
            this.lblCard.Text = "■ Meals";
            // 
            // lblGcashValue
            // 
            this.lblGcashValue.AutoSize = true;
            this.lblGcashValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblGcashValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblGcashValue.Location = new System.Drawing.Point(180, 130);
            this.lblGcashValue.Name = "lblGcashValue";
            this.lblGcashValue.Size = new System.Drawing.Size(70, 13);
            this.lblGcashValue.TabIndex = 4;
            this.lblGcashValue.Text = "34%";
            // 
            // lblGcash
            // 
            this.lblGcash.AutoSize = true;
            this.lblGcash.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGcash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblGcash.Location = new System.Drawing.Point(180, 112);
            this.lblGcash.Name = "lblGcash";
            this.lblGcash.Size = new System.Drawing.Size(54, 15);
            this.lblGcash.TabIndex = 5;
            this.lblGcash.Text = "■ Canned Goods";
            // 
            // lblCashValue
            // 
            this.lblCashValue.AutoSize = true;
            this.lblCashValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCashValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblCashValue.Location = new System.Drawing.Point(180, 87);
            this.lblCashValue.Name = "lblCashValue";
            this.lblCashValue.Size = new System.Drawing.Size(70, 13);
            this.lblCashValue.TabIndex = 6;
            this.lblCashValue.Text = "38%";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblCash.Location = new System.Drawing.Point(180, 69);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(45, 15);
            this.lblCash.TabIndex = 7;
            this.lblCash.Text = "■ Noodles";
            // 
            // chartPayment
            // 
            this.chartPayment.BackColor = System.Drawing.Color.Transparent;
            this.chartPayment.Location = new System.Drawing.Point(8, 48);
            this.chartPayment.Name = "chartPayment";
            this.chartPayment.Size = new System.Drawing.Size(166, 190);
            this.chartPayment.TabIndex = 8;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.White;
            this.lblPaymentTitle.Location = new System.Drawing.Point(18, 14);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(190, 20);
            this.lblPaymentTitle.TabIndex = 9;
            this.lblPaymentTitle.Text = "Sales by Category";
            // 
            // panelRecentTransactions
            // 
            this.panelRecentTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelRecentTransactions.Controls.Add(this.dgvRecent);
            this.panelRecentTransactions.Controls.Add(this.lblRecentTitle);
            this.panelRecentTransactions.Location = new System.Drawing.Point(8, 416);
            this.panelRecentTransactions.Name = "panelRecentTransactions";
            this.panelRecentTransactions.Size = new System.Drawing.Size(642, 220);
            this.panelRecentTransactions.TabIndex = 1;
            // 
            // dgvRecent
            // 
            this.dgvRecent.AllowUserToAddRows = false;
            this.dgvRecent.AllowUserToDeleteRows = false;
            this.dgvRecent.AllowUserToResizeRows = false;
            this.dgvRecent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(43)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(43)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProduct,
            this.colQty,
            this.colTotal,
            this.colPayment,
            this.colTime});
            this.dgvRecent.EnableHeadersVisualStyles = false;
            this.dgvRecent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(56)))), ((int)(((byte)(46)))));
            this.dgvRecent.Location = new System.Drawing.Point(18, 44);
            this.dgvRecent.Name = "dgvRecent";
            this.dgvRecent.ReadOnly = true;
            this.dgvRecent.RowHeadersVisible = false;
            this.dgvRecent.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.dgvRecent.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvRecent.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(60)))), ((int)(((byte)(37)))));
            this.dgvRecent.Size = new System.Drawing.Size(606, 158);
            this.dgvRecent.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 90;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "Menu Item";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 170;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 55;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 85;
            // 
            // colPayment
            // 
            this.colPayment.HeaderText = "Payment";
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            this.colPayment.Width = 85;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.White;
            this.lblRecentTitle.Location = new System.Drawing.Point(18, 13);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(149, 20);
            this.lblRecentTitle.TabIndex = 1;
            this.lblRecentTitle.Text = "Recent Transactions";
            // 
            // panelLowStock
            // 
            this.panelLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(32)))), ((int)(((byte)(28)))));
            this.panelLowStock.Controls.Add(this.lblLowBadge3);
            this.panelLowStock.Controls.Add(this.lblLowItem4);
            this.panelLowStock.Controls.Add(this.lblLowBadge2);
            this.panelLowStock.Controls.Add(this.lblLowItem3);
            this.panelLowStock.Controls.Add(this.lblLowBadge1);
            this.panelLowStock.Controls.Add(this.lblLowItem2);
            this.panelLowStock.Controls.Add(this.lblCriticalBadge);
            this.panelLowStock.Controls.Add(this.lblLowItem1);
            this.panelLowStock.Controls.Add(this.lblLowStockTitle);
            this.panelLowStock.Location = new System.Drawing.Point(664, 416);
            this.panelLowStock.Name = "panelLowStock";
            this.panelLowStock.Size = new System.Drawing.Size(338, 220);
            this.panelLowStock.TabIndex = 0;
            // 
            // lblLowBadge3
            // 
            this.lblLowBadge3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(38)))), ((int)(((byte)(17)))));
            this.lblLowBadge3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblLowBadge3.Location = new System.Drawing.Point(246, 169);
            this.lblLowBadge3.Name = "lblLowBadge3";
            this.lblLowBadge3.Size = new System.Drawing.Size(72, 24);
            this.lblLowBadge3.TabIndex = 0;
            this.lblLowBadge3.Text = "LOW";
            this.lblLowBadge3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowItem4
            // 
            this.lblLowItem4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLowItem4.ForeColor = System.Drawing.Color.White;
            this.lblLowItem4.Location = new System.Drawing.Point(18, 169);
            this.lblLowItem4.Name = "lblLowItem4";
            this.lblLowItem4.Size = new System.Drawing.Size(205, 28);
            this.lblLowItem4.TabIndex = 1;
            this.lblLowItem4.Text = "Rice            Stock: 6";
            // 
            // lblLowBadge2
            // 
            this.lblLowBadge2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(38)))), ((int)(((byte)(17)))));
            this.lblLowBadge2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblLowBadge2.Location = new System.Drawing.Point(246, 130);
            this.lblLowBadge2.Name = "lblLowBadge2";
            this.lblLowBadge2.Size = new System.Drawing.Size(72, 24);
            this.lblLowBadge2.TabIndex = 2;
            this.lblLowBadge2.Text = "LOW";
            this.lblLowBadge2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowItem3
            // 
            this.lblLowItem3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLowItem3.ForeColor = System.Drawing.Color.White;
            this.lblLowItem3.Location = new System.Drawing.Point(18, 130);
            this.lblLowItem3.Name = "lblLowItem3";
            this.lblLowItem3.Size = new System.Drawing.Size(205, 28);
            this.lblLowItem3.TabIndex = 3;
            this.lblLowItem3.Text = "Corned Beef     Stock: 4";
            // 
            // lblLowBadge1
            // 
            this.lblLowBadge1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(38)))), ((int)(((byte)(17)))));
            this.lblLowBadge1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblLowBadge1.Location = new System.Drawing.Point(246, 91);
            this.lblLowBadge1.Name = "lblLowBadge1";
            this.lblLowBadge1.Size = new System.Drawing.Size(72, 24);
            this.lblLowBadge1.TabIndex = 4;
            this.lblLowBadge1.Text = "LOW";
            this.lblLowBadge1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowItem2
            // 
            this.lblLowItem2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLowItem2.ForeColor = System.Drawing.Color.White;
            this.lblLowItem2.Location = new System.Drawing.Point(18, 91);
            this.lblLowItem2.Name = "lblLowItem2";
            this.lblLowItem2.Size = new System.Drawing.Size(205, 28);
            this.lblLowItem2.TabIndex = 5;
            this.lblLowItem2.Text = "Eggs            Stock: 5";
            // 
            // lblCriticalBadge
            // 
            this.lblCriticalBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.lblCriticalBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.lblCriticalBadge.Location = new System.Drawing.Point(246, 52);
            this.lblCriticalBadge.Name = "lblCriticalBadge";
            this.lblCriticalBadge.Size = new System.Drawing.Size(72, 24);
            this.lblCriticalBadge.TabIndex = 6;
            this.lblCriticalBadge.Text = "CRITICAL";
            this.lblCriticalBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowItem1
            // 
            this.lblLowItem1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLowItem1.ForeColor = System.Drawing.Color.White;
            this.lblLowItem1.Location = new System.Drawing.Point(18, 52);
            this.lblLowItem1.Name = "lblLowItem1";
            this.lblLowItem1.Size = new System.Drawing.Size(205, 28);
            this.lblLowItem1.TabIndex = 7;
            this.lblLowItem1.Text = "Pancit Canton   Stock: 3";
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.White;
            this.lblLowStockTitle.Location = new System.Drawing.Point(18, 13);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(119, 20);
            this.lblLowStockTitle.TabIndex = 8;
            this.lblLowStockTitle.Text = "Low Stock Alert";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(19, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(19, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(19, 18);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 51);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(22)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(1010, 646);
            this.Controls.Add(this.panelLowStock);
            this.Controls.Add(this.panelRecentTransactions);
            this.Controls.Add(this.panelPaymentMethods);
            this.Controls.Add(this.panelSalesOverview);
            this.Controls.Add(this.panelStockCard);
            this.Controls.Add(this.panelTransactionsCard);
            this.Controls.Add(this.panelProductsCard);
            this.Controls.Add(this.panelSalesCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.panelSalesCard.ResumeLayout(false);
            this.panelSalesCard.PerformLayout();
            this.panelProductsCard.ResumeLayout(false);
            this.panelProductsCard.PerformLayout();
            this.panelTransactionsCard.ResumeLayout(false);
            this.panelTransactionsCard.PerformLayout();
            this.panelStockCard.ResumeLayout(false);
            this.panelStockCard.PerformLayout();
            this.panelSalesOverview.ResumeLayout(false);
            this.panelSalesOverview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.panelPaymentMethods.ResumeLayout(false);
            this.panelPaymentMethods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPayment)).EndInit();
            this.panelRecentTransactions.ResumeLayout(false);
            this.panelRecentTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            this.panelLowStock.ResumeLayout(false);
            this.panelLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel panelSalesCard; private System.Windows.Forms.Label lblSalesTrend; private System.Windows.Forms.Label lblSalesValue; private System.Windows.Forms.Label lblSalesTitle;         private System.Windows.Forms.Panel panelProductsCard; private System.Windows.Forms.Label lblProductsTrend; private System.Windows.Forms.Label lblProductsValue; private System.Windows.Forms.Label lblProductsTitle;         private System.Windows.Forms.Panel panelTransactionsCard; private System.Windows.Forms.Label lblTransactionsTrend; private System.Windows.Forms.Label lblTransactionsValue; private System.Windows.Forms.Label lblTransactionsTitle;         private System.Windows.Forms.Panel panelStockCard; private System.Windows.Forms.Label lblStockTrend; private System.Windows.Forms.Label lblStockValue; private System.Windows.Forms.Label lblStockTitle;         private System.Windows.Forms.Panel panelSalesOverview; private System.Windows.Forms.ComboBox cmbPeriod; private System.Windows.Forms.DataVisualization.Charting.Chart chartSales; private System.Windows.Forms.Label lblSalesOverviewTitle;
        private System.Windows.Forms.Panel panelPaymentMethods; private System.Windows.Forms.Label lblOtherValue; private System.Windows.Forms.Label lblOther; private System.Windows.Forms.Label lblCardValue; private System.Windows.Forms.Label lblCard; private System.Windows.Forms.Label lblGcashValue; private System.Windows.Forms.Label lblGcash; private System.Windows.Forms.Label lblCashValue; private System.Windows.Forms.Label lblCash; private System.Windows.Forms.DataVisualization.Charting.Chart chartPayment; private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Panel panelRecentTransactions; private System.Windows.Forms.DataGridView dgvRecent; private System.Windows.Forms.DataGridViewTextBoxColumn colId; private System.Windows.Forms.DataGridViewTextBoxColumn colProduct; private System.Windows.Forms.DataGridViewTextBoxColumn colQty; private System.Windows.Forms.DataGridViewTextBoxColumn colTotal; private System.Windows.Forms.DataGridViewTextBoxColumn colPayment; private System.Windows.Forms.DataGridViewTextBoxColumn colTime; private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.Panel panelLowStock; private System.Windows.Forms.Label lblLowBadge3; private System.Windows.Forms.Label lblLowItem4; private System.Windows.Forms.Label lblLowBadge2; private System.Windows.Forms.Label lblLowItem3; private System.Windows.Forms.Label lblLowBadge1; private System.Windows.Forms.Label lblLowItem2; private System.Windows.Forms.Label lblCriticalBadge; private System.Windows.Forms.Label lblLowItem1; private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
