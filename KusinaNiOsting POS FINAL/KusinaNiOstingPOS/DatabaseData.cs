using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMartPOS
{
    // Shared data loaded through LINQ to SQL.
    internal static class DatabaseData
    {
        internal static readonly List<User> Users = new List<User>();
        internal static readonly List<Category> Categories = new List<Category>();
        internal static readonly List<Supplier> Suppliers = new List<Supplier>();
        internal static readonly List<MenuItem> MenuItems = new List<MenuItem>();
        internal static readonly List<ProductImage> ProductImages = new List<ProductImage>();
        internal static readonly List<Sale> Sales = new List<Sale>();
        internal static readonly List<SaleItem> SaleItems = new List<SaleItem>();
        internal static readonly List<InventoryLog> InventoryLogs = new List<InventoryLog>();
        internal static StoreSetting Settings;

        static DatabaseData() { Reload(); }

        internal static void Reload()
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                Replace(Users, db.Users.ToList());
                Replace(Categories, db.Categories.ToList());
                Replace(Suppliers, db.Suppliers.ToList());
                Replace(MenuItems, db.MenuItems.ToList());
                Replace(ProductImages, db.ProductImages.ToList());
                Replace(Sales, db.Sales.ToList());
                Replace(SaleItems, db.SaleItems.ToList());
                Replace(InventoryLogs, db.InventoryLogs.ToList());
                Settings = db.StoreSettings.FirstOrDefault();
            }
        }

        internal static void SaveMenuItem(MenuItem item, string imagePath)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                MenuItem row = item.MenuItemID == 0 ? null : db.MenuItems.FirstOrDefault(x => x.MenuItemID == item.MenuItemID);
                if (row == null) { row = new MenuItem(); db.MenuItems.InsertOnSubmit(row); }
                row.ItemCode = item.ItemCode; row.ItemName = item.ItemName; row.CategoryID = item.CategoryID;
                row.SupplierID = item.SupplierID; row.Price = item.Price; row.Stock = item.Stock;
                row.ReorderLevel = item.ReorderLevel; row.IsActive = item.IsActive;
                db.SubmitChanges();

                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    ProductImage image = db.ProductImages.FirstOrDefault(x => x.MenuItemID == row.MenuItemID && x.IsPrimary);
                    if (image == null) { image = new ProductImage { MenuItemID = row.MenuItemID, IsPrimary = true }; db.ProductImages.InsertOnSubmit(image); }
                    image.ImagePath = imagePath;
                    db.SubmitChanges();
                }
            }
            Reload();
        }

        internal static void SoftDeleteMenuItem(int id)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
                db.SetProductStatus(id, false);
            Reload();
        }

        internal static void RestoreMenuItem(int id)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
                db.SetProductStatus(id, true);
            Reload();
        }

        internal static void HardDeleteMenuItem(int id)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
                db.HardDeleteMenuItem(id);
            Reload();
        }

        internal static void SaveSupplier(Supplier supplier)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                Supplier row = supplier.SupplierID == 0 ? null : db.Suppliers.FirstOrDefault(x => x.SupplierID == supplier.SupplierID);
                if (row == null) { row = new Supplier(); db.Suppliers.InsertOnSubmit(row); }
                row.SupplierCode = supplier.SupplierCode; row.SupplierName = supplier.SupplierName;
                row.ContactNo = supplier.ContactNo; row.Supplies = supplier.Supplies;
                row.LastDeliveryDate = supplier.LastDeliveryDate; row.IsActive = supplier.IsActive;
                db.SubmitChanges();
            }
            Reload();
        }

        internal static void AdjustStock(int itemId, int change, string reason, int? userId)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                MenuItem item = db.MenuItems.First(x => x.MenuItemID == itemId);
                int oldStock = item.Stock;
                item.Stock += change;
                db.InventoryLogs.InsertOnSubmit(new InventoryLog { MenuItemID = itemId, QuantityChange = change,
                    PreviousStock = oldStock, NewStock = item.Stock, Reason = reason, LogDate = DateTime.Now, UserID = userId });
                db.SubmitChanges();
            }
            Reload();
        }

        internal static Sale SaveSale(Sale sale, IEnumerable<SaleItem> lines)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                Sale row = new Sale { TransactionNo = sale.TransactionNo, SaleDate = sale.SaleDate, UserID = sale.UserID,
                    PaymentMethod = sale.PaymentMethod, Subtotal = sale.Subtotal, TotalAmount = sale.TotalAmount,
                    CashReceived = sale.CashReceived, ChangeAmount = sale.ChangeAmount };
                db.Sales.InsertOnSubmit(row);
                db.SubmitChanges();
                foreach (SaleItem line in lines)
                {
                    MenuItem item = db.MenuItems.First(x => x.MenuItemID == line.MenuItemID);
                    int oldStock = item.Stock;
                    item.Stock -= line.Quantity;
                    db.SaleItems.InsertOnSubmit(new SaleItem { SaleID = row.SaleID, MenuItemID = line.MenuItemID,
                        Quantity = line.Quantity, UnitPrice = line.UnitPrice, Subtotal = line.Subtotal });
                    db.InventoryLogs.InsertOnSubmit(new InventoryLog { MenuItemID = line.MenuItemID,
                        QuantityChange = -line.Quantity, PreviousStock = oldStock, NewStock = item.Stock,
                        Reason = "Sale " + row.TransactionNo, LogDate = DateTime.Now, UserID = row.UserID });
                }
                db.SubmitChanges();
                sale.SaleID = row.SaleID;
            }
            Reload();
            return sale;
        }

        internal static void SaveSettings(StoreSetting settings)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                StoreSetting row = db.StoreSettings.FirstOrDefault();
                if (row == null) { row = new StoreSetting(); db.StoreSettings.InsertOnSubmit(row); }
                row.StoreName = settings.StoreName; row.ReceiptFooter = settings.ReceiptFooter;
                row.PrintReceipt = settings.PrintReceipt; row.LowStockAlerts = settings.LowStockAlerts;
                row.SoundEffects = settings.SoundEffects;
                db.SubmitChanges();
            }
            Reload();
        }

        internal static string CategoryName(int id) { Category c = Categories.FirstOrDefault(x => x.CategoryID == id); return c == null ? "Uncategorized" : c.CategoryName; }
        internal static string ImagePath(int id) { ProductImage p = ProductImages.FirstOrDefault(x => x.MenuItemID == id && x.IsPrimary); return p == null ? null : p.ImagePath; }
        internal static int NextMenuId() { return 0; }
        internal static int NextSupplierId() { return 0; }
        internal static int NextSaleId() { return 0; }

        private static void Replace<T>(List<T> target, List<T> values) { target.Clear(); target.AddRange(values); }
    }
}
