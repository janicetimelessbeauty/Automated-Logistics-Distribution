using System.ComponentModel.DataAnnotations;

namespace TradeSystemInterface.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        [Required]
        public string name { get; set; }
        public DateTime dateofBirth { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [MinLength(15)]
        public string address { get; set; }
        public string city { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string mobilePhone { get; set; }
        public int? dist { get; set; }
    }
}
