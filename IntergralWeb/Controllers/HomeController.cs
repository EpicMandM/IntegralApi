using Microsoft.AspNetCore.Mvc;
using IntegralApi;
using IntegralApi.Model;
namespace IntergralWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Proceed(string expression)
        {
            return View(Integral.Get(expression ?? "").Result);
        }
    }
}
