using Microsoft.AspNetCore.Mvc;
using IntegralApi;
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
            return Ok(await Integral.GetAsync(equation));
        }
    }
}
