namespace GROUP_PROJECT
{
    partial class CustomerOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView gridMenu;
        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numCash;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCheckout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gridMenu = new System.Windows.Forms.DataGridView();
            this.gridCart = new System.Windows.Forms.DataGridView();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numCash = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCash)).BeginInit();
            this.SuspendLayout();
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Text = "ORDER NOW";
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMenu.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblMenu.Location = new System.Drawing.Point(26, 84);
            this.lblMenu.Text = "MENU";
            this.txtSearch.Location = new System.Drawing.Point(105, 82);
            this.txtSearch.Size = new System.Drawing.Size(310, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchMenu);
            this.gridMenu.Location = new System.Drawing.Point(28, 120);
            this.gridMenu.Size = new System.Drawing.Size(570, 420);
            this.gridMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.gridMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMenu.BackgroundColor = System.Drawing.Color.White;
            this.gridMenu.ReadOnly = true;
            this.gridMenu.AllowUserToAddRows = false;
            this.gridMenu.RowHeadersVisible = false;
            this.gridMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.numQuantity.Location = new System.Drawing.Point(28, 558);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Maximum = 100;
            this.numQuantity.Value = 1;
            this.numQuantity.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.Location = new System.Drawing.Point(145, 552);
            this.btnAdd.Size = new System.Drawing.Size(150, 38);
            this.btnAdd.Text = "ADD TO CART";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.AddToCart);
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCart.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblCart.Location = new System.Drawing.Point(630, 84);
            this.lblCart.Text = "YOUR CART";
            this.gridCart.Location = new System.Drawing.Point(632, 120);
            this.gridCart.Size = new System.Drawing.Size(535, 310);
            this.gridCart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.gridCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCart.BackgroundColor = System.Drawing.Color.White;
            this.gridCart.ReadOnly = true;
            this.gridCart.AllowUserToAddRows = false;
            this.gridCart.RowHeadersVisible = false;
            this.gridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.btnRemove.Location = new System.Drawing.Point(632, 443);
            this.btnRemove.Size = new System.Drawing.Size(130, 34);
            this.btnRemove.Text = "REMOVE ITEM";
            this.btnRemove.Click += new System.EventHandler(this.RemoveCartItem);
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(48, 70, 57);
            this.lblTotal.Location = new System.Drawing.Point(632, 493);
            this.lblTotal.Text = "TOTAL: ₱0.00";
            this.numCash.DecimalPlaces = 2;
            this.numCash.Location = new System.Drawing.Point(632, 540);
            this.numCash.Maximum = 1000000;
            this.numCash.Size = new System.Drawing.Size(180, 25);
            this.numCash.ValueChanged += new System.EventHandler(this.CashChanged);
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(832, 541);
            this.lblChange.Text = "CHANGE: ₱0.00";
            this.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCheckout.Location = new System.Drawing.Point(947, 584);
            this.btnCheckout.Size = new System.Drawing.Size(220, 48);
            this.btnCheckout.Text = "CHECKOUT";
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(77, 108, 88);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Click += new System.EventHandler(this.Checkout);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 245);
            this.ClientSize = new System.Drawing.Size(1194, 656);
            this.Controls.Add(this.lblTitle); this.Controls.Add(this.lblMenu); this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gridMenu); this.Controls.Add(this.numQuantity); this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCart); this.Controls.Add(this.gridCart); this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblTotal); this.Controls.Add(this.numCash); this.Controls.Add(this.lblChange);
            this.Controls.Add(this.btnCheckout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "CustomerOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adlaw - Order Now";
            this.Load += new System.EventHandler(this.CustomerOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
