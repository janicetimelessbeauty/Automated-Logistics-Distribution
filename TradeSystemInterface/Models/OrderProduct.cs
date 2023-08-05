namespace TradeSystemInterface.Models
{
    public class OrderProduct
    {
        public Guid orderProId { get; set; }
        public Guid productID { get; set; }
        public string productImage { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public Customer cust { get; set; }
    }
}
