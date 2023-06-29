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
        public async Task<IActionResult> Index()
        {
            var cliente = await _clienteService.ObterTodosClientes();
            return View(cliente);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var cliente = await _clienteService.ObterClientePorId(id);
            return View(cliente);
        }
    }
}