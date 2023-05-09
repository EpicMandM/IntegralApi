using Microsoft.AspNetCore.Mvc;
using IntegralApi;
using IntegralApi.Model;
using Microsoft.AspNetCore.Hosting;

namespace IntergralWeb.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(IWebHostEnvironment webHostEnvironment)
        {
            var filePath = Path.Combine(webHostEnvironment.ContentRootPath, "StaticPages", "index.html");
            return PhysicalFile(filePath, "text/html");
        }

        [HttpPost]
        [Route("proceed")]
        public async Task<IActionResult> Proceed(string expression)
        {
            return View(await Integral.GetAsync(expression ?? ""));
        }
    }
}
