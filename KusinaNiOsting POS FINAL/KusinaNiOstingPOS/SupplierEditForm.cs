using System;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class SupplierEditForm : Form
    {
        // ONE DATABASE CONTEXT FOR THIS FORM.
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();

        private int supplierID;

        public SupplierEditForm() : this(0) { }

        public SupplierEditForm(int id)
        {
            supplierID = id;
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            UiStyle.PolishForm(this);

            if (supplierID > 0)
                LoadSupplier();
        }

        private void LoadSupplier()
        {
            { // Shared form DataContext

                SupplierRow supplier = db.GetSupplierSimple(supplierID);

                if (supplier == null)
                    return;

                txtCode.Text = supplier.SupplierCode;
                txtName.Text = supplier.SupplierName;
                txtContact.Text = supplier.ContactNo;
                txtSupplies.Text = supplier.Supplies;
                chkActive.Checked = supplier.IsActive;

                if (supplier.LastDeliveryDate.HasValue)
                    dtDelivery.Value = supplier.LastDeliveryDate.Value;
            }
        }

        // EVENT: btnSave_Click - runs when the user interacts with this control.

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                UiDialogs.Warning(this, "Supplier", "Supplier code and name are required.");
                return;
            }

            { // Shared form DataContext

                if (supplierID == 0)
                {
                    db.AddSupplierSimple(
                        txtCode.Text.Trim(),
                        txtName.Text.Trim(),
                        txtContact.Text.Trim(),
                        txtSupplies.Text.Trim(),
                        dtDelivery.Value.Date,
                        chkActive.Checked
                    );
                }
                else
                {
                    db.UpdateSupplierSimple(
                        supplierID,
                        txtCode.Text.Trim(),
                        txtName.Text.Trim(),
                        txtContact.Text.Trim(),
                        txtSupplies.Text.Trim(),
                        dtDelivery.Value.Date,
                        chkActive.Checked
                    );
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        // RELEASE THE DATABASE CONTEXT WHEN THE FORM CLOSES.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
