using Microsoft.AspNetCore.Identity;

namespace TradeSystemAPI.Models.DTOClient
{
    public class ApplicationToken
    {
        public string? token { get; set; }
        public RefreshToken? refreshToken { get; set; }
    }
}
