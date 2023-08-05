namespace TradeSystemAPI.Models
{
    public class NewOrder
    {
        public Guid NewOrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Created { get; set; }
    }
}
