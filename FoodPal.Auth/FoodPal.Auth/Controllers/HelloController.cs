using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodPal.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = "CustomAuthScheme")]
        public IActionResult Hello()
        {
            return Ok(new { Hello = "Darkness my old friend" });
        }
    }
}
