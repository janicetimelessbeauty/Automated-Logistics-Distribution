using System.ComponentModel.DataAnnotations;

namespace TradeSystemAPI.Models.DTOClient
{
    public class ImageUploadForm
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]
        public string fileName { get; set; }
        public string? fileDescription { get; set; }
    }
}
