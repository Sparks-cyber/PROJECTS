using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public partial class Products : Form
    {
        private AdlawDataContext db;
        private DataGridView grid;
        private bool showingDeletedProducts;

        public Products()
        {
            InitializeComponent();

            SetupUI();

            button1.Click += Dashboard_Click;
            btnneworder.Click += NewOrder_Click;
            button5.Text = "DELETED PRODUCTS";
            button5.Click += ShowDeletedProducts;
            button4.Click += Logout_Click;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            db = new AdlawDataContext();

            Retrieve();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }

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
            if (showingDeletedProducts)
            {
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
            using (InventoryForm inventory = new InventoryForm())
            {
                inventory.ShowDialog(this);
            }

            Retrieve();
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            using (SalesForm sales = new SalesForm())
            {
                sales.ShowDialog(this);
            }

            Retrieve();
        }

        private void ShowDeletedProducts(object sender, EventArgs e)
        {
            showingDeletedProducts = !showingDeletedProducts;
            if (showingDeletedProducts)
                button5.Text = "ACTIVE PRODUCTS";
            else
                button5.Text = "DELETED PRODUCTS";
            btnadd.Enabled = !showingDeletedProducts;
            textBox1.Enabled = !showingDeletedProducts;

            if (showingDeletedProducts)
                DisplayProducts(db.Adlaw_RetrieveDeletedProducts().ToList());
            else
                DisplayProducts(db.Adlaw_RetrieveProducts().ToList());

            UpdateActionHeaders();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
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

            grid.CellContentClick += Grid_CellContentClick;


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

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.Name = "EditAction";
            editColumn.HeaderText = "EDIT";
            editColumn.Text = "EDIT";
            editColumn.UseColumnTextForButtonValue = true;
            editColumn.FillWeight = 65;

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "DeleteAction";
            deleteColumn.HeaderText = "DELETE";
            deleteColumn.Text = "SOFT DELETE";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.FillWeight = 80;


            grid.Columns.Add(imageColumn);
            grid.Columns.Add(codeColumn);
            grid.Columns.Add(nameColumn);
            grid.Columns.Add(categoryColumn);
            grid.Columns.Add(priceColumn);
            grid.Columns.Add(stockColumn);
            grid.Columns.Add(idColumn);
            grid.Columns.Add(categoryIdColumn);
            grid.Columns.Add(imagePathColumn);
            grid.Columns.Add(editColumn);
            grid.Columns.Add(deleteColumn);


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

        private void UpdateActionHeaders()
        {
            DataGridViewButtonColumn firstAction =
                (DataGridViewButtonColumn)grid.Columns["EditAction"];
            DataGridViewButtonColumn secondAction =
                (DataGridViewButtonColumn)grid.Columns["DeleteAction"];

            if (showingDeletedProducts)
            {
                firstAction.HeaderText = "RESTORE";
                firstAction.Text = "RESTORE";
                secondAction.HeaderText = "PERMANENT";
                secondAction.Text = "HARD DELETE";
            }
            else
            {
                firstAction.HeaderText = "EDIT";
                firstAction.Text = "EDIT";
                secondAction.HeaderText = "DELETE";
                secondAction.Text = "SOFT DELETE";
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string columnName = grid.Columns[e.ColumnIndex].Name;
            int productID = Convert.ToInt32(
                grid.Rows[e.RowIndex].Cells["ProductID"].Value);

            if (columnName == "EditAction")
            {
                if (showingDeletedProducts)
                {
                    RestoreProduct(productID);
                }
                else
                {
                    EditProduct(e.RowIndex, productID);
                }
            }
            else if (columnName == "DeleteAction")
            {
                DeleteProduct(productID, showingDeletedProducts);
            }
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
                message = "Move this product to deleted products?";

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
                Retrieve();
            }
        }

        private void RestoreProduct(int productID)
        {
            db.Adlaw_RestoreProduct(productID);
            DisplayProducts(db.Adlaw_RetrieveDeletedProducts().ToList());
        }

    }
}
