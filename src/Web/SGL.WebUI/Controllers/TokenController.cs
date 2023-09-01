using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SGL.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        [Route("getToken")]
        public async Task<JsonResult> CallApi()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return new JsonResult(accessToken);
        }
    }
}
