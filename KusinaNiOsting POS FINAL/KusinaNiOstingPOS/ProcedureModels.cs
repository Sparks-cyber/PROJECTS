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

    public partial class KusinaDataClassesDataContext
    {
        public System.Collections.Generic.List<LookupRow> LoadCategoriesList()
        {
            return LoadCategories().ToList();
        }

        public System.Collections.Generic.List<LookupRow> LoadSuppliersList()
        {
            return LoadSuppliers().ToList();
        }

        public System.Collections.Generic.List<ProductRow> SearchProductsList(string search, int sort)
        {
            System.Collections.Generic.List<ProductRow> products =
                SearchProducts(search, sort).ToList();

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
                SearchSuppliers(search, sort).ToList();

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
            return GetSupplier(id).FirstOrDefault();
        }

        public ProductEditRow GetProductSimple(int id)
        {
            return GetProduct(id).FirstOrDefault();
        }

        public int AddSupplierSimple(string code, string name, string contact, string supplies, DateTime date, bool active)
        {
            return AddSupplier(code, name, contact, supplies, date, active);
        }

        public int UpdateSupplierSimple(int id, string code, string name, string contact, string supplies, DateTime date, bool active)
        {
            return UpdateSupplier(id, code, name, contact, supplies, date, active);
        }

        public int DeactivateSupplierSimple(int id)
        {
            return DeactivateSupplier(id);
        }

    }
}
