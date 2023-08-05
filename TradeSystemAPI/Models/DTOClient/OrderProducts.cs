namespace TradeSystemAPI.Models.DTOClient
{
    public class OrderProducts
    {
        public Guid orderID { get; set; }
        public IEnumerable<OrderProduct> products { get; set;}
    }
}
