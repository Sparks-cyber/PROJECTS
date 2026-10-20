using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class Products : Form
    {
        private readonly AdlawDataContext db = new AdlawDataContext();
        private DataGridView grid;
        private bool showingDeletedProducts;
        private Form openMenuForm;

        public Products()
        {
            InitializeComponent();

            SetupUI();

            button1.Click += Dashboard_Click;
            btnneworder.Click += NewOrder_Click;
            button3.Click += ProductsMenu_Click;
            button4.Click += Logout_Click;

            cboStatus.SelectedIndexChanged += StatusChanged;
            btnEdit.Click += EditSelectedProduct;
            btnStatus.Click += ChangeSelectedStatus;
            btnHardDelete.Click += HardDeleteSelectedProduct;

            cboStatus.SelectedIndex = 0;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            // Load the active products.
            Retrieve();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the global database context when the form closes.
            CloseMenuForm();
            db.Dispose();
            base.OnFormClosed(e);
        }

        private void Retrieve()
        {
            // RETRIEVE
            DisplayProducts(
                db.Adlaw_RetrieveProducts().ToList()
            );
        }

        private void Search(object sender, EventArgs e)
        {
            // Filter the current product list using the search text.
            if (showingDeletedProducts)
            {
                System.Collections.Generic.List<ProductResult> products =
                    db.Adlaw_RetrieveDeletedProducts().ToList();
                System.Collections.Generic.List<ProductResult> filteredProducts =
                    new System.Collections.Generic.List<ProductResult>();
                string searchText = textBox1.Text.Trim().ToLower();

                foreach (ProductResult product in products)
                {
                    if (product.ItemCode.ToLower().Contains(searchText) ||
                        product.ItemName.ToLower().Contains(searchText))
                    {
                        filteredProducts.Add(product);
                    }
                }

                DisplayProducts(filteredProducts);
                return;
            }

            // SEARCH
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DisplayProducts(
                    db.Adlaw_RetrieveProducts().ToList()
                );
            }
            else
            {
                DisplayProducts(
                    db.Adlaw_SearchProducts(
                        textBox1.Text.Trim()
                    ).ToList()
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open the form for adding a product.
            using (AddProductForm add = new AddProductForm())
            {
                if (add.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                // ADD
                db.Adlaw_AddProduct(
                    add.ItemName,
                    add.CategoryID,
                    add.Price,
                    add.Stock,
                    add.ImagePath
                );

                Retrieve();

                MessageBox.Show(
                    "Product added successfully.",
                    "Adlaw POS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            // Show inventory inside the main content panel.
            SetSelectedMenu(button1);
            OpenMenuForm(new InventoryForm(), "Inventory");
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            // Show sales inside the main content panel.
            SetSelectedMenu(btnneworder);
            OpenMenuForm(new SalesForm(), "Sales Report");
        }

        private void ProductsMenu_Click(object sender, EventArgs e)
        {
            // Return to product management.
            SetSelectedMenu(button3);
            CloseMenuForm();
            label1.Text = "Products";
            SetProductToolsVisible(true);
            panel3.Padding = new Padding(15);
            grid.Visible = true;
            grid.BringToFront();
            UpdateProductView();
        }

        private void OpenMenuForm(Form menuForm, string title)
        {
            // Place the selected menu form inside the shared content panel.
            CloseMenuForm();
            openMenuForm = menuForm;
            label1.Text = title;
            SetProductToolsVisible(false);
            panel3.Padding = new Padding(0);
            grid.Visible = false;

            openMenuForm.TopLevel = false;
            openMenuForm.FormBorderStyle = FormBorderStyle.None;
            openMenuForm.MinimumSize = Size.Empty;
            openMenuForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(openMenuForm);
            openMenuForm.BringToFront();
            openMenuForm.Show();
        }

        private void CloseMenuForm()
        {
            // Close the current embedded menu before showing another one.
            if (openMenuForm != null)
            {
                openMenuForm.Close();
                openMenuForm.Dispose();
                openMenuForm = null;
            }
        }

        private void SetProductToolsVisible(bool visible)
        {
            // Show product controls only on the Products menu.
            panel2.Visible = visible;
            lblSearch.Visible = visible;
            textBox1.Visible = visible;
            lblStatus.Visible = visible;
            cboStatus.Visible = visible;
            btnEdit.Visible = visible;
            btnStatus.Visible = visible;
            btnadd.Visible = visible;

            if (!visible)
                btnHardDelete.Visible = false;
            else if (showingDeletedProducts)
                btnHardDelete.Visible = true;
        }

        private void SetSelectedMenu(Button selectedButton)
        {
            // Highlight only the active sidebar menu.
            button1.BackColor = Color.FromArgb(239, 243, 240);
            button1.ForeColor = Color.FromArgb(48, 70, 57);
            btnneworder.BackColor = Color.FromArgb(239, 243, 240);
            btnneworder.ForeColor = Color.FromArgb(48, 70, 57);
            button3.BackColor = Color.FromArgb(239, 243, 240);
            button3.ForeColor = Color.FromArgb(48, 70, 57);

            selectedButton.BackColor = Color.FromArgb(77, 108, 88);
            selectedButton.ForeColor = Color.White;
        }

        private void StatusChanged(object sender, EventArgs e)
        {
            // Show products based on the selected availability status.
            if (cboStatus.SelectedIndex == 1)
                showingDeletedProducts = true;
            else
                showingDeletedProducts = false;

            UpdateProductView();
        }

        private void UpdateProductView()
        {
            textBox1.Clear();
            btnadd.Enabled = !showingDeletedProducts;
            btnEdit.Enabled = !showingDeletedProducts;
            btnHardDelete.Visible = showingDeletedProducts;

            if (showingDeletedProducts)
            {
                btnStatus.Text = "SET AVAILABLE";
                DisplayProducts(db.Adlaw_RetrieveDeletedProducts().ToList());
            }
            else
            {
                btnStatus.Text = "SET UNAVAILABLE";
                Retrieve();
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            // Confirm before logging out.
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Adlaw POS",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                // Closing returns control to the original login form.
                this.Close();
            }
        }

        private void SetupUI()
        {
            textBox1.TextChanged += Search;

            SetupGrid();
        }

        private void SetupGrid()
        {
            grid = new DataGridView();

            grid.Dock = DockStyle.Fill;

            grid.AutoGenerateColumns = false;

            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;

            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.MultiSelect = false;

            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;

            grid.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            grid.GridColor =
                Color.FromArgb(220, 225, 220);

            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersHeight = 45;
            grid.RowTemplate.Height = 70;

            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(77, 108, 88);

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(77, 108, 88);

            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;


            grid.DefaultCellStyle.BackColor =
                Color.White;

            grid.DefaultCellStyle.ForeColor =
                Color.FromArgb(45, 55, 48);

            grid.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F
                );

            grid.DefaultCellStyle.Padding =
                new Padding(6);

            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(225, 237, 229);

            grid.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(48, 70, 57);


            DataGridViewImageColumn imageColumn =
                new DataGridViewImageColumn();

            imageColumn.Name = "ProductImage";
            imageColumn.HeaderText = "IMAGE";
            imageColumn.FillWeight = 60;

            imageColumn.ImageLayout =
                DataGridViewImageCellLayout.Zoom;


            DataGridViewTextBoxColumn codeColumn =
                new DataGridViewTextBoxColumn();

            codeColumn.Name = "ItemCode";
            codeColumn.HeaderText = "ITEM CODE";
            codeColumn.FillWeight = 80;


            DataGridViewTextBoxColumn nameColumn =
                new DataGridViewTextBoxColumn();

            nameColumn.Name = "ItemName";
            nameColumn.HeaderText = "ITEM NAME";
            nameColumn.FillWeight = 140;


            DataGridViewTextBoxColumn categoryColumn =
                new DataGridViewTextBoxColumn();

            categoryColumn.Name = "Category";
            categoryColumn.HeaderText = "CATEGORY";
            categoryColumn.FillWeight = 90;


            DataGridViewTextBoxColumn priceColumn =
                new DataGridViewTextBoxColumn();

            priceColumn.Name = "Price";
            priceColumn.HeaderText = "PRICE";
            priceColumn.FillWeight = 70;

            priceColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            priceColumn.DefaultCellStyle.Format = "₱#,##0.00";


            DataGridViewTextBoxColumn stockColumn =
                new DataGridViewTextBoxColumn();

            stockColumn.Name = "Stock";
            stockColumn.HeaderText = "STOCK";
            stockColumn.FillWeight = 60;

            stockColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ProductID";
            idColumn.Visible = false;

            DataGridViewTextBoxColumn categoryIdColumn = new DataGridViewTextBoxColumn();
            categoryIdColumn.Name = "CategoryID";
            categoryIdColumn.Visible = false;

            DataGridViewTextBoxColumn imagePathColumn = new DataGridViewTextBoxColumn();
            imagePathColumn.Name = "ImagePath";
            imagePathColumn.Visible = false;

            grid.Columns.Add(imageColumn);
            grid.Columns.Add(codeColumn);
            grid.Columns.Add(nameColumn);
            grid.Columns.Add(categoryColumn);
            grid.Columns.Add(priceColumn);
            grid.Columns.Add(stockColumn);
            grid.Columns.Add(idColumn);
            grid.Columns.Add(categoryIdColumn);
            grid.Columns.Add(imagePathColumn);


            panel3.Padding =
                new Padding(15);

            panel3.BackColor =
                Color.FromArgb(245, 247, 245);

            panel3.Controls.Add(grid);

            grid.BringToFront();
            grid.ClearSelection();
        }

        private void DisplayProducts(
            System.Collections.Generic.List<ProductResult> products)
        {
            grid.Rows.Clear();

            foreach (ProductResult product in products)
            {
                Image productImage = null;

                string filePath;
                if (Path.IsPathRooted(product.ImagePath))
                    filePath = product.ImagePath;
                else
                {
                    string imagePath = product.ImagePath;
                    if (imagePath == null)
                        imagePath = "";
                    filePath = Path.Combine(Application.StartupPath, imagePath);
                }

                if (File.Exists(filePath))
                {
                    using (Image source =
                        Image.FromFile(filePath))
                    {
                        productImage =
                            new Bitmap(
                                source,
                                new Size(55, 55)
                            );
                    }
                }

                string categoryName;

                if (product.CategoryID == 1)
                {
                    categoryName = "Coffee";
                }
                else if (product.CategoryID == 2)
                {
                    categoryName = "Matcha";
                }
                else if (product.CategoryID == 3)
                {
                    categoryName = "Non Coffee";
                }
                else
                {
                    categoryName = "Refresher";
                }

                grid.Rows.Add(
                    productImage,
                    product.ItemCode,
                    product.ItemName,
                    categoryName,
                    product.Price,
                    product.Stock,
                    product.ProductID,
                    product.CategoryID,
                    product.ImagePath
                );
            }

            grid.ClearSelection();
        }

        private DataGridViewRow GetSelectedProductRow()
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product first.", "Adlaw POS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return grid.SelectedRows[0];
        }

        private void EditSelectedProduct(object sender, EventArgs e)
        {
            // Edit the selected available product.
            DataGridViewRow row = GetSelectedProductRow();
            if (row == null)
            {
                return;
            }

            int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
            EditProduct(row.Index, productID);
        }

        private void ChangeSelectedStatus(object sender, EventArgs e)
        {
            // Change the selected product between available and unavailable.
            DataGridViewRow row = GetSelectedProductRow();
            if (row == null)
            {
                return;
            }

            int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
            if (showingDeletedProducts)
                RestoreProduct(productID);
            else
                DeleteProduct(productID, false);
        }

        private void HardDeleteSelectedProduct(object sender, EventArgs e)
        {
            // Permanently delete the selected unavailable product.
            DataGridViewRow row = GetSelectedProductRow();
            if (row == null)
            {
                return;
            }

            int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
            DeleteProduct(productID, true);
        }

        private void EditProduct(int rowIndex, int productID)
        {
            DataGridViewRow row = grid.Rows[rowIndex];
            ProductResult product = new ProductResult
            {
                ProductID = productID,
                ItemCode = Convert.ToString(row.Cells["ItemCode"].Value),
                ItemName = Convert.ToString(row.Cells["ItemName"].Value),
                CategoryID = Convert.ToInt32(row.Cells["CategoryID"].Value),
                Price = Convert.ToDecimal(row.Cells["Price"].Value),
                Stock = Convert.ToInt32(row.Cells["Stock"].Value),
                ImagePath = Convert.ToString(row.Cells["ImagePath"].Value)
            };

            using (AddProductForm edit = new AddProductForm(product))
            {
                if (edit.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                db.Adlaw_UpdateProduct(
                    productID,
                    edit.ItemCode,
                    edit.ItemName,
                    edit.CategoryID,
                    edit.Price,
                    edit.Stock,
                    edit.ImagePath);
            }

            Retrieve();
        }

        private void DeleteProduct(int productID, bool hardDelete)
        {
            string message;
            if (hardDelete)
                message = "Permanently delete this product? This cannot be undone.";
            else
                message = "Set this product as unavailable?";

            if (MessageBox.Show(message, "Adlaw POS", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            if (hardDelete)
            {
                db.Adlaw_HardDeleteProduct(productID);
                DisplayProducts(db.Adlaw_RetrieveDeletedProducts().ToList());
            }
            else
            {
                db.Adlaw_SoftDeleteProduct(productID);
                Search(null, EventArgs.Empty);
            }
        }

        private void RestoreProduct(int productID)
        {
            db.Adlaw_RestoreProduct(productID);
            Search(null, EventArgs.Empty);
        }

    }
}
