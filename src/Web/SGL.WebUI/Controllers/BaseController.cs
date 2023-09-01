#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SGL.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }

        public async Task<string> GetToken() => await HttpContext.GetTokenAsync("access_token");
    }
}