using System;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class StockAdjustForm : Form
    {
        private readonly int itemID;

        public StockAdjustForm() : this(0) { }

        public StockAdjustForm(int id)
        {
            itemID = id;
            InitializeComponent();
            LoadItem();
        }

        private void LoadItem()
        {
            MenuItem item = DatabaseData.MenuItems.First(x => x.MenuItemID == itemID);
            lblItem.Text = item.ItemName;
            lblCurrent.Text = "Current Stock: " + item.Stock;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate and save the stock adjustment.
            int change = Convert.ToInt32(numChange.Value);

            if (change == 0)
            {
                UiDialogs.Warning(this, "Adjust Stock", "Enter a quantity change.");
                return;
            }

            MenuItem item = DatabaseData.MenuItems.First(x => x.MenuItemID == itemID);
            int newStock = item.Stock + change;

            if (newStock < 0)
            {
                UiDialogs.Warning(this, "Adjust Stock", "Stock cannot be negative.");
                return;
            }

            string reason = txtReason.Text.Trim();
            if (reason == "")
                reason = "Manual adjustment";

            int? userID = null;
            if (Session.CurrentUserID > 0)
                userID = Session.CurrentUserID;

            DatabaseData.AdjustStock(itemID, change, reason, userID);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
