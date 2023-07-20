using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;

namespace SGL.WebUI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: CustomerController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = await GetToken();
            var cliente = await _clienteService.ObterTodosClientes(token);
            return View(cliente);
        }

        // GET: CustomerController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var cliente = await _clienteService.ObterClientePorId(id, token);
            return View(cliente);
        }

        private async Task<string> GetToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }
}