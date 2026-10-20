using System.Drawing;
using System.Windows.Forms;

namespace GROUP_PROJECT
{
    public class ReceiptForm : Form
    {
        public ReceiptForm(string receipt)
        {
            Text = "Adlaw POS - Receipt";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(390, 560);
            BackColor = Color.White;
            RichTextBox text = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true,
                BorderStyle = BorderStyle.None, Font = new Font("Consolas", 10F), Text = receipt,
                BackColor = Color.White, ForeColor = Color.FromArgb(45, 55, 48) };
            Button close = new Button { Dock = DockStyle.Bottom, Height = 48, Text = "DONE",
                BackColor = Color.FromArgb(77, 108, 88), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat };
            close.Click += delegate { Close(); };
            Controls.Add(text); Controls.Add(close);
        }
    }
}
