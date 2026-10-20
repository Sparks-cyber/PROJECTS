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
            return SearchProducts(search, sort).ToList();
        }

        public System.Collections.Generic.List<SupplierRow> SearchSuppliersList(string search, int sort)
        {
            return SearchSuppliers(search, sort).ToList();
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
