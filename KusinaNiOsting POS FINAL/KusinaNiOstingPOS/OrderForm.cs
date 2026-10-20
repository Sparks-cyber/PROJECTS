using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MiniMartPOS
{
    public partial class OrderForm : Form
    {
        private readonly List<CartLine> cart = new List<CartLine>();
        private readonly Dictionary<Button, int> buttonItemIds = new Dictionary<Button, int>();
        private readonly List<Button> productButtons = new List<Button>();
        private int selectedCategoryId;

        public bool HasActiveOrder { get { return cart.Count > 0; } }

        public OrderForm()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            UiStyle.RoundControl(panelProducts, 16); UiStyle.RoundControl(panelCart, 16); UiStyle.RoundControl(panelSummary, 16);
            UiStyle.AddBorder(panelProducts, Color.FromArgb(73,56,46)); UiStyle.AddBorder(panelCart, Color.FromArgb(73,56,46)); UiStyle.AddBorder(panelSummary, Color.FromArgb(73,56,46));
            UiStyle.RoundControl(btnPay, 10); UiStyle.AddHover(btnPay, Color.FromArgb(234,88,12), Color.FromArgb(245,158,11));
            UiStyle.SetCueBanner(txtSearch, "Search menu item...");
            UiStyle.PolishForm(this);
            cmbSort.Items.AddRange(new object[] { "Sort: Default", "Price: Low to High", "Price: High to Low" });
            cmbSort.SelectedIndex = 0;
            cmbSort.SelectedIndexChanged += delegate { LoadProductButtons(); };
            dgvCart.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvCart.ColumnHeadersDefaultCellStyle.BackColor;
            dgvCart.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgvCart.ColumnHeadersDefaultCellStyle.ForeColor;
            dgvCart.DefaultCellStyle.SelectionBackColor = dgvCart.DefaultCellStyle.BackColor;
            dgvCart.DefaultCellStyle.SelectionForeColor = dgvCart.DefaultCellStyle.ForeColor;
            colDecrease.DefaultCellStyle.BackColor = Color.FromArgb(76,44,30);
            colDecrease.DefaultCellStyle.ForeColor = Color.White;
            colDecrease.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76,44,30);
            colDecrease.DefaultCellStyle.SelectionForeColor = Color.White;

            InitializeProductCards();
            ConfigureCategoryButton(btnCatAll, 0); ConfigureCategoryButton(btnCatNoodles, 1); ConfigureCategoryButton(btnCatMeals, 2); ConfigureCategoryButton(btnCatCanned, 3); ConfigureCategoryButton(btnCatDrinks, 4);
            txtSearch.TextChanged += delegate { LoadProductButtons(); };
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            Resize += delegate { LayoutResponsivePanels(); };

            LayoutResponsivePanels();
            LoadProductButtons();
            RefreshCart();
        }

        private void InitializeProductCards()
        {
            productButtons.AddRange(new[] { btnP1,btnP2,btnP3,btnP4,btnP5,btnP6,btnP7,btnP8,btnP9,btnP10,btnP11,btnP12,btnP13 });
            EnsureProductCardCapacity(DatabaseData.MenuItems.Count);
            foreach(Button button in productButtons) ConfigureProductCard(button);
        }

        private void EnsureProductCardCapacity(int count)
        {
            while(productButtons.Count<count)
            {
                Button button=new Button();
                button.Name="btnProduct"+(productButtons.Count+1);
                panelProductGrid.Controls.Add(button); productButtons.Add(button);
            }
        }

        private void ConfigureProductCard(Button button)
        {
            button.BackColor=Color.FromArgb(54,43,36); button.ForeColor=Color.White;
            button.FlatStyle=FlatStyle.Flat; button.FlatAppearance.BorderSize=0;
            button.Font=new Font("Segoe UI",9f,FontStyle.Bold); button.Cursor=Cursors.Hand;
            button.UseVisualStyleBackColor=false; button.TabStop=false;
            button.Click += ProductButton_Click; button.Paint += ProductButton_Paint;
            Button captured=button;
            captured.MouseEnter += delegate { ApplyProductCardState(captured,true); };
            captured.MouseLeave += delegate { ApplyProductCardState(captured,false); };
        }

        private Button[] ProductButtons() { return productButtons.ToArray(); }

        private void ConfigureCategoryButton(Button button, int categoryId)
        {
            button.Tag=categoryId; button.FlatStyle=FlatStyle.Flat; button.FlatAppearance.BorderSize=0;
            button.UseVisualStyleBackColor=false; button.UseMnemonic=false; button.FlatAppearance.MouseDownBackColor=Color.FromArgb(194,65,12); button.FlatAppearance.MouseOverBackColor=Color.FromArgb(124,70,42);
            button.BackColor=categoryId==0?Color.FromArgb(234,88,12):Color.FromArgb(54,43,36);
            button.ForeColor=Color.White; button.Font=new Font("Segoe UI",8.5f,FontStyle.Bold);
            button.Cursor=Cursors.Hand; button.Margin=new Padding(0,0,8,0); UiStyle.RoundControl(button,8);
            button.MouseEnter += delegate { button.BackColor=(int)button.Tag==selectedCategoryId?Color.FromArgb(234,88,12):Color.FromArgb(83,58,45); };
            button.MouseLeave += delegate { RefreshCategoryStyles(); };
            button.Click += CategoryButton_Click;
        }

        private void RefreshCategoryStyles()
        {
            foreach(Button b in panelCategories.Controls.OfType<Button>())
            {
                bool selected=(int)b.Tag==selectedCategoryId;
                b.BackColor=selected?Color.FromArgb(234,88,12):Color.FromArgb(54,43,36);
                b.ForeColor=Color.White; b.FlatAppearance.MouseDownBackColor=selected?Color.FromArgb(194,65,12):Color.FromArgb(83,58,45);
                b.Invalidate();
            }
        }

        // EVENT: CategoryButton_Click - runs when the user interacts with this control.

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Button selected=(Button)sender; selectedCategoryId=(int)selected.Tag;
            RefreshCategoryStyles();
            LoadProductButtons();
        }

        private void LayoutResponsivePanels()
        {
            const int gap = 16;
            const int margin = 14;
            int usableWidth = Math.Max(1, ClientSize.Width - (margin * 2));
            int usableHeight = Math.Max(1, ClientSize.Height - (margin * 2));
            int rightWidth = Math.Min(390, Math.Max(310, (int)(usableWidth * .32)));
            if (rightWidth > usableWidth - 420) rightWidth = Math.Max(280, usableWidth - 420);
            int leftWidth = usableWidth - rightWidth - gap;
            int summaryHeight = Math.Min(210, Math.Max(190, usableHeight / 3));

            panelProducts.SetBounds(margin, margin, leftWidth, usableHeight);
            panelCart.SetBounds(margin + leftWidth + gap, margin, rightWidth, usableHeight - summaryHeight - gap);
            panelSummary.SetBounds(margin + leftWidth + gap, margin + usableHeight - summaryHeight, rightWidth, summaryHeight);

            int sortWidth=Math.Min(190,Math.Max(130,panelProducts.Width/3));
            cmbSort.SetBounds(panelProducts.Width-sortWidth-22,txtSearch.Top,sortWidth,txtSearch.Height);
            txtSearch.Width = Math.Max(120, cmbSort.Left - 30);
            int categoriesTop=txtSearch.Bottom+14;
            panelCategories.SetBounds(22,categoriesTop,Math.Max(120,panelProducts.Width-44),36);
            int gridTop=panelCategories.Bottom+14;
            panelProductGrid.SetBounds(22,gridTop,Math.Max(120,panelProducts.Width-44),Math.Max(120,panelProducts.Height-gridTop-22));
            dgvCart.Width = Math.Max(120, panelCart.Width - 36);
            dgvCart.Height = Math.Max(80, panelCart.Height - 76);
            btnPay.SetBounds(18, panelSummary.Height - 58, Math.Max(120, panelSummary.Width - 36), 42);
            lblSubtotal.Width = lblTax.Width = lblTotal.Width = Math.Max(120, panelSummary.Width - 36);

            Button[] productButtons = ProductButtons();
            const int columns = 3;
            const int cardGap = 16;
            int buttonWidth = Math.Max(130, (panelProductGrid.ClientSize.Width - 18 - (cardGap * 2)) / columns);
            int buttonHeight = Math.Max(180, Math.Min(215, buttonWidth));
            int visibleIndex=0;
            panelProductGrid.AutoScrollPosition=new Point(0,0);
            for (int i = 0; i < productButtons.Length; i++)
            {
                Button cardButton = productButtons[i];
                if(!cardButton.Visible) continue;
                int col = visibleIndex % columns, row = visibleIndex / columns;
                cardButton.SetBounds(4 + col * (buttonWidth + cardGap), 12 + row * (buttonHeight + cardGap), buttonWidth, buttonHeight);
                cardButton.TextImageRelation = TextImageRelation.Overlay;
                cardButton.UseVisualStyleBackColor = false;
                cardButton.ImageAlign = ContentAlignment.TopCenter;
                cardButton.TextAlign = ContentAlignment.MiddleCenter;
                cardButton.Padding = new Padding(6, 12, 6, 10);
                cardButton.FlatAppearance.BorderSize = 0;
                UiStyle.RoundControl(cardButton, 13);
                visibleIndex++;
            }
            int rows=Math.Max(1,(visibleIndex+columns-1)/columns);
            panelProductGrid.AutoScrollMinSize=new Size(0,24+rows*(buttonHeight+cardGap));
        }

        private void LoadProductButtons()
        {
            Button[] buttons = ProductButtons();
            buttonItemIds.Clear();

            foreach (Button button in buttons)
            {
                if (button.Image != null)
                {
                    Image oldImage = button.Image;
                    button.Image = null;
                    oldImage.Dispose();
                }
            }

                    string key = txtSearch.Text.Trim();
                    IEnumerable<MenuItem> query = DatabaseData.MenuItems
                        .Where(m => m.IsActive && m.Stock > 0 &&
                            (selectedCategoryId==0 || m.CategoryID==selectedCategoryId) &&
                            (key == "" || m.ItemName.IndexOf(key,StringComparison.OrdinalIgnoreCase)>=0 || m.ItemCode.IndexOf(key,StringComparison.OrdinalIgnoreCase)>=0));
                    if(cmbSort.SelectedIndex==1) query=query.OrderBy(m=>m.Price).ThenBy(m=>m.ItemName);
                    else if(cmbSort.SelectedIndex==2) query=query.OrderByDescending(m=>m.Price).ThenBy(m=>m.ItemName);
                    else query=query.OrderBy(m=>m.CategoryID).ThenBy(m=>m.ItemName);
                    List<MenuItem> items=query.ToList();

                    for (int i = 0; i < buttons.Length; i++)
                    {
                        Button button = buttons[i];

                        if (i < items.Count)
                        {
                            MenuItem item = items[i];
                            ProductImage productImage = DatabaseData.ProductImages.FirstOrDefault(p =>
                                p.MenuItemID == item.MenuItemID && p.IsPrimary);

                            button.Text = "";
                            button.Enabled = true;
                            button.Visible = true;
                            button.BackColor = Color.FromArgb(54,43,36);
                            buttonItemIds[button] = item.MenuItemID;

                            button.TextAlign = ContentAlignment.MiddleCenter;
                            button.ImageAlign = ContentAlignment.TopCenter;
                            button.TextImageRelation = TextImageRelation.Overlay;
                            button.Padding = new Padding(6, 12, 6, 10);

                            if (productImage != null)
                                button.Image = UiStyle.LoadProductImage(productImage.ImagePath, 96, 96);
                        }
                        else
                        {
                            button.Text = "";
                            button.Enabled = false;
                            button.Visible = false;
                            button.TextAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                    LayoutResponsivePanels();
        }

        // EVENT: ProductButton_Click - runs when the user interacts with this control.

        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null || !buttonItemIds.ContainsKey(button)) return;
            int id = buttonItemIds[button];

                MenuItem item = DatabaseData.MenuItems.FirstOrDefault(m => m.MenuItemID == id && m.IsActive);
                if (item == null || item.Stock <= 0) { UiDialogs.Warning(this, "Out of Stock", "This item is currently out of stock."); LoadProductButtons(); return; }

                CartLine line = cart.FirstOrDefault(c => c.MenuItemID == id);
                if (line == null)
                {
                    cart.Add(new CartLine { MenuItemID = item.MenuItemID, ItemName = item.ItemName, Price = item.Price, Quantity = 1, AvailableStock = item.Stock });
                }
                else
                {
                    if (line.Quantity >= item.Stock) { UiDialogs.Warning(this, "Stock Limit", "You cannot add more than the available stock."); return; }
                    line.Quantity++;
                    line.AvailableStock = item.Stock;
                }
            RefreshCart();
        }

        // EVENT: ProductButton_Paint - runs when the user interacts with this control.

        private void ProductButton_Paint(object sender, PaintEventArgs e)
        {
            Button button=sender as Button;
            if(button==null || !buttonItemIds.ContainsKey(button)) return;
            int itemId=buttonItemIds[button];
            MenuItem item=DatabaseData.MenuItems.First(x=>x.MenuItemID==itemId);
            CartLine line=cart.FirstOrDefault(x=>x.MenuItemID==itemId);
            bool selected=line!=null && line.Quantity>0;
            e.Graphics.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color border=selected?Color.FromArgb(249,115,22):Color.FromArgb(82,62,50);
            using(Pen borderPen=new Pen(border,selected?2f:1f))
                e.Graphics.DrawRoundedRectangleCompat(borderPen,new RectangleF(2f,2f,button.Width-5f,button.Height-5f),11f);
            int reserved=line==null?0:line.Quantity;
            int left=Math.Max(0,item.Stock-reserved);
            int nameY=Math.Max(100,button.Height-82);
            RectangleF nameBox=new RectangleF(10,nameY,button.Width-20,35);
            using(Font nameFont=new Font("Segoe UI",8.7f,FontStyle.Bold))
            using(SolidBrush nameBrush=new SolidBrush(Color.White))
            using(StringFormat center=new StringFormat{Alignment=StringAlignment.Center,LineAlignment=StringAlignment.Center,Trimming=StringTrimming.EllipsisWord})
                e.Graphics.DrawString(item.ItemName,nameFont,nameBrush,nameBox,center);
            using(Font priceFont=new Font("Segoe UI",9f,FontStyle.Bold))
            using(SolidBrush priceBrush=new SolidBrush(Color.FromArgb(251,146,60)))
                e.Graphics.DrawString("₱"+item.Price.ToString("N2"),priceFont,priceBrush,10,button.Height-36);
            Color stockColor=left<=item.ReorderLevel?Color.FromArgb(251,146,60):Color.FromArgb(190,178,170);
            using(Font stockFont=new Font("Segoe UI",7.8f,FontStyle.Regular))
            using(SolidBrush stockBrush=new SolidBrush(stockColor))
            using(StringFormat right=new StringFormat{Alignment=StringAlignment.Far})
                e.Graphics.DrawString(left+" left",stockFont,stockBrush,new RectangleF(button.Width-86,button.Height-33,74,20),right);
            if(!selected) return;
            int diameter=34; Rectangle badge=new Rectangle(button.ClientSize.Width-diameter-9,9,diameter,diameter);
            using(SolidBrush fill=new SolidBrush(Color.FromArgb(249,115,22)))e.Graphics.FillEllipse(fill,badge);
            using(Pen outline=new Pen(Color.FromArgb(255,205,170),1.3f))e.Graphics.DrawEllipse(outline,badge);
            using(Font font=new Font("Segoe UI",9f,FontStyle.Bold))
            using(SolidBrush textBrush=new SolidBrush(Color.White))
            using(StringFormat format=new StringFormat{Alignment=StringAlignment.Center,LineAlignment=StringAlignment.Center})
                e.Graphics.DrawString("×"+line.Quantity,font,textBrush,badge,format);
        }

        private void ApplyProductCardState(Button button, bool hovering)
        {
            int id;
            if(button==null || !buttonItemIds.TryGetValue(button,out id)) return;
            bool selected=cart.Any(x=>x.MenuItemID==id);
            button.BackColor=selected
                ? (hovering?Color.FromArgb(132,72,42):Color.FromArgb(112,63,38))
                : (hovering?Color.FromArgb(68,53,44):Color.FromArgb(54,43,36));
            button.Invalidate();
        }

        // EVENT: dgvCart_CellContentClick - runs when the user interacts with this control.

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0 || e.ColumnIndex!=colDecrease.Index || e.RowIndex>=cart.Count) return;
            CartLine line=cart[e.RowIndex]; line.Quantity--;
            if(line.Quantity<=0) cart.RemoveAt(e.RowIndex);
            RefreshCart();
        }

        private void RefreshCart()
        {
            dgvCart.Rows.Clear();
            foreach (CartLine line in cart)
                dgvCart.Rows.Add(line.ItemName, line.Quantity, "₱" + line.Price.ToString("N2"), "₱" + line.Total.ToString("N2"));
            dgvCart.ClearSelection();
            dgvCart.CurrentCell = null;

            decimal subtotal = cart.Sum(c => c.Total);
            lblSubtotal.Text = "Subtotal                                      ₱" + subtotal.ToString("N2");
            lblTax.Text = "Tax                                                ₱0.00";
            lblTotal.Text = "Total                                        ₱" + subtotal.ToString("N2");
            foreach(KeyValuePair<Button,int> pair in buttonItemIds)
            {
                CartLine selectedLine=cart.FirstOrDefault(x=>x.MenuItemID==pair.Value);
                bool selected=selectedLine!=null;
                MenuItem item=DatabaseData.MenuItems.First(x=>x.MenuItemID==pair.Value);
                int left=Math.Max(0,item.Stock-(selected?selectedLine.Quantity:0));
                pair.Key.Text="";
                pair.Key.BackColor=selected?Color.FromArgb(112,63,38):Color.FromArgb(54,43,36);
                pair.Key.Invalidate();
            }
            RefreshCategoryStyles();
        }

        // EVENT: btnPay_Click - runs when the user interacts with this control.

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0) { UiDialogs.Warning(this, "Empty Order", "Choose at least one menu item before proceeding to payment."); return; }
            decimal total = cart.Sum(c => c.Total);

            using (PaymentForm payment = new PaymentForm(total))
            {
                if (payment.ShowDialog() != DialogResult.OK) return;

                foreach (CartLine line in cart)
                {
                    MenuItem check = DatabaseData.MenuItems.First(m => m.MenuItemID == line.MenuItemID);
                    if (check.Stock < line.Quantity)
                    {
                        UiDialogs.Warning(this, "Stock Updated", check.ItemName + " now has only " + check.Stock + " left. Please review the order and try again.");
                        LoadProductButtons(); return;
                    }
                }

                        int saleUserId = Session.CurrentUserID;
                        if (saleUserId <= 0)
                        {
                            User kioskUser = DatabaseData.Users.First(u => u.IsActive);
                            saleUserId = kioskUser.UserID;
                        }

                        Sale sale = new Sale
                        {
                            TransactionNo = "TRX-" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                            SaleDate = DateTime.Now,
                            UserID = saleUserId,
                            PaymentMethod = payment.PaymentMethod,
                            Subtotal = total,
                            TotalAmount = total,
                            CashReceived = payment.AmountReceived,
                            ChangeAmount = payment.ChangeAmount
                        };
                        List<SaleItem> saleLines = new List<SaleItem>();
                        foreach (CartLine line in cart)
                        {
                            saleLines.Add(new SaleItem
                            {
                                MenuItemID = line.MenuItemID,
                                Quantity = line.Quantity,
                                UnitPrice = line.Price,
                                Subtotal = line.Total
                            });
                        }
                        DatabaseData.SaveSale(sale, saleLines);
                        if (DatabaseData.Settings == null || DatabaseData.Settings.PrintReceipt)
                        {
                            using (ReceiptForm receipt = new ReceiptForm(sale)) receipt.ShowDialog(this);
                        }
                        else
                        {
                            UiDialogs.Info(this, "Order Confirmed", "Payment received successfully.\n\nTransaction: " + sale.TransactionNo + "\nTotal: ₱" + total.ToString("N2") + "\nChange: ₱" + payment.ChangeAmount.ToString("N2"));
                        }

                    cart.Clear();
                    txtSearch.Clear();
                    RefreshCart();
                    LoadProductButtons();
            }
        }
    }
}
