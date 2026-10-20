using System;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class AddProductForm : Form
    {
        private bool editingProduct;

        public string ItemCode
        {
            get
            {
                if (editingProduct)
                    return txtItemCode.Text.Trim();
                else
                    return null;
            }
        }

        public string ItemName
        {
            get
            {
                return txtItemName.Text.Trim();
            }
        }

        public int CategoryID
        {
            get
            {
                return cboCategory.SelectedIndex + 1;
            }
        }

        public decimal Price
        {
            get
            {
                return numPrice.Value;
            }
        }

        public int Stock
        {
            get
            {
                return (int)numStock.Value;
            }
        }

        public string ImagePath
        {
            get
            {
                return txtImagePath.Text.Trim();
            }
        }

        public AddProductForm()
        {
            InitializeComponent();

            cboCategory.SelectedIndex = 0;
            txtItemCode.Text = "AUTO-GENERATED";
            txtItemCode.ReadOnly = true;
            txtItemCode.TabStop = false;
            txtItemCode.BackColor = System.Drawing.Color.Gainsboro;
        }

        public AddProductForm(ProductResult product)
            : this()
        {
            editingProduct = true;
            Text = "Adlaw POS - Edit Product";
            lblTitle.Text = "EDIT PRODUCT";
            lblSubtitle.Text = "Update the selected product details.";
            btnAdd.Text = "UPDATE";

            txtItemCode.Text = product.ItemCode;
            txtItemCode.ReadOnly = false;
            txtItemCode.TabStop = true;
            txtItemCode.BackColor = System.Drawing.Color.White;
            txtItemName.Text = product.ItemName;
            cboCategory.SelectedIndex = product.CategoryID - 1;
            numPrice.Value = product.Price;
            numStock.Value = product.Stock;
            txtImagePath.Text = product.ImagePath;
        }

        private void btnBrowse_Click(
            object sender,
            EventArgs e)
        {
            // Select an image for the product.
            using (OpenFileDialog dialog =
                new OpenFileDialog())
            {
                dialog.Title = "Select Product Image";

                dialog.Filter =
                    "Image Files|*.png;*.jpg;*.jpeg";

                if (dialog.ShowDialog(this) ==
                    DialogResult.OK)
                {
                    txtImagePath.Text =
                        dialog.FileName;
                }
            }
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            // Validate and submit the product details.
            if (editingProduct && ItemCode == "")
            {
                MessageBox.Show(
                    "Enter Item Code.",
                    "Adlaw POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtItemCode.Focus();
                return;
            }

            if (ItemName == "")
            {
                MessageBox.Show(
                    "Enter Item Name.",
                    "Adlaw POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtItemName.Focus();
                return;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Select a category.",
                    "Adlaw POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (Price <= 0)
            {
                MessageBox.Show(
                    "Enter a valid price.",
                    "Adlaw POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                numPrice.Focus();
                return;
            }

            if (Stock < 0)
            {
                MessageBox.Show(
                    "Enter a valid stock.",
                    "Adlaw POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                numStock.Focus();
                return;
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            // Close without saving the product.
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
