using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Collections;
using TradeSystemUI.Models;

namespace TradeSystemUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CustomerController(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<Customer> customers;
            try
            {
                var client = _clientFactory.CreateClient();
                var HttpResponse = await client.GetAsync("https://localhost:7049/api/customers");
                HttpResponse.EnsureSuccessStatusCode();
                customers = await HttpResponse.Content.ReadFromJsonAsync<List<Customer>>();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return View(customers);
        }

    }
}
