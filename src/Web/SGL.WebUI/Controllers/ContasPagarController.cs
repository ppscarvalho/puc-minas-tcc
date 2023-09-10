using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.WebUI.Controllers
{
    public class ContasPagarController : BaseController
    {
        private readonly IContasPagarService _contasPagarService;
        private readonly IFornecedorService _fornecedorService;
        public ContasPagarController(IContasPagarService contasPagarService, IFornecedorService fornecedorService)
        {
            _contasPagarService = contasPagarService;
            _fornecedorService = fornecedorService;
        }

        // GET: ContasPagarController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = await GetToken();
            var ContasPagar = await _contasPagarService.ObterTodosContasPagars(token);
            return View(ContasPagar);
        }

        // GET: ContasPagarController/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var token = await GetToken();
            var fornecedores = await _fornecedorService.ObterTodosFornecedores(token);
            var contasPagar = new ContasPagarViewModel
            {
                FornecedorViewModels = fornecedores.ToList(),
                StatusVieModels = _contasPagarService.TodosStatus()
            };

            return View(contasPagar);
        }

        // POST: ContasPagarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ContasPagarViewModel contasPagarViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                contasPagarViewModel.Valor /= 100.0M;

                var token = await GetToken();
                var result = await _contasPagarService.Adicionar(contasPagarViewModel, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContasPagarController/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var token = await GetToken();
            var contasPagar = await _contasPagarService.ObterContasPagarPorId(id, token);
            var fornecedor = await _fornecedorService.ObterTodosFornecedores(token);
            contasPagar.FornecedorViewModels = fornecedor.ToList();
            contasPagar.StatusVieModels = _contasPagarService.TodosStatus();
            return View(contasPagar);
        }

        // POST: ContasPagarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(ContasPagarViewModel contasPagarViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            contasPagarViewModel.Valor /= 100.0M;

            var token = await GetToken();
            var result = await _contasPagarService.Atualizar(contasPagarViewModel, token);

            return RedirectToAction(nameof(Index));
        }

        // GET: ContasPagarController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var contasPagar = await _contasPagarService.ObterContasPagarPorId(id, token);
            return View(contasPagar);
        }
    }
}