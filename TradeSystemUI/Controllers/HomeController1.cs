using Microsoft.AspNetCore.Mvc;

namespace TradeSystemUI.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
