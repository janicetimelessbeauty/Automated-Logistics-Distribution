using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public interface TokenInterface
    {
        string createToken(IdentityUser user, List<string> roles);
        RefreshToken GenerateRefreshToken();
        ApplicationToken checkExpire(IdentityUser user, string token, List<string> roles);
    }
}
