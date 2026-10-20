namespace MiniMartPOS
{
    public static class Session
    {
        public static int CurrentUserID { get; set; }
        public static string CurrentUserName { get; set; }
        public static string CurrentRole { get; set; }

        public static void Clear()
        {
            CurrentUserID = 0;
            CurrentUserName = null;
            CurrentRole = null;
        }
    }

    public class LookupItem
    {
        public int? ID { get; set; }
        public string Text { get; set; }
        public override string ToString() { return Text; }
    }

    public class CartLine
    {
        public int MenuItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int AvailableStock { get; set; }
        public decimal Total { get { return Price * Quantity; } }
    }
}
