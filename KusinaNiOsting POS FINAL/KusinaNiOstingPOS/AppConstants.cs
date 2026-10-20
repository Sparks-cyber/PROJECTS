namespace MiniMartPOS
{
    // Fixed business words used by more than one form.
    internal static class AppConstants
    {
        public const string AdminRole = "Admin";
        public const string DefaultAdminName = "Admin";

        public const string PaymentCash = "Cash";
        public const string PaymentGCash = "GCash";
        public const string TransactionPrefix = "TRX-";
        public const string TransactionDateFormat = "yyyyMMddHHmmssfff";
        public const string AllCategoriesText = "All";
        public const int AllCategoriesID = 0;
        public const int SortPriceLowToHigh = 1;
        public const int SortPriceHighToLow = 2;

        public const string StatusAvailable = "Available";
        public const string StatusUnavailable = "Unavailable";
        public const string StatusLowStock = "Low Stock";
        public const string StockLow = "Low";
        public const string StockGood = "Good";

        public const string DefaultStoreName = "Kusina ni Osting";
        public const string DefaultReceiptFooter = "Kaon kay gamiton";
    }
}
