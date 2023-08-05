namespace TradeSystemInterface.Models
{
    public class OrderGroup
    {
        public Guid orderID { get; set; }
        public IEnumerable<OrderProduct> products { get; set; }
    }
}
