using TradeSystemAPI.Models;

namespace TradeSystemAPI.Repository
{
    public interface ImageRepo
    {
        Task<ImageUpload> uploadImage(ImageUpload image);
    }
}
