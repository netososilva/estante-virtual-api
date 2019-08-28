using EstanteVirtual.Bo.Interfaces;
using EstanteVirtual.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstanteVirtual.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    public class LoginController : ControllerBase
    {
        private readonly ILoginBo _loginBo;

        public LoginController(ILoginBo loginBo)
        {
            _loginBo = loginBo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Post([FromBody]Login login)
        {
            var user = _loginBo.Authenticate(login);

            if (user == null)
                return Unauthorized();

            return Ok(user);
        }
    }
}
