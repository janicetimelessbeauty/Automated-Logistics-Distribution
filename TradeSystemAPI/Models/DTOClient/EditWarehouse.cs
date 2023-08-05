using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class EditWarehouse
    {
        [MinLength(3, ErrorMessage = "WareName must be at least 3 characters")]
        public string WareName { get; set; }
        public string License { get; set; }
        [MinLength(1, ErrorMessage = "Must be between 1 - 99")]
        [MaxLength(2, ErrorMessage = "Must be between 1 - 99")]
        public string CentralDistance { get; set; }
        public int EstimatedTime { get; set; }
    }
}
