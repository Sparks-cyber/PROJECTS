namespace GROUP_PROJECT
{
    // Store one product selected by the customer.
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Subtotal
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
