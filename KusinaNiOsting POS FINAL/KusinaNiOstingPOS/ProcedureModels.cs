using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
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

    public class SaleItemRow
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class SaleDetailsRow
    {
        public int SaleID { get; set; }
        public string TransactionNo { get; set; }
        public DateTime SaleDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CashReceived { get; set; }
        public decimal ChangeAmount { get; set; }
        public string Cashier { get; set; }
    }

    public class ReportSummaryRow
    {
        public decimal DailySales { get; set; }
        public decimal WeeklySales { get; set; }
        public decimal MonthlySales { get; set; }
        public int TransactionCount { get; set; }
        public int ItemsSold { get; set; }
    }

    public class TopProductRow
    {
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalSales { get; set; }
    }

    public class DashboardSummaryRow
    {
        public decimal TodaySales { get; set; }
        public int TodayTransactions { get; set; }
        public int ActiveProducts { get; set; }
        public int LowStockCount { get; set; }
    }

    public class DailySalesRow
    {
        public DateTime SaleDay { get; set; }
        public decimal TotalSales { get; set; }
    }

    public class CategorySalesRow
    {
        public string CategoryName { get; set; }
        public decimal TotalSales { get; set; }
    }

    public class DefaultUserRow
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
    }

    public partial class KusinaDataClassesDataContext
    {
        [Function(Name = "dbo.SearchOrderProducts")]
        public ISingleResult<ProductRow> SearchOrderProducts(string search, int categoryID, int sort)
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod(),
                search, categoryID, sort);
            return (ISingleResult<ProductRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetSaleItems")]
        public ISingleResult<SaleItemRow> GetSaleItems(int saleID)
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod(), saleID);
            return (ISingleResult<SaleItemRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetSaleDetails")]
        public ISingleResult<SaleDetailsRow> GetSaleDetails(int saleID)
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod(), saleID);
            return (ISingleResult<SaleDetailsRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetReportSummary")]
        public ISingleResult<ReportSummaryRow> GetReportSummary()
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod());
            return (ISingleResult<ReportSummaryRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetTopProducts")]
        public ISingleResult<TopProductRow> GetTopProducts()
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod());
            return (ISingleResult<TopProductRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetDashboardSummary")]
        public ISingleResult<DashboardSummaryRow> GetDashboardSummary()
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod());
            return (ISingleResult<DashboardSummaryRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetDailySales")]
        public ISingleResult<DailySalesRow> GetDailySales(int days)
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod(), days);
            return (ISingleResult<DailySalesRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetCategorySales")]
        public ISingleResult<CategorySalesRow> GetCategorySales()
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod());
            return (ISingleResult<CategorySalesRow>)result.ReturnValue;
        }

        [Function(Name = "dbo.GetDefaultUser")]
        public ISingleResult<DefaultUserRow> GetDefaultUser()
        {
            IExecuteResult result = ExecuteMethodCall(this,
                (System.Reflection.MethodInfo)System.Reflection.MethodInfo.GetCurrentMethod());
            return (ISingleResult<DefaultUserRow>)result.ReturnValue;
        }

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
