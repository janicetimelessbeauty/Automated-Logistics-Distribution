using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
