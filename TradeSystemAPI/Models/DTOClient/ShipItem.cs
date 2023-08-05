namespace TradeSystemAPI.Models.DTOClient
{
    public class ShipItem
    {
        public Guid orderId { get; set; }
        public Guid wareId { get; set; }
        public string wareName { get; set; }
        public int total { get; set; }
        public DateTime Created { get; set; }
    }
}
