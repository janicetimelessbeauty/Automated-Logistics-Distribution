using System.ComponentModel.DataAnnotations;

namespace TradeSystemInterface.Models
{
    public class MyLog
    {
        [Required]
        [MinLength(6)]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password did not match")]
        public string confirmPassword { get; set; }
        public string[] roles { get; set; } = new string[] { "Admin", "Customer" };
        public bool[] check { get; set; }
        
    }
}
