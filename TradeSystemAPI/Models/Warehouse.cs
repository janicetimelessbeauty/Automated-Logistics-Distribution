using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models
{
    public class Warehouse
    {
        public Guid WarehouseId { get; set; }
        public string WareName { get; set; }
        public string License { get; set; }
        public string CentralDistance { get; set; }
        public int EstimatedTime { get; set; }
    }
}
