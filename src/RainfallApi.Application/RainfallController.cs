using Microsoft.AspNetCore.Mvc;

namespace RainfallApi.Host
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RainfallController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();
        }
    }
}
