using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.WebUI.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: ClienteController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = await GetToken();
            var cliente = await _clienteService.ObterTodosClientes(token);
            return View(cliente);
        }

        // GET: ClienteController/Create
        [Authorize]
        public ActionResult Create()
        {
            var cliente = new ClienteViewModel
            {
                Estados = _clienteService.TodosEstados()
            };
            return View(cliente);
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var token = await GetToken();
                var result = await _clienteService.Adicionar(clienteViewModel, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var token = await GetToken();
            var cliente = await _clienteService.ObterClientePorId(id, token);
            cliente.Estados = _clienteService.TodosEstados();
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var token = await GetToken();
            var result = await _clienteService.Atualizar(clienteViewModel, token);

            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var cliente = await _clienteService.ObterClientePorId(id, token);
            return View(cliente);
        }
    }
}