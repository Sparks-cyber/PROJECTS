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

        internal static void AdjustStock(int itemId, int change, string reason, int? userId)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
                db.AdjustStock(itemId, change, reason, userId);

            Reload();
        }

        internal static Sale SaveSale(Sale sale, IEnumerable<SaleItem> lines)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
            {
                CreateSaleResult savedSale = db.CreateSale(
                    sale.TransactionNo,
                    sale.SaleDate,
                    sale.UserID,
                    sale.PaymentMethod,
                    sale.Subtotal,
                    sale.TotalAmount,
                    sale.CashReceived,
                    sale.ChangeAmount).First();

                sale.SaleID = savedSale.SaleID;

                foreach (SaleItem line in lines)
                {
                    db.AddSaleItem(
                        sale.SaleID,
                        line.MenuItemID,
                        line.Quantity,
                        line.UnitPrice,
                        line.Subtotal,
                        sale.UserID);
                }
            }
            Reload();
            return sale;
        }

        internal static void SaveSettings(StoreSetting settings)
        {
            using (KusinaDataClassesDataContext db = new KusinaDataClassesDataContext())
                db.SaveSettings(settings.StoreName, settings.ReceiptFooter,
                    settings.PrintReceipt, settings.LowStockAlerts, settings.SoundEffects);

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
