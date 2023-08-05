using TradeSystemAPI.Data;
using TradeSystemAPI.Models;

namespace TradeSystemAPI.Repository
{
    public class Image : ImageRepo
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _accessor;
        private readonly TradeContext _tradeContext;

        public Image(IWebHostEnvironment webHost, IHttpContextAccessor accessor, TradeContext tradeContext) 
        {
            _webHost = webHost;
            _accessor = accessor;
            _tradeContext = tradeContext;
        }

        public async Task<ImageUpload> uploadImage(ImageUpload image)
        {
            // upload image to local path / stream
            var localPath = Path.Combine(_webHost.ContentRootPath, "Images", $"{image.fileName}{image.fileExtension}");
            var stream = new FileStream(localPath, FileMode.Create);
            await image.File.CopyToAsync(stream);
            // https://localhost:1234/images/kmo.jpg
            var url = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}{_accessor.HttpContext.Request.PathBase}/Images/{image.fileName}{image.fileExtension}";
            image.filePath = url;
            await _tradeContext.ImageUploads.AddAsync(image);
            await _tradeContext.SaveChangesAsync();
            return image;
        }
    }
}
