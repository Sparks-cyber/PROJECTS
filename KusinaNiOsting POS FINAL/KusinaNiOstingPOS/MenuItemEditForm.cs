using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class MenuItemEditForm : Form
    {
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        private int itemID;
        private string selectedImage;
        private string currentImage;

        public MenuItemEditForm() : this(0) { }

        public MenuItemEditForm(int id)
        {
            itemID = id;
            InitializeComponent();

            UiStyle.RoundControl(btnBrowseImage, 9);
            UiStyle.RoundControl(btnSave, 9);
            UiStyle.RoundControl(btnCancel, 9);

            LoadCategories();
            LoadSuppliers();

            if (itemID > 0)
                LoadItem();
        }

        private void LoadCategories()
        {
            cmbCategory.DataSource = db.LoadCategoriesList();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ID";
        }

        private void LoadSuppliers()
        {
            cmbSupplier.DataSource = db.LoadSuppliersList();
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "ID";
        }

        private void LoadItem()
        {
            ProductEditRow item = db.GetProductSimple(itemID);

            if (item == null)
                return;

            txtCode.Text = item.ItemCode;
            txtName.Text = item.ItemName;
            numPrice.Value = item.Price;
            numStock.Value = item.Stock;
            numReorder.Value = item.ReorderLevel;
            chkActive.Checked = item.IsActive;

            cmbCategory.SelectedValue = item.CategoryID;

            if (item.SupplierID.HasValue)
                cmbSupplier.SelectedValue = item.SupplierID.Value;

            currentImage = item.ImagePath;

            if (currentImage != null)
                SetPreview(UiStyle.LoadProductImage(currentImage, 190, 190));
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            // Select a product image.
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            selectedImage = dialog.FileName;

            using (Image image = Image.FromFile(selectedImage))
            {
                SetPreview(new Bitmap(image));
            }
        }

        private void SetPreview(Image image)
        {
            Image oldImage = picPreview.Image;
            picPreview.Image = image;

            if (oldImage != null)
                oldImage.Dispose();
        }

        private string SaveImage(string code)
        {
            if (string.IsNullOrWhiteSpace(selectedImage))
                return currentImage;

            string folder = Path.Combine(Application.StartupPath, "Images", "Products");
            Directory.CreateDirectory(folder);

            string extension = Path.GetExtension(selectedImage);
            string fileName = code + "_" + DateTime.Now.Ticks + extension;
            string destination = Path.Combine(folder, fileName);

            File.Copy(selectedImage, destination, true);

            return "Images/Products/" + fileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save the product through its stored procedure.
            if (txtCode.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                UiDialogs.Warning(this, "Menu Item", "Code and name are required.");
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                UiDialogs.Warning(this, "Menu Item", "Select a category.");
                return;
            }

            string code = txtCode.Text.Trim();
            string name = txtName.Text.Trim();
            int categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            int? supplierID = null;

            if (cmbSupplier.SelectedValue != null)
                supplierID = Convert.ToInt32(cmbSupplier.SelectedValue);

            string imagePath = SaveImage(code);

            if (itemID == 0)
            {
                db.AddProduct(code, name, categoryID, supplierID,
                    numPrice.Value, Convert.ToInt32(numStock.Value),
                    Convert.ToInt32(numReorder.Value), chkActive.Checked, imagePath);
            }
            else
            {
                db.UpdateProduct(itemID, code, name, categoryID, supplierID,
                    numPrice.Value, Convert.ToInt32(numStock.Value),
                    Convert.ToInt32(numReorder.Value), imagePath);

                db.SetProductStatus(itemID, chkActive.Checked);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Release the database connection when the form closes.
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
