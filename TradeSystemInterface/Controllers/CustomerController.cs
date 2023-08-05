using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using TradeSystemInterface.Models;
using System.Net.Http.Headers;
namespace TradeSystemInterface.Controllers
{

    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CustomerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<Customer> customers;
            try
            {
                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["token"]);
                var HttpResponse = await client.GetAsync("https://trading-webapp.azurewebsites.net/api/customers");
                HttpResponse.EnsureSuccessStatusCode();
                customers = await HttpResponse.Content.ReadFromJsonAsync<List<Customer>>();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(customers);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Customer customer)
        {
            var client = _clientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://trading-webapp.azurewebsites.net/api/customers"),
                Content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json")
            };
            var httpResponse = await client.SendAsync(httpRequestMessage);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch(HttpRequestException ex)
            {
                ModelState.AddModelError("Error with input", ex.Message);
            }
            var response = await httpResponse.Content.ReadFromJsonAsync<Customer>();
            if (response != null)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View(customer);

        }
        public async Task<IActionResult> Edit(Guid? id)
        {
            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["token"]);
            var httpResponse = await client.GetFromJsonAsync<Customer>($"https://trading-webapp.azurewebsites.net/api/customers/{id}");
            return View(httpResponse);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            HttpClient client = _clientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://trading-webapp.azurewebsites.net/api/customers/{customer.CustomerId}"),
                Content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json")
            };
            var httpResponse = await client.SendAsync(httpRequestMessage);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("request", ex.Message);
            }
            var responseContent = await httpResponse.Content.ReadFromJsonAsync<Customer>();
            if (responseContent != null)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            HttpClient client = _clientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://trading-webapp.azurewebsites.net/api/customers/{customer.CustomerId}"),
                Content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json")
            };
            var httpResponse = await client.SendAsync(httpRequestMessage);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("request", ex.Message);
            }
            var responseContent = await httpRequestMessage.Content.ReadFromJsonAsync<Customer>();
            if (responseContent != null)
            {
                return RedirectToAction("Delete", "Customer");
            }
            return View(customer);




        }
    }
}
