using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstanteVirtual.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
