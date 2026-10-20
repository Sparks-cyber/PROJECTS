using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class InventoryForm : Form
    {
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();
        private RoundedComboBox cmbSort;
        public InventoryForm()
        {
            InitializeComponent();
            UiStyle.RoundControl(panelToolbar, 14);
            UiStyle.AddBorder(panelToolbar, Color.FromArgb(73, 56, 46));
            UiStyle.RoundControl(btnPrimary, 10);
            UiStyle.AddHover(btnPrimary, Color.FromArgb(234, 88, 12), Color.FromArgb(245, 158, 11));
            UiStyle.SetCueBanner(txtSearch, "Search inventory...");
            cmbSort=UiStyle.AddToolbarSort(panelToolbar,txtSearch,"Sort: Stock Low First","Stock High First","Name A–Z","Name Z–A","Supplier A–Z");
            cmbSort.SelectedIndexChanged+=delegate{LoadData();};
            txtSearch.TextChanged += delegate { LoadData(); };
            LoadData();
        }

        private void LoadData()
        {
            string key = txtSearch.Text.Trim();
            List<SP_LoadInventoryResult> items =
                db.SP_LoadInventory(key, cmbSort.SelectedIndex).ToList();

            dgvData.Rows.Clear();
            foreach (SP_LoadInventoryResult item in items)
            {
                if (string.IsNullOrWhiteSpace(item.SupplierName))
                    item.SupplierName = "-";

                // Show a simple stock status.
                if (item.Stock <= item.ReorderLevel)
                    item.StockStatus = AppConstants.StockLow;
                else
                    item.StockStatus = AppConstants.StockGood;

                int row = dgvData.Rows.Add(item.ItemName, item.Stock, item.ReorderLevel,
                    item.SupplierName, item.StockStatus);
                dgvData.Rows[row].Tag = item.MenuItemID;
            }
        }

        // EVENT: btnPrimary_Click - runs when the user interacts with this control.

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Tag == null)
            {
                UiDialogs.Warning(this, "Inventory", "Select an inventory item first.");
                return;
            }
            int id = Convert.ToInt32(dgvData.CurrentRow.Tag);
            using (StockAdjustForm form = new StockAdjustForm(id))
                if (form.ShowDialog() == DialogResult.OK) LoadData();
        }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        db.Dispose();
        base.OnFormClosed(e);
    }
}
