using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class TransactionsForm : Form
    {
        private readonly KusinaDataClassesDataContext db = new KusinaDataClassesDataContext();
        private RoundedComboBox cmbSort;
        public TransactionsForm()
        {
            InitializeComponent();
            UiStyle.RoundControl(panelToolbar, 14);
            UiStyle.AddBorder(panelToolbar, Color.FromArgb(73, 56, 46));
            UiStyle.RoundControl(btnPrimary, 10);
            UiStyle.AddHover(btnPrimary, Color.FromArgb(234, 88, 12), Color.FromArgb(245, 158, 11));
            UiStyle.SetCueBanner(txtSearch, "Search transactions...");
            cmbSort=UiStyle.AddToolbarSort(panelToolbar,txtSearch,"Sort: Newest First","Oldest First","Total: High to Low","Total: Low to High");
            cmbSort.SelectedIndexChanged+=delegate{LoadData();};
            txtSearch.TextChanged += delegate { LoadData(); };
            dgvData.CellDoubleClick += delegate { OpenDetails(); };
            LoadData();
        }

        private void LoadData()
        {
            string key = txtSearch.Text.Trim();
            List<SP_LoadSalesResult> sales =
                db.SP_LoadSales(key, cmbSort.SelectedIndex).ToList();

            // Sort sales using simple C# conditions.
            if (cmbSort.SelectedIndex == 1)
                sales = sales.OrderBy(item => item.SaleDate).ToList();
            else if (cmbSort.SelectedIndex == 2)
                sales = sales.OrderByDescending(item => item.TotalAmount).ToList();
            else if (cmbSort.SelectedIndex == 3)
                sales = sales.OrderBy(item => item.TotalAmount).ToList();

            List<SaleItem> saleItems = db.SaleItems.ToList();
            dgvData.Rows.Clear();
            foreach (SP_LoadSalesResult sale in sales)
            {
                // Count all quantities included in this sale.
                sale.ItemCount = 0;
                foreach (SaleItem item in saleItems)
                {
                    if (item.SaleID == sale.SaleID)
                        sale.ItemCount += item.Quantity;
                }

                int row = dgvData.Rows.Add(sale.TransactionNo,
                    sale.SaleDate.ToString("MMM d, yyyy h:mm tt"), sale.ItemCount,
                    sale.PaymentMethod, "₱" + sale.TotalAmount.ToString("N2"), sale.Cashier);
                dgvData.Rows[row].Tag = sale.SaleID;
            }
        }

        // EVENT: btnPrimary_Click - runs when the user interacts with this control.

        private void btnPrimary_Click(object sender, EventArgs e) { OpenDetails(); }
        private void OpenDetails()
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Tag == null) { UiDialogs.Warning(this, "Transactions", "Select a transaction first."); return; }
            using (TransactionDetailsForm form = new TransactionDetailsForm(Convert.ToInt32(dgvData.CurrentRow.Tag))) form.ShowDialog();
        }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        db.Dispose();
        base.OnFormClosed(e);
    }
}
