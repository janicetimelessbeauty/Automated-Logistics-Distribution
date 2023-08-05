using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeSystemAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid NewOrderId { get; set; }
        public NewOrder NewOrder { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }



        


    }
}
