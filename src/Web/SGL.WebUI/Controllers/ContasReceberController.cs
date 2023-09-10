using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.WebUI.Controllers
{
    public class ContasReceberController : BaseController
    {
        private readonly IContasReceberService _contasReceberService;
        private readonly IClienteService _clienteService;
        public ContasReceberController(IContasReceberService contasReceberService, IClienteService clienteService)
        {
            _contasReceberService = contasReceberService;
            _clienteService = clienteService;
        }

        // GET: ContasReceberController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = await GetToken();
            var ContasReceber = await _contasReceberService.ObterTodosContasRecebers(token);
            return View(ContasReceber);
        }

        // GET: ContasReceberController/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var token = await GetToken();
            var clientes = await _clienteService.ObterTodosClientes(token);
            var contasReceber = new ContasReceberViewModel
            {
                ClienteViewModels = clientes.ToList(),
                StatusVieModels = _contasReceberService.TodosStatus()
            };

            return View(contasReceber);
        }

        // POST: ContasReceberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ContasReceberViewModel contasReceberViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                contasReceberViewModel.Valor /= 100.0M;

                var token = await GetToken();
                var result = await _contasReceberService.Adicionar(contasReceberViewModel, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContasReceberController/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var token = await GetToken();
            var contasPagar = await _contasReceberService.ObterContasReceberPorId(id, token);
            var fornecedor = await _clienteService.ObterTodosClientes(token);
            contasPagar.ClienteViewModels = fornecedor.ToList();
            contasPagar.StatusVieModels = _contasReceberService.TodosStatus();
            return View(contasPagar);
        }

        // POST: ContasReceberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(ContasReceberViewModel contasReceberViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            contasReceberViewModel.Valor /= 100.0M;

            var token = await GetToken();
            var result = await _contasReceberService.Atualizar(contasReceberViewModel, token);

            return RedirectToAction(nameof(Index));
        }

        // GET: ContasReceberController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var ContasReceber = await _contasReceberService.ObterContasReceberPorId(id, token);
            return View(ContasReceber);
        }
    }
}