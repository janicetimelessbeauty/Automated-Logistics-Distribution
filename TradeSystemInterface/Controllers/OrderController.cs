using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text.Json;
using TradeSystemInterface.Models;
using System.Text;

namespace TradeSystemInterface.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _client;

        public OrderController(IHttpClientFactory client) {
            _client = client;
        }
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var client = _client.CreateClient();
            var httpResponse = await client.GetAsync("https://trading-webapp.azurewebsites.net/api/orders");
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                return RedirectToAction("Index", "Home");
            }
            var ordersGroup = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<OrderGroup>>();
            if (ordersGroup == null) {
                return RedirectToAction("Index", "Home");
            }
            return View(ordersGroup);
        }
        public IActionResult Graph()
        {
            return View();
        }
        
    }
}
