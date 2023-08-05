using System.ComponentModel.DataAnnotations.Schema;

namespace TradeSystemAPI.Models
{
    public class ImageUpload
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string fileName { get; set; }
        public string fileExtension { get; set; }
        public string filePath { get; set; }
        public long fileSize { get; set; }
        public string fileDescription { get; set; }

    }
}
