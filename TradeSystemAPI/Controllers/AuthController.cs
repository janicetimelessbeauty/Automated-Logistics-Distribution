using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;
using System.Security.Claims;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Repository;

namespace TradeSystemAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenInterface _tokenInterface;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager, TokenInterface tokenInterface)
        {
            _tokenInterface = tokenInterface;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register/authentication")]
        public async Task<IActionResult> CreateUser([FromBody] Admin adminUser)
        {
            List<string> roles = new List<string>();
            for (int i = 0; i < adminUser.roles.Length; i++)
            {
                if (adminUser.check[i] == true)
                {
                    roles.Add(adminUser.roles[i]);
                }
            }
            IdentityUser user = new IdentityUser()
            {
                Email = adminUser.email,
                UserName = adminUser.userName
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, adminUser.password);
            if (identityResult.Succeeded)
            {
                var identity = await _userManager.AddToRolesAsync(user, roles.ToArray());
                if (identity.Succeeded)
                {
                    return Ok("The user is succesfully registered");
                }
            }
            return BadRequest("Username or email already exists");
        }
        [HttpPost]
        [Route("login/authentication")]
        public async Task<IActionResult> LogUser([FromBody] Login logUser)
        {
            var user = await _userManager.FindByEmailAsync(logUser.email);
            if (user != null)
            {
                var checkPass = await _userManager.CheckPasswordAsync(user, logUser.password);
                if (checkPass)
                {
                    var userRole = await _userManager.GetRolesAsync(user);
                    if (userRole != null)
                    {
                        var jwtToken = _tokenInterface.createToken(user, userRole.ToList());                 
                        var refreshToken = _tokenInterface.GenerateRefreshToken();
                        var response = new Response() {
                            token  = jwtToken,
                            refresh = refreshToken,
                            user = user.UserName,
                            Id = user.Id
                        };
                        return Ok(response);
                    }
                }

            }
            return BadRequest("Username or password is wrong");
        }
        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> checkRefreshToken(ClientToken clientToken)
        {
            var user = await _userManager.FindByNameAsync(clientToken.userName);
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null)
            {
                return Unauthorized("Username is invalid");
            }
            var newTokens = _tokenInterface.checkExpire(user, clientToken.token, roles.ToList());
            if (newTokens == null)
            {
                return Ok(newTokens);
            }
            return Ok(newTokens);
            
        }
    }

}
