using Microsoft.AspNetCore.Mvc;
using IntegralApi;
using System.Net;

namespace IntergralWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquationController : ControllerBase
    {
        [HttpGet]
        [Route("{equation}")]
        public async Task<ActionResult<string>> Get(string equation)
        {
            return Ok(await Integral.GetAsync(WebUtility.UrlDecode(equation)));
        }
    }
}
