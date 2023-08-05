namespace TradeSystemAPI.Models.DTOClient
{
    public class OrderGroup
    {
        public Guid opId { get; set; }
        public Guid order { get; set; }
        public Guid product { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public int quantity { get; set; }
        public Customer cust { get; set; }
    }
}
