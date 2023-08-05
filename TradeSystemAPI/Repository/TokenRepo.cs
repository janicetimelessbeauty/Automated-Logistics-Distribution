using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TradeSystemAPI.Models.DTOClient;

namespace TradeSystemAPI.Repository
{
    public class TokenRepo : TokenInterface
    {
        private readonly IConfiguration configuration;
        public TokenRepo(IConfiguration configuration) { 
            this.configuration = configuration;
        }

        public string createToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(configuration["JWT:Issuer"],
                configuration["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signInCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public RefreshToken GenerateRefreshToken()
        {
            RefreshToken refreshToken = new RefreshToken() { 
                token = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["JWT:Refresh"])),
                Expires = DateTime.Now.AddMinutes(2),
                Created = DateTime.Now
            };
            return refreshToken;
        }
        public ApplicationToken checkExpire(IdentityUser user, string tokenClient, List<string> roles)
        {
            var applicationToken = new ApplicationToken();
            if (tokenClient != null)
            {
                return applicationToken;
            }
            var token = createToken(user, roles);
            var refreshToken = GenerateRefreshToken();
            applicationToken.token = token;
            applicationToken.refreshToken = refreshToken;
            return applicationToken;
        }
    }
}
