using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class EditCustomer
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be an email address")]
        public string email { get; set; }
        [Required]
        [MinLength(15)]
        public string address { get; set; }
        public string city { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Must be a valid mobile phonenumber")]
        public string mobilePhone { get; set; }
        public int dist { get; set; }
    }
}
