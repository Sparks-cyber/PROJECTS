using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            UiStyle.PolishForm(this);
            UiStyle.RoundControl(panelStore, 16); UiStyle.RoundControl(panelPreferences, 16);
            UiStyle.AddBorder(panelStore, Color.FromArgb(73,56,46)); UiStyle.AddBorder(panelPreferences, Color.FromArgb(73,56,46));
            UiStyle.RoundControl(btnSave, 10); UiStyle.AddHover(btnSave, Color.FromArgb(234,88,12), Color.FromArgb(245,158,11));
            LoadSettings();
        }

        private void LoadSettings()
        {
                    StoreSetting s = DatabaseData.Settings;
                    if (s == null) return;
                    txtStoreName.Text = s.StoreName; txtReceiptFooter.Text = s.ReceiptFooter;
                    chkReceipt.Checked = s.PrintReceipt; chkLowStock.Checked = s.LowStockAlerts; chkSound.Checked = s.SoundEffects;
        }

        // EVENT: btnSave_Click - runs when the user interacts with this control.

        private void btnSave_Click(object sender, EventArgs e)
        {
                    StoreSetting s = DatabaseData.Settings;
                    if (s == null) { s = new StoreSetting(); DatabaseData.Settings = s; }
                    s.StoreName = txtStoreName.Text.Trim(); s.ReceiptFooter = txtReceiptFooter.Text.Trim();
                    s.PrintReceipt = chkReceipt.Checked; s.LowStockAlerts = chkLowStock.Checked; s.SoundEffects = chkSound.Checked;
                    DatabaseData.SaveSettings(s);
            UiDialogs.Info(this, "Settings Saved", "Your preferences have been saved.");
        }
    }
}
