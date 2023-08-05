using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Diagnostics;
using TradeSystemInterface.Models;

namespace TradeSystemInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _client;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var client = _client.CreateClient();
            var httpResponse = await client.GetAsync("https://trading-webapp.azurewebsites.net/api/products?isAscending=true&pageNumber=1&pageSize=10");
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                return null;
            }
            var products = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            return View(products);
        }
        public async Task<IActionResult> Filter(string sortBy, bool isAscending, int pageNumber, int pageSize)
        {
            var client = _client.CreateClient();
            var httpResponse = await client.GetAsync($"https://trading-webapp.azurewebsites.net/api/products?sortBy={sortBy}&isAscending={isAscending}&pageNumber={pageNumber}&pageSize={pageSize}");
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                return null;
            }
            var products = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            return View(products);
        }
        public async Task<IActionResult> Search(string column, string value, bool isAscending, int pageNumber, int pageSize)
        {
            var client = _client.CreateClient();
            var httpResponse = await client.GetAsync($"https://trading-webapp.azurewebsites.net/api/products?column={column}&value={value}&isAscending={isAscending}&pageNumber={pageNumber}&pageSize={pageSize}");
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                return null;
            }
            var products = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            return View(products);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}