using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class InsertCustomer
    {
        [Required]
        public string name { get; set; }
        public DateTime dateofBirth { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be an email address")]
        public string email { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Address must be at least 15 characters in length")]
        public string address { get; set; }
        public string city { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Must be a phone number")]
        public string mobilePhone { get; set; }
    }
}
