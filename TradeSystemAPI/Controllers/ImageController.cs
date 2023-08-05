using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeSystemAPI.Models;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Repository;

namespace TradeSystemAPI.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageRepo _imageRepo;

        public ImageController(ImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> upload([FromForm] ImageUploadForm file) 
        {
            fileValidation(file);
            if (ModelState.IsValid)
            {
                var imageModel = new ImageUpload() { 
                   File = file.file,
                   fileSize = file.file.Length,
                   fileName = file.fileName,
                   fileExtension = Path.GetExtension(file.file.FileName),
                   fileDescription = file.fileDescription
                };
                await _imageRepo.uploadImage(imageModel);
                return Ok(imageModel);
            }
            return BadRequest(ModelState);    

        }
        private void fileValidation(ImageUploadForm request)
        {
            string[] extensions = new string[] {".jpg", ".png", ".jpeg" };
            Console.WriteLine(Path.GetExtension(request.file.FileName));
            if (!extensions.Contains(Path.GetExtension(request.file.FileName)))
            {
                ModelState.AddModelError("file", "Invalid image file extension");
            }
            if (request.file.Length > 5000000)
            {
                ModelState.AddModelError("file", "File size must be equal or under 5MB");
            }
        }
    }
}
