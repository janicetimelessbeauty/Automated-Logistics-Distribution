using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using TradeSystemInterface.Models;

namespace TradeSystemInterface.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthController(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }
        [HttpGet] 
        public IActionResult Register()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["token"]))
            {
                return RedirectToAction("Index", "Customer");
            }
            MyLog ob = new MyLog()
            {
                roles = new string[] {"Admin", "Customer"},
                check = new bool[] { false, false }
            };
            return View(ob);
        }
        [HttpPost]
        public async Task<IActionResult> Register(MyLog customer)
        {
            var client = _clientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://trading-webapp.azurewebsites.net/api/auth/register/authentication"),
                Content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json")
            };
            var httpResponse = await client.SendAsync(httpRequestMessage);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch(HttpRequestException ex)
            {
                ModelState.AddModelError("info", "Email or username already exists");
                return View(customer);
            }
            var httpContent = await httpResponse.Content.ReadAsStringAsync();
            if (httpContent != null)
            {
                ViewBag.Success = httpContent;
                return RedirectToAction("Login", "Auth");
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login customer)
        {
            var client = _clientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage() { 
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://trading-webapp.azurewebsites.net/api/auth/login/authentication"),
                Content = new StringContent(JsonSerializer.Serialize(customer),Encoding.UTF8, "application/json")
            };
            var httpResponse = await client.SendAsync(httpRequestMessage);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch(HttpRequestException ex)
            {
                ModelState.AddModelError("info", "Username or password is wrong");
                return View(customer);
            }
            var content = await httpResponse.Content.ReadFromJsonAsync<Response>();
            Response.Cookies.Append("token", content.token);
            Response.Cookies.Append("userName", content.user);
            Response.Cookies.Append("refreshToken", content.refresh.token, new CookieOptions() { HttpOnly = true, Expires = content.refresh.Expires });
            return RedirectToAction("Dashboard", "Auth", new {user = content.user, Id = content.Id });
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard([FromQuery] string user, string Id)
        {
            var client = _clientFactory.CreateClient();
            var clientToken = new ClientToken()
            {
                token = Request.Cookies["refreshToken"],
                userName = Request.Cookies["userName"]
            };
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://trading-webapp.azurewebsites.net/api/auth/refreshToken"),
                Content = new StringContent(JsonSerializer.Serialize(clientToken), Encoding.UTF8, "application/json")
            };
            var HttpToken = await client.SendAsync(requestMessage);
            HttpToken.EnsureSuccessStatusCode();
            var newToken = await HttpToken.Content.ReadFromJsonAsync<ApplicationToken>();
            if (newToken.token != null)
            {
                Response.Cookies.Delete("token");
                Response.Cookies.Delete("refreshToken");
                Response.Cookies.Append("token", newToken.token);
                Response.Cookies.Append("refreshToken", newToken.refreshToken.token, new CookieOptions() { HttpOnly = true, Expires = newToken.refreshToken.Expires });
            }
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Request.Cookies["token"]);
            var httpResponse = await client.GetAsync("https://trading-webapp.azurewebsites.net/api/customers");
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Auth");
            }
            var customers = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
            Dashboard db = new Dashboard() { 
                response = new RouteV() { user = user, Id = Id },
                customers = customers
            };

            return View(db);
        }
    }
}
