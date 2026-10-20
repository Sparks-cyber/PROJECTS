using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public enum ButtonIconKind { None, Lock, ArrowRight, Back }

    [System.ComponentModel.DefaultEvent("Click")]
    public class RoundedButton : Button
    {
        private int cornerRadius = 12;
        private ButtonIconKind iconKind;
        private bool hovering;
        private Color hoverColor = Color.Empty;
        private Color fillColor = Color.FromArgb(234, 88, 12);
        private Color outlineColor = Color.FromArgb(55, 255, 255, 255);

        [System.ComponentModel.DefaultValue(12)]
        public int CornerRadius { get { return cornerRadius; } set { cornerRadius = Math.Max(2, value); UpdateButtonRegion(); Invalidate(); } }

        [System.ComponentModel.DefaultValue(ButtonIconKind.None)]
        public ButtonIconKind IconKind { get { return iconKind; } set { iconKind = value; Invalidate(); } }

        public Color HoverColor { get { return hoverColor; } set { hoverColor = value; Invalidate(); } }
        public Color FillColor { get { return fillColor; } set { fillColor = value; Invalidate(); } }
        public Color OutlineColor { get { return outlineColor; } set { outlineColor = value; Invalidate(); } }

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnMouseEnter(EventArgs e) { hovering = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hovering = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnResize(EventArgs e) { base.OnResize(e); UpdateButtonRegion(); }

        private void UpdateButtonRegion()
        {
            if (Width < 3 || Height < 3) return;
            using (GraphicsPath path = CreateButtonPath(new RectangleF(0, 0, Width - 1, Height - 1), Math.Min(cornerRadius, Height / 2f)))
            {
                Region previous = Region;
                Region = new Region(path);
                if (previous != null) previous.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            RectangleF rect = new RectangleF(.5f, .5f, Width - 2f, Height - 2f);
            Color fill = hovering && hoverColor != Color.Empty ? hoverColor : fillColor;
            using (GraphicsPath path = CreateButtonPath(rect, Math.Min(cornerRadius, Height / 2)))
            using (SolidBrush brush = new SolidBrush(fill))
            using (Pen outline = new Pen(outlineColor, 1f))
            { e.Graphics.FillPath(brush, path); e.Graphics.DrawPath(outline, path); }

            int iconSpace = iconKind == ButtonIconKind.None ? 0 : 25;
            SizeF textSize = e.Graphics.MeasureString(Text, Font);
            float groupWidth = textSize.Width + iconSpace;
            float startX = (Width - groupWidth) / 2f;
            if (iconKind != ButtonIconKind.None) DrawIcon(e.Graphics, new RectangleF(startX, (Height - 18) / 2f, 18, 18));
            using (SolidBrush textBrush = new SolidBrush(ForeColor))
                e.Graphics.DrawString(Text, Font, textBrush, startX + iconSpace, (Height - textSize.Height) / 2f);
        }

        private static GraphicsPath CreateButtonPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath(); float d = radius * 2f;
            path.AddArc(rect.Left, rect.Top, d, d, 180, 90); path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90); path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure(); return path;
        }

        private void DrawIcon(Graphics g, RectangleF box)
        {
            using (Pen pen = new Pen(ForeColor, 1.8f))
            {
                pen.StartCap = LineCap.Round; pen.EndCap = LineCap.Round; pen.LineJoin = LineJoin.Round;
                if (iconKind == ButtonIconKind.Lock)
                {
                    g.DrawArc(pen, box.X + 4, box.Y, 10, 11, 180, 180);
                    g.DrawRoundedRectangleCompat(pen, new RectangleF(box.X + 2, box.Y + 7, 14, 10), 3);
                    g.DrawLine(pen, box.X + 9, box.Y + 11, box.X + 9, box.Y + 14);
                }
                else if (iconKind == ButtonIconKind.ArrowRight)
                {
                    g.DrawLine(pen, box.X + 2, box.Y + 9, box.X + 15, box.Y + 9);
                    g.DrawLine(pen, box.X + 10, box.Y + 4, box.X + 15, box.Y + 9);
                    g.DrawLine(pen, box.X + 10, box.Y + 14, box.X + 15, box.Y + 9);
                }
                else if (iconKind == ButtonIconKind.Back)
                {
                    g.DrawLine(pen, box.X + 3, box.Y + 9, box.X + 16, box.Y + 9);
                    g.DrawLine(pen, box.X + 3, box.Y + 9, box.X + 8, box.Y + 4);
                    g.DrawLine(pen, box.X + 3, box.Y + 9, box.X + 8, box.Y + 14);
                }
            }
        }
    }

    internal static class GraphicsExtensions
    {
        public static void DrawRoundedRectangleCompat(this Graphics graphics, Pen pen, RectangleF rect, float radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                float d = radius * 2f;
                path.AddArc(rect.Left, rect.Top, d, d, 180, 90); path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90); path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure(); graphics.DrawPath(pen, path);
            }
        }
    }

    public class RoundedComboBox : ComboBox
    {
        private int cornerRadius = 8;
        private Color borderColor = Color.FromArgb(92, 72, 59);
        public int CornerRadius { get { return cornerRadius; } set { cornerRadius = Math.Max(2, value); UpdateShape(); Invalidate(); } }
        public Color BorderColor { get { return borderColor; } set { borderColor = value; Invalidate(); } }

        public RoundedComboBox()
        {
            FlatStyle = FlatStyle.Standard;
            DrawMode = DrawMode.Normal;
        }
        protected override void OnResize(EventArgs e) { base.OnResize(e); }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Color bg = (e.State & DrawItemState.Selected) != 0 ? Color.FromArgb(109, 63, 38) : BackColor;
            using (SolidBrush b = new SolidBrush(bg)) e.Graphics.FillRectangle(b, e.Bounds);
            using (SolidBrush t = new SolidBrush(ForeColor)) e.Graphics.DrawString(GetItemText(Items[e.Index]), Font, t, e.Bounds.X + 7, e.Bounds.Y + 4);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
        private static GraphicsPath RoundedPath(RectangleF rect,float radius)
        {
            GraphicsPath path=new GraphicsPath();float d=Math.Min(radius*2f,Math.Min(rect.Width,rect.Height));
            path.AddArc(rect.Left,rect.Top,d,d,180,90);path.AddArc(rect.Right-d,rect.Top,d,d,270,90);
            path.AddArc(rect.Right-d,rect.Bottom-d,d,d,0,90);path.AddArc(rect.Left,rect.Bottom-d,d,d,90,90);path.CloseFigure();return path;
        }
        private void UpdateShape()
        {
            Region old = Region; Region = null; if (old != null) old.Dispose();
        }
    }

    public class RoundedDateTimePicker : DateTimePicker
    {
        private int cornerRadius = 8;
        private Color borderColor = Color.FromArgb(92, 72, 59);
        public int CornerRadius { get { return cornerRadius; } set { cornerRadius = Math.Max(2, value); UpdateShape(); Invalidate(); } }
        public Color BorderColor { get { return borderColor; } set { borderColor = value; Invalidate(); } }
        public RoundedDateTimePicker() { SetStyle(ControlStyles.OptimizedDoubleBuffer, true); }
        protected override void OnResize(EventArgs e) { base.OnResize(e); UpdateShape(); }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F && Width > 2 && Height > 2)
                using (Graphics g = CreateGraphics())
                using (Pen p = new Pen(borderColor, 1.2f))
                { g.SmoothingMode = SmoothingMode.AntiAlias; g.DrawRoundedRectangleCompat(p, new RectangleF(.7f, .7f, Width - 1.5f, Height - 1.5f), cornerRadius); }
        }
        private void UpdateShape()
        {
            if (Width < 3 || Height < 3) return;
            using (GraphicsPath p = new GraphicsPath())
            {
                float r = Math.Min(cornerRadius, Height / 2f), d = r * 2;
                p.AddArc(0, 0, d, d, 180, 90); p.AddArc(Width - d - 1, 0, d, d, 270, 90);
                p.AddArc(Width - d - 1, Height - d - 1, d, d, 0, 90); p.AddArc(0, Height - d - 1, d, d, 90, 90); p.CloseFigure();
                Region old = Region; Region = new Region(p); if (old != null) old.Dispose();
            }
        }
    }

    internal static class UiStyle
    {
        private const int EM_SETCUEBANNER = 0x1501;
        private static readonly Dictionary<Control, int> RoundedRadii = new Dictionary<Control, int>();
        public static readonly Color Bg = Color.FromArgb(28, 22, 19);
        public static readonly Color Surface = Color.FromArgb(39, 32, 28);
        public static readonly Color Surface2 = Color.FromArgb(54, 43, 36);
        public static readonly Color Border = Color.FromArgb(78, 61, 51);
        public static readonly Color Accent = Color.FromArgb(234, 88, 12);
        public static readonly Color AccentHover = Color.FromArgb(249, 115, 22);
        public static readonly Color Text = Color.FromArgb(248, 250, 252);
        public static readonly Color Muted = Color.FromArgb(180, 167, 159);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public static void SetCueBanner(TextBox textBox, string text)
        {
            if (textBox == null) return;
            if (!textBox.IsHandleCreated)
                textBox.HandleCreated += delegate { SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, text); };
            else SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
        }

        public static void RoundControl(Control control, int radius)
        {
            if (control == null) return;
            RoundedRadii[control] = radius;
            ApplyRound(control, radius);
            control.SizeChanged += delegate { ApplyRound(control, radius); control.Invalidate(); };
            control.Disposed += delegate { RoundedRadii.Remove(control); };
        }

        private static GraphicsPath CreateRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float maxRadius = Math.Min(rect.Width, rect.Height) / 2f;
            radius = Math.Max(1f, Math.Min(radius, maxRadius));
            float d = radius * 2f;
            path.StartFigure();
            path.AddArc(rect.Left, rect.Top, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static void ApplyRound(Control control, int radius)
        {
            if (control.Width <= 2 || control.Height <= 2) return;
            RectangleF rect = new RectangleF(0, 0, control.Width - 1f, control.Height - 1f);
            using (GraphicsPath path = CreateRoundedPath(rect, radius))
            {
                Region old = control.Region;
                control.Region = new Region(path);
                if (old != null) old.Dispose();
            }
        }

        public static void AddHover(Control control, Color normal, Color hover)
        {
            if (control == null) return;
            control.BackColor = normal;
            control.MouseEnter += delegate { if (control.Enabled) control.BackColor = hover; };
            control.MouseLeave += delegate { control.BackColor = normal; };
        }

        public static void AddBorder(Panel panel, Color borderColor)
        {
            if (panel == null) return;
            panel.Paint += delegate(object sender, PaintEventArgs e)
            {
                if (panel.Width <= 3 || panel.Height <= 3) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                float inset = 1.25f;
                RectangleF rect = new RectangleF(inset, inset, panel.Width - inset * 2f - 1f, panel.Height - inset * 2f - 1f);
                int radius; if (!RoundedRadii.TryGetValue(panel, out radius)) radius = 8;
                using (GraphicsPath path = CreateRoundedPath(rect, Math.Max(1, radius - 1)))
                using (Pen pen = new Pen(borderColor, 1.2f))
                { pen.Alignment = PenAlignment.Inset; e.Graphics.DrawPath(pen, path); }
            };
            panel.Invalidate();
        }

        public static RoundedComboBox AddToolbarSort(Panel toolbar, TextBox searchBox, params string[] options)
        {
            RoundedComboBox combo=new RoundedComboBox();
            combo.Name="cmbSort"; combo.DropDownStyle=ComboBoxStyle.DropDownList;
            combo.BackColor=Surface2; combo.ForeColor=Text; combo.BorderColor=Color.FromArgb(82,62,50);
            combo.CornerRadius=7; combo.Font=new Font("Segoe UI",9.5f,FontStyle.Regular);
            foreach(string option in options) combo.Items.Add(option); combo.SelectedIndex=0;
            int left=searchBox.Right+14, rightLimit=toolbar.ClientSize.Width-18;
            foreach(Control control in toolbar.Controls)
                if(control is Button && control.Left>searchBox.Right) rightLimit=Math.Min(rightLimit,control.Left-12);
            combo.SetBounds(left,searchBox.Top,Math.Max(120,Math.Min(190,rightLimit-left)),searchBox.Height);
            toolbar.Controls.Add(combo); combo.BringToFront(); return combo;
        }

        public static void PolishForm(Control root)
        {
            if (root == null) return;
            foreach (Control c in root.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Cursor = Cursors.Hand;
                    b.TabStop = false;
                    b.FlatAppearance.MouseDownBackColor = b.BackColor;
                    b.Font = new Font("Segoe UI", Math.Max(9f, b.Font.Size), FontStyle.Bold);
                    RoundedButton rounded = b as RoundedButton;
                    Color normal = rounded != null ? rounded.FillColor : b.BackColor;
                    Color hover = normal.R > 180 ? AccentHover : Color.FromArgb(
                        Math.Min(255, normal.R + 12), Math.Min(255, normal.G + 10), Math.Min(255, normal.B + 8));
                    if (rounded != null) { if (rounded.HoverColor == Color.Empty) rounded.HoverColor = hover; }
                    else AddHover(b, normal, hover);
                }

                TextBox tb = c as TextBox;
                if (tb != null)
                {
                    // Keep the panel's input style.
                    bool hasInputShell = tb.BorderStyle == BorderStyle.None && tb.Parent is Panel;
                    if (!hasInputShell)
                    {
                        tb.BackColor = Surface2; tb.ForeColor = Text;
                        tb.BorderStyle = BorderStyle.FixedSingle;
                    }
                    tb.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                }

                ComboBox cb = c as ComboBox;
                if (cb != null)
                { cb.BackColor = Surface2; cb.ForeColor = Text; cb.FlatStyle = FlatStyle.Standard; cb.Font = new Font("Segoe UI", 10f); }

                NumericUpDown nud = c as NumericUpDown;
                if (nud != null)
                { nud.BackColor = Surface2; nud.ForeColor = Text; nud.BorderStyle = BorderStyle.FixedSingle; nud.Font = new Font("Segoe UI", 10f); }

                DataGridView grid = c as DataGridView;
                if (grid != null) StyleDataGrid(grid);

                PolishForm(c);
            }
        }

        public static void StyleDataGrid(DataGridView grid)
        {
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Border;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Surface2;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Text;
            // Keep grid headers neutral.
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Surface2;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Text;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            grid.ColumnHeadersHeight = 38;
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(235, 228, 223);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(109, 63, 38);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.25f);
            grid.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);
            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = Math.Max(grid.RowTemplate.Height, 42);
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                DataGridViewImageColumn imageColumn = column as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageColumn.DefaultCellStyle.Padding = new Padding(10, 7, 10, 7);
                }
            }

            // Clear the active header color.
            grid.ColumnHeaderMouseClick -= KeepGridHeaderNeutral;
            grid.ColumnHeaderMouseClick += KeepGridHeaderNeutral;
            grid.DataBindingComplete -= ClearGridSelectionAfterBinding;
            grid.DataBindingComplete += ClearGridSelectionAfterBinding;
        }

        public static void PrepareEmbeddedPage(Form page)
        {
            // Hide duplicate page headings.
            Control title = page.Controls["lblTitle"];
            Control subtitle = page.Controls["lblSubtitle"];
            if (title == null || subtitle == null)
            {
                foreach (Control candidate in page.Controls)
                {
                    Label label = candidate as Label;
                    if (label == null) continue;
                    if (title == null && label.Font.Size >= 17f &&
                        string.Equals(label.Text, page.Text, StringComparison.OrdinalIgnoreCase)) title = label;
                    else if (subtitle == null && label.Font.Size <= 10f && label.Top < 70) subtitle = label;
                }
            }
            if (title == null || subtitle == null) return;

            title.Visible = false;
            subtitle.Visible = false;
            const int releasedHeaderSpace = 66;
            foreach (Control control in page.Controls)
            {
                if (control == title || control == subtitle) continue;
                if (control.Top >= releasedHeaderSpace)
                    control.Top -= releasedHeaderSpace;
            }
        }

        private static void KeepGridHeaderNeutral(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null) return;
            grid.BeginInvoke(new MethodInvoker(delegate
            {
                grid.ClearSelection();
                grid.InvalidateColumn(e.ColumnIndex);
            }));
        }

        private static void ClearGridSelectionAfterBinding(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid != null) grid.ClearSelection();
        }

        public static Image LoadProductImage(string relativePath, int maxWidth, int maxHeight)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(relativePath)) return null;
                string fixedPath = relativePath.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                string fullPath = Path.Combine(Application.StartupPath, fixedPath);
                if (!File.Exists(fullPath))
                {
                    // Fallback for local builds.
                    string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", ".."));
                    string fallback = Path.Combine(projectRoot, fixedPath);
                    if (File.Exists(fallback)) fullPath = fallback; else return null;
                }
                using (Image source = Image.FromFile(fullPath))
                {
                    double scale = Math.Min((double)maxWidth / source.Width, (double)maxHeight / source.Height);
                    int w = Math.Max(1, (int)(source.Width * scale));
                    int h = Math.Max(1, (int)(source.Height * scale));
                    Bitmap output = new Bitmap(w, h);
                    using (Graphics g = Graphics.FromImage(output))
                    {
                        g.Clear(Color.Transparent);
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.DrawImage(source, new Rectangle(0, 0, w, h));
                    }
                    return output;
                }
            }
            catch { return null; }
        }

        public static Image LoadAsset(string relativePath)
        {
            try
            {
                string fixedPath = relativePath.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                string fullPath = Path.Combine(Application.StartupPath, fixedPath);
                if (!File.Exists(fullPath))
                    fullPath = Path.Combine(Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..")), fixedPath);
                if (!File.Exists(fullPath)) return null;
                using (Image source = Image.FromFile(fullPath)) return new Bitmap(source);
            }
            catch { return null; }
        }

        public static void DrawImageCover(Graphics graphics, Image image, Rectangle bounds)
        {
            if (graphics == null || image == null || bounds.Width <= 0 || bounds.Height <= 0) return;
            float scale = Math.Max((float)bounds.Width / image.Width, (float)bounds.Height / image.Height);
            int width = (int)Math.Ceiling(image.Width * scale);
            int height = (int)Math.Ceiling(image.Height * scale);
            Rectangle destination = new Rectangle(bounds.X + (bounds.Width - width) / 2, bounds.Y + (bounds.Height - height) / 2, width, height);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.DrawImage(image, destination);
        }
    }

    internal static class UiDialogs
    {
        public static void Info(IWin32Window owner, string title, string message) { Show(owner, title, message, false, false); }
        public static void Warning(IWin32Window owner, string title, string message) { Show(owner, title, message, false, true); }
        public static void Error(IWin32Window owner, string title, string message) { Show(owner, title, message, false, true); }
        public static bool Confirm(IWin32Window owner, string title, string message) { return Confirm(owner,title,message,"YES"); }
        public static bool Confirm(IWin32Window owner, string title, string message,string actionText) { return Show(owner,title,message,true,false,actionText) == DialogResult.Yes; }

        private static DialogResult Show(IWin32Window owner, string title, string message, bool confirm, bool warn,string actionText=null)
        {
            using (Form f = new Form())
            using (Panel card = new Panel())
            using (Label icon = new Label())
            using (Label lblTitle = new Label())
            using (Label lblMessage = new Label())
            using (Button primary = new Button())
            using (Button secondary = new Button())
            {
                f.FormBorderStyle = FormBorderStyle.None;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowInTaskbar = false;
                f.BackColor = Color.FromArgb(17, 13, 11);
                f.ClientSize = new Size(440, 230);
                f.Padding = new Padding(1);

                card.Dock = DockStyle.Fill; card.BackColor = UiStyle.Surface; f.Controls.Add(card);
                UiStyle.RoundControl(card, 18); UiStyle.AddBorder(card, UiStyle.Border);

                icon.Text = warn ? "!" : (confirm ? "?" : "✓"); icon.TextAlign = ContentAlignment.MiddleCenter;
                icon.Font = new Font("Segoe UI", 16f, FontStyle.Bold); icon.ForeColor = Color.White;
                icon.BackColor = warn ? Color.FromArgb(185, 28, 28) : (confirm ? Color.FromArgb(180, 83, 9) : Color.FromArgb(5, 150, 105));
                icon.Location = new Point(26, 26); icon.Size = new Size(44, 44); card.Controls.Add(icon); UiStyle.RoundControl(icon, 22);

                lblTitle.Text = title; lblTitle.ForeColor = Color.White; lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                lblTitle.Location = new Point(86, 28); lblTitle.Size = new Size(325, 30); card.Controls.Add(lblTitle);

                lblMessage.Text = message; lblMessage.ForeColor = Color.FromArgb(210, 200, 194); lblMessage.Font = new Font("Segoe UI", 9.5f);
                lblMessage.Location = new Point(88, 64); lblMessage.Size = new Size(320, 88); card.Controls.Add(lblMessage);

                primary.Text = confirm ? (string.IsNullOrWhiteSpace(actionText)?"YES":actionText) : "OK"; primary.DialogResult = confirm ? DialogResult.Yes : DialogResult.OK;
                primary.BackColor = UiStyle.Accent; primary.ForeColor = Color.White; primary.FlatStyle = FlatStyle.Flat; primary.FlatAppearance.BorderSize = 0;
                primary.Location = new Point(294, 170); primary.Size = new Size(112, 40); card.Controls.Add(primary); UiStyle.RoundControl(primary, 10); UiStyle.AddHover(primary, UiStyle.Accent, UiStyle.AccentHover);

                if (confirm)
                {
                    secondary.Text = "CANCEL"; secondary.DialogResult = DialogResult.No;
                    secondary.BackColor = Color.FromArgb(73, 56, 46); secondary.ForeColor = Color.White; secondary.FlatStyle = FlatStyle.Flat; secondary.FlatAppearance.BorderSize = 0;
                    secondary.Location = new Point(172, 170); secondary.Size = new Size(112, 40); card.Controls.Add(secondary); UiStyle.RoundControl(secondary, 10); UiStyle.AddHover(secondary, secondary.BackColor, Color.FromArgb(92, 69, 56));
                    f.CancelButton = secondary;
                }
                f.AcceptButton = primary;
                return owner == null ? f.ShowDialog() : f.ShowDialog(owner);
            }
        }
    }
}
