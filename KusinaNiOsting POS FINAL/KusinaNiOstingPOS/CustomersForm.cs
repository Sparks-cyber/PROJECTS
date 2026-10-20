using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class CustomersForm : Form
    {
        // ONE DATABASE CONTEXT FOR THIS FORM.
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        private RoundedComboBox cmbSort;
        public CustomersForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            UiStyle.PolishForm(this);
            UiStyle.RoundControl(panelToolbar, 14);
            UiStyle.AddBorder(panelToolbar, Color.FromArgb(73, 56, 46));
            UiStyle.RoundControl(btnPrimary, 10);
            UiStyle.RoundControl(btnEdit, 10);
            UiStyle.RoundControl(btnDelete, 10);
            UiStyle.AddHover(btnPrimary, Color.FromArgb(234, 88, 12), Color.FromArgb(245, 158, 11));
            UiStyle.SetCueBanner(txtSearch, "Search suppliers...");
            cmbSort=UiStyle.AddToolbarSort(panelToolbar,txtSearch,"Sort: Name A–Z","Name Z–A","Latest Delivery","Oldest Delivery");
            cmbSort.SelectedIndexChanged+=delegate{LoadData();};
            txtSearch.TextChanged += delegate { LoadData(); };
            dgvData.CellDoubleClick += delegate { EditSelected(); };
            LoadData();
        }

        private void LoadData()
        {
            string search = txtSearch.Text.Trim();
            int sort = cmbSort.SelectedIndex;

            { // Shared form DataContext

                var suppliers = db.SearchSuppliersList(search, sort);

                dgvData.Rows.Clear();

                foreach (SupplierRow supplier in suppliers)
                {
                    string date = "-";

                    if (supplier.LastDeliveryDate.HasValue)
                        date = supplier.LastDeliveryDate.Value.ToString("MMM d, yyyy");

                    int row = dgvData.Rows.Add(
                        supplier.SupplierCode,
                        supplier.SupplierName,
                        supplier.ContactNo,
                        supplier.Supplies,
                        date,
                        supplier.IsActive ? "Active" : "Inactive"
                    );

                    dgvData.Rows[row].Tag = supplier.SupplierID;
                }
            }
        }

        private int SelectedID()
        {
            return dgvData.CurrentRow != null && dgvData.CurrentRow.Tag != null ? Convert.ToInt32(dgvData.CurrentRow.Tag) : 0;
        }

        // EVENT: btnPrimary_Click - runs when the user interacts with this control.

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            using (SupplierEditForm form = new SupplierEditForm())
                if (form.ShowDialog() == DialogResult.OK) LoadData();
        }
        // EVENT: btnEdit_Click - runs when the user interacts with this control.
        private void btnEdit_Click(object sender, EventArgs e) { EditSelected(); }
        private void EditSelected()
        {
            int id = SelectedID(); if (id == 0) { UiDialogs.Warning(this, "Suppliers", "Select a supplier first."); return; }
            using (SupplierEditForm form = new SupplierEditForm(id))
                if (form.ShowDialog() == DialogResult.OK) LoadData();
        }
        // EVENT: btnDelete_Click - runs when the user interacts with this control.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = SelectedID(); if (id == 0) { UiDialogs.Warning(this, "Suppliers", "Select a supplier first."); return; }
            if (!UiDialogs.Confirm(this, "Deactivate Supplier", "Deactivate this supplier? Existing product and delivery records will be kept.","DEACTIVATE")) return;
            { // Shared form DataContext

                db.DeactivateSupplierSimple(id);
            }

            LoadData();
        }
        // RELEASE THE DATABASE CONTEXT WHEN THE FORM CLOSES.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
