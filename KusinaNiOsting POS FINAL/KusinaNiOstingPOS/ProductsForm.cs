using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class ProductsForm : Form
    {
        // ONE DATABASE CONTEXT FOR THIS FORM.
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        private RoundedComboBox cmbSort;
        public ProductsForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            UiStyle.RoundControl(panelToolbar, 14);
            UiStyle.AddBorder(panelToolbar, Color.FromArgb(73, 56, 46));
            UiStyle.RoundControl(btnPrimary, 10);
            UiStyle.RoundControl(btnEdit, 10);
            UiStyle.RoundControl(btnDelete, 10);
            UiStyle.AddHover(btnPrimary, Color.FromArgb(234, 88, 12), Color.FromArgb(245, 158, 11));
            UiStyle.SetCueBanner(txtSearch, "Search menu items...");
            UiStyle.PolishForm(this);
            cmbSort=UiStyle.AddToolbarSort(panelToolbar,txtSearch,"Sort: Name A–Z","Name Z–A","Price: Low to High","Price: High to Low","Stock: Low to High","Stock: High to Low","Status: Available First","Status: Unavailable First");
            cmbSort.SelectedIndexChanged+=delegate{LoadData();};

            this.Load += ProductsForm_Load;
            txtSearch.TextChanged += delegate { LoadData(); };
            dgvData.CellDoubleClick += delegate { EditSelected(); };
        }

        // LOAD PRODUCTS WHEN THE FORM OPENS

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string search = txtSearch.Text.Trim();
            int sort = cmbSort == null ? 0 : cmbSort.SelectedIndex;

            { // Shared form DataContext

                var items = db.SearchProductsList(search, sort);

                dgvData.Rows.Clear();

                foreach (ProductRow item in items)
                {
                    string status = AppConstants.StatusAvailable;

                    if (!item.IsActive)
                    {
                        status = AppConstants.StatusUnavailable;
                    }
                    else if (item.Stock <= item.ReorderLevel)
                    {
                        status = AppConstants.StatusLowStock;
                    }

                    Image thumbnail = UiStyle.LoadProductImage(item.ImagePath, 64, 64);

                    int row = dgvData.Rows.Add(
                        thumbnail,
                        item.ItemCode,
                        item.ItemName,
                        item.CategoryName,
                        "₱" + item.Price.ToString("N2"),
                        item.Stock,
                        status
                    );

                    dgvData.Rows[row].Tag = item.MenuItemID;
                }

                dgvData.ClearSelection();
            }
        }

        private int SelectedID()
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Tag == null) return 0;
            return Convert.ToInt32(dgvData.CurrentRow.Tag);
        }

        // OPEN ADD PRODUCT FORM

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            using (MenuItemEditForm form = new MenuItemEditForm())
                if (form.ShowDialog() == DialogResult.OK) LoadData();
        }

        // EDIT SELECTED PRODUCT

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void EditSelected()
        {
            int id = SelectedID();
            if (id == 0)
            {
                UiDialogs.Warning(this, "Menu Items", "Select a menu item first.");
                return;
            }

            using (MenuItemEditForm form = new MenuItemEditForm(id))
                if (form.ShowDialog() == DialogResult.OK) LoadData();
        }

        // PERMANENTLY DELETE SELECTED PRODUCT
        // CONFIRM BEFORE PERMANENT DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            HardDeleteSelected();
        }

        private void HardDeleteSelected()
        {
            int id = SelectedID();
            if (id == 0)
            {
                UiDialogs.Warning(this, "Menu Items", "Select a menu item first.");
                return;
            }
            if (!UiDialogs.Confirm(this, "Delete Product",
                "Permanently delete this product? This cannot be undone.", "DELETE"))
            {
                return;
            }
            try
            {
                { // Shared form DataContext

                    db.HardDeleteMenuItem(id);
                }
                LoadData();
                UiDialogs.Info(this, "Product Deleted", "The product was permanently deleted.");
            }
            catch (Exception ex)
            {
                UiDialogs.Warning(this, "Delete Product", ex.Message);
            }
        }

        // RELEASE THE DATABASE CONTEXT WHEN THE FORM CLOSES.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
