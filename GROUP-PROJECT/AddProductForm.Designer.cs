namespace GROUP_PROJECT
{
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblImagePath;

        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtImagePath;

        private System.Windows.Forms.ComboBox cboCategory;

        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numStock;

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblImagePath = new System.Windows.Forms.Label();

            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();

            this.cboCategory = new System.Windows.Forms.ComboBox();

            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();

            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.numPrice)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.numStock)).BeginInit();

            this.SuspendLayout();


            // HEADER
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(77, 108, 88);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.pnlHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlHeader.Location =
                new System.Drawing.Point(0, 0);

            this.pnlHeader.Name = "pnlHeader";

            this.pnlHeader.Size =
                new System.Drawing.Size(500, 95);


            // TITLE
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    19F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(30, 17);

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "ADD PRODUCT";


            // SUBTITLE
            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(225, 235, 228);

            this.lblSubtitle.Location =
                new System.Drawing.Point(33, 60);

            this.lblSubtitle.Name = "lblSubtitle";

            this.lblSubtitle.Text =
                "Add a new product to the Adlaw menu.";


            // ITEM CODE LABEL
            this.lblItemCode.AutoSize = true;

            this.lblItemCode.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblItemCode.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.lblItemCode.Location =
                new System.Drawing.Point(35, 120);

            this.lblItemCode.Text =
                "ITEM CODE (AUTO)";


            // ITEM CODE
            this.txtItemCode.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtItemCode.Location =
                new System.Drawing.Point(35, 143);

            this.txtItemCode.Name =
                "txtItemCode";

            this.txtItemCode.Size =
                new System.Drawing.Size(200, 25);

            this.txtItemCode.TabIndex = 0;


            // CATEGORY LABEL
            this.lblCategory.AutoSize = true;

            this.lblCategory.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblCategory.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.lblCategory.Location =
                new System.Drawing.Point(265, 120);

            this.lblCategory.Text =
                "CATEGORY";


            // CATEGORY
            this.cboCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboCategory.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.cboCategory.FormattingEnabled = true;

            this.cboCategory.Items.AddRange(
                new object[]
                {
                    "Coffee",
                    "Matcha",
                    "Non Coffee",
                    "Refresher"
                }
            );

            this.cboCategory.Location =
                new System.Drawing.Point(265, 143);

            this.cboCategory.Name =
                "cboCategory";

            this.cboCategory.Size =
                new System.Drawing.Size(200, 25);

            this.cboCategory.TabIndex = 1;


            // ITEM NAME LABEL
            this.lblItemName.AutoSize = true;

            this.lblItemName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblItemName.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.lblItemName.Location =
                new System.Drawing.Point(35, 195);

            this.lblItemName.Text =
                "ITEM NAME";


            // ITEM NAME
            this.txtItemName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtItemName.Location =
                new System.Drawing.Point(35, 218);

            this.txtItemName.Name =
                "txtItemName";

            this.txtItemName.Size =
                new System.Drawing.Size(430, 25);

            this.txtItemName.TabIndex = 2;


            // PRICE LABEL
            this.lblPrice.AutoSize = true;

            this.lblPrice.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblPrice.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.lblPrice.Location =
                new System.Drawing.Point(35, 270);

            this.lblPrice.Text =
                "PRICE";


            // PRICE
            this.numPrice.DecimalPlaces = 2;

            this.numPrice.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.numPrice.Location =
                new System.Drawing.Point(35, 293);

            this.numPrice.Maximum =
                new decimal(
                    new int[]
                    {
                        10000,
                        0,
                        0,
                        0
                    }
                );

            this.numPrice.Name =
                "numPrice";

            this.numPrice.Size =
                new System.Drawing.Size(200, 25);

            this.numPrice.TabIndex = 3;

            this.numPrice.TextAlign =
                System.Windows.Forms.HorizontalAlignment.Right;


            // STOCK LABEL
            this.lblStock.AutoSize = true;

            this.lblStock.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblStock.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.lblStock.Location =
                new System.Drawing.Point(265, 270);

            this.lblStock.Text =
                "STOCK";


            // STOCK
            this.numStock.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.numStock.Location =
                new System.Drawing.Point(265, 293);

            this.numStock.Maximum =
                new decimal(
                    new int[]
                    {
                        10000,
                        0,
                        0,
                        0
                    }
                );

            this.numStock.Name =
                "numStock";

            this.numStock.Size =
                new System.Drawing.Size(200, 25);

            this.numStock.TabIndex = 4;

            this.numStock.TextAlign =
                System.Windows.Forms.HorizontalAlignment.Right;


            // IMAGE LABEL
            this.lblImagePath.AutoSize = true;

            this.lblImagePath.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblImagePath.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.lblImagePath.Location =
                new System.Drawing.Point(35, 345);

            this.lblImagePath.Text =
                "PRODUCT IMAGE";


            // IMAGE PATH
            this.txtImagePath.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.txtImagePath.Location =
                new System.Drawing.Point(35, 368);

            this.txtImagePath.Name =
                "txtImagePath";

            this.txtImagePath.ReadOnly = true;

            this.txtImagePath.Size =
                new System.Drawing.Size(320, 23);

            this.txtImagePath.TabIndex = 5;


            // BROWSE
            this.btnBrowse.BackColor =
                System.Drawing.Color.FromArgb(235, 240, 236);

            this.btnBrowse.FlatAppearance.BorderSize = 0;

            this.btnBrowse.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBrowse.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnBrowse.ForeColor =
                System.Drawing.Color.FromArgb(48, 70, 57);

            this.btnBrowse.Location =
                new System.Drawing.Point(365, 366);

            this.btnBrowse.Name =
                "btnBrowse";

            this.btnBrowse.Size =
                new System.Drawing.Size(100, 28);

            this.btnBrowse.TabIndex = 6;

            this.btnBrowse.Text =
                "BROWSE";

            this.btnBrowse.UseVisualStyleBackColor =
                false;

            this.btnBrowse.Click +=
                new System.EventHandler(
                    this.btnBrowse_Click
                );


            // CANCEL
            this.btnCancel.BackColor =
                System.Drawing.Color.White;

            this.btnCancel.DialogResult =
                System.Windows.Forms.DialogResult.Cancel;

            this.btnCancel.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(77, 108, 88);

            this.btnCancel.FlatAppearance.BorderSize = 1;

            this.btnCancel.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCancel.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnCancel.ForeColor =
                System.Drawing.Color.FromArgb(77, 108, 88);

            this.btnCancel.Location =
                new System.Drawing.Point(245, 435);

            this.btnCancel.Name =
                "btnCancel";

            this.btnCancel.Size =
                new System.Drawing.Size(105, 40);

            this.btnCancel.TabIndex = 8;

            this.btnCancel.Text =
                "CANCEL";

            this.btnCancel.UseVisualStyleBackColor =
                false;

            this.btnCancel.Click +=
                new System.EventHandler(
                    this.btnCancel_Click
                );


            // ADD
            this.btnAdd.BackColor =
                System.Drawing.Color.FromArgb(77, 108, 88);

            this.btnAdd.FlatAppearance.BorderSize = 0;

            this.btnAdd.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAdd.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnAdd.ForeColor =
                System.Drawing.Color.White;

            this.btnAdd.Location =
                new System.Drawing.Point(360, 435);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(105, 40);

            this.btnAdd.TabIndex = 7;

            this.btnAdd.Text =
                "ADD";

            this.btnAdd.UseVisualStyleBackColor =
                false;

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click
                );


            // FORM
            this.AcceptButton =
                this.btnAdd;

            this.CancelButton =
                this.btnCancel;

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.ClientSize =
                new System.Drawing.Size(500, 510);

            this.Controls.Add(this.pnlHeader);

            this.Controls.Add(this.lblItemCode);
            this.Controls.Add(this.txtItemCode);

            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboCategory);

            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItemName);

            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);

            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numStock);

            this.Controls.Add(this.lblImagePath);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnBrowse);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);

            this.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name =
                "AddProductForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Adlaw POS - Add Product";


            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.numPrice)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.numStock)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
