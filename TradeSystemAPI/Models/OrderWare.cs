using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models
{
    public class orderWare
    {
        public Guid Id { get; set; }
        public Guid NewOrderId { get; set; }
        public NewOrder NewOrder { get; set; }
        public int totalAmount { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public DateTime Created { get; set; }   

    }
}
