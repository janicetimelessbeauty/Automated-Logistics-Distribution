using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class OrderCreate
    {

        public Guid NewOrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        [Range(5,100, ErrorMessage = "Discount must be at least 5% and at most 100%")]
        public int Discount { get; set; }
    }
}
