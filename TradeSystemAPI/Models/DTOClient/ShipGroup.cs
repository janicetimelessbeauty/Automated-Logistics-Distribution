namespace TradeSystemAPI.Models.DTOClient
{
    public class ShipGroup
    {
        public Guid ShipId { get; set; }
        public IEnumerable<ShipItem> orders { get; set; }
    }
}
