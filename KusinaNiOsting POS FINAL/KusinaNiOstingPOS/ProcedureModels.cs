using System;
using System.Data.Linq;
using System.Linq;

namespace MiniMartPOS
{
    public class ProductRow
    {
        public int MenuItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
    }

    public class ProductEditRow
    {
        public int MenuItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
    }

    public class LookupRow
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class SupplierRow
    {
        public int SupplierID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ContactNo { get; set; }
        public string Supplies { get; set; }
        public DateTime? LastDeliveryDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class LoginRow
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }

    public partial class KusinaDataClassesDataContext
    {
        public System.Collections.Generic.List<LookupRow> LoadCategoriesList()
        {
            return ExecuteQuery<LookupRow>("EXEC LoadCategories").ToList();
        }

        public System.Collections.Generic.List<LookupRow> LoadSuppliersList()
        {
            return ExecuteQuery<LookupRow>("EXEC LoadSuppliers").ToList();
        }

        public int AddProduct(string code, string name, int categoryID, int? supplierID, decimal price, int stock, int reorder, bool active, string imagePath)
        {
            return ExecuteCommand("EXEC AddProduct {0},{1},{2},{3},{4},{5},{6},{7},{8}", code, name, categoryID, supplierID, price, stock, reorder, active, imagePath);
        }

        public int UpdateProduct(int id, string code, string name, int categoryID, int? supplierID, decimal price, int stock, int reorder, string imagePath)
        {
            return ExecuteCommand("EXEC UpdateProduct {0},{1},{2},{3},{4},{5},{6},{7},{8}", id, code, name, categoryID, supplierID, price, stock, reorder, imagePath);
        }

        public System.Collections.Generic.List<ProductRow> SearchProductsList(string search, int sort)
        {
            System.Collections.Generic.List<ProductRow> products =
                ExecuteQuery<ProductRow>("EXEC SearchProducts {0},{1}", search, sort).ToList();

            // Sort the products using simple C# conditions.
            if (sort == 1)
                products = products.OrderByDescending(item => item.ItemName).ToList();
            else if (sort == 2)
                products = products.OrderBy(item => item.Price).ToList();
            else if (sort == 3)
                products = products.OrderByDescending(item => item.Price).ToList();
            else if (sort == 4)
                products = products.OrderBy(item => item.Stock).ToList();
            else if (sort == 5)
                products = products.OrderByDescending(item => item.Stock).ToList();
            else if (sort == 6)
                products = products.OrderByDescending(item => item.IsActive).ToList();
            else if (sort == 7)
                products = products.OrderBy(item => item.IsActive).ToList();

            return products;
        }

        public System.Collections.Generic.List<SupplierRow> SearchSuppliersList(string search, int sort)
        {
            System.Collections.Generic.List<SupplierRow> suppliers =
                ExecuteQuery<SupplierRow>("EXEC SearchSuppliers {0},{1}", search, sort).ToList();

            // Sort the suppliers using simple C# conditions.
            if (sort == 1)
                suppliers = suppliers.OrderByDescending(item => item.SupplierName).ToList();
            else if (sort == 2)
                suppliers = suppliers.OrderByDescending(item => item.LastDeliveryDate).ToList();
            else if (sort == 3)
                suppliers = suppliers.OrderBy(item => item.LastDeliveryDate).ToList();

            return suppliers;
        }

        public SupplierRow GetSupplierSimple(int id)
        {
            return ExecuteQuery<SupplierRow>("EXEC GetSupplier {0}", id).FirstOrDefault();
        }

        public int AddSupplierSimple(string code, string name, string contact, string supplies, DateTime date, bool active)
        {
            return ExecuteCommand("EXEC AddSupplier {0},{1},{2},{3},{4},{5}", code, name, contact, supplies, date, active);
        }

        public int UpdateSupplierSimple(int id, string code, string name, string contact, string supplies, DateTime date, bool active)
        {
            return ExecuteCommand("EXEC UpdateSupplier {0},{1},{2},{3},{4},{5},{6}", id, code, name, contact, supplies, date, active);
        }

        public int DeactivateSupplierSimple(int id)
        {
            return ExecuteCommand("EXEC DeactivateSupplier {0}", id);
        }

        public LoginRow LoginUserSimple(string username, string passwordHash)
        {
            return ExecuteQuery<LoginRow>("EXEC LoginUser {0},{1}", username, passwordHash).FirstOrDefault();
        }
    }
}
