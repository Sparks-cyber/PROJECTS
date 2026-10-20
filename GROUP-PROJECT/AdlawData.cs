using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace GROUP_PROJECT
{
    public class AuthenticationResult
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Role { get; set; }
    }

    public class ProductResult
    {
        public int ProductID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SaleResult
    {
        public int SaleID { get; set; }
        public System.DateTime SaleDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class InventoryResult
    {
        public int ProductID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Stock { get; set; }

        public string DisplayName { get; set; }
    }

    public class AdlawDataContext : DataContext
    {
        private const string ConnectionStringName = "AdlawPOSConnectionString";

        public AdlawDataContext()
            : base(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString)
        {
        }

        [Function(Name = "Adlaw_Authenticate")]
        public ISingleResult<AuthenticationResult> Adlaw_Authenticate(
            [Parameter(Name = "Username")] string username,
            [Parameter(Name = "PasswordHash")] string passwordHash)
        {
            return (ISingleResult<AuthenticationResult>)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                username,
                passwordHash
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_RetrieveProducts")]
        public ISingleResult<ProductResult> Adlaw_RetrieveProducts()
        {
            return (ISingleResult<ProductResult>)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod()
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_SearchProducts")]
        public ISingleResult<ProductResult> Adlaw_SearchProducts(
            [Parameter(Name = "ItemName")] string itemName)
        {
            return (ISingleResult<ProductResult>)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                itemName
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_AddProduct")]
        public void Adlaw_AddProduct(
            string itemName,
            int categoryID,
            decimal price,
            int stock,
            string imagePath)
        {
            ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                itemName,
                categoryID,
                price,
                stock,
                imagePath
            );
        }

        [Function(Name = "Adlaw_UpdateProduct")]
        public void Adlaw_UpdateProduct(
            int productID,
            string itemCode,
            string itemName,
            int categoryID,
            decimal price,
            int stock,
            string imagePath)
        {
            ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                productID,
                itemCode,
                itemName,
                categoryID,
                price,
                stock,
                imagePath
            );
        }

        [Function(Name = "Adlaw_SoftDeleteProduct")]
        public void Adlaw_SoftDeleteProduct(int productID)
        {
            ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                productID
            );
        }

        [Function(Name = "Adlaw_RestoreProduct")]
        public void Adlaw_RestoreProduct(int productID)
        {
            ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                productID
            );
        }

        [Function(Name = "Adlaw_HardDeleteProduct")]
        public void Adlaw_HardDeleteProduct(int productID)
        {
            ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                productID
            );
        }

        [Function(Name = "Adlaw_RetrieveDeletedProducts")]
        public ISingleResult<ProductResult> Adlaw_RetrieveDeletedProducts()
        {
            return (ISingleResult<ProductResult>)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod()
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_CreateSaleHeader")]
        public int Adlaw_CreateSaleHeader(string paymentMethod)
        {
            return (int)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                paymentMethod
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_AddSaleItem")]
        public int Adlaw_AddSaleItem(int saleID, int productID, int quantity)
        {
            return (int)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                saleID,
                productID,
                quantity
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_RetrieveSales")]
        public ISingleResult<SaleResult> Adlaw_RetrieveSales()
        {
            return (ISingleResult<SaleResult>)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod()
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_RetrieveInventory")]
        public ISingleResult<InventoryResult> Adlaw_RetrieveInventory()
        {
            return (ISingleResult<InventoryResult>)ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod()
            ).ReturnValue;
        }

        [Function(Name = "Adlaw_RestockProduct")]
        public void Adlaw_RestockProduct(int productID, int quantity)
        {
            ExecuteMethodCall(
                this,
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                productID,
                quantity
            );
        }
    }
}
