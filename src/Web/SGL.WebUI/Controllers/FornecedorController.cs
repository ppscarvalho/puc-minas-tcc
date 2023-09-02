using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.WebUI.Controllers
{
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: FornecedorController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = await GetToken();
            var fornecedor = await _fornecedorService.ObterTodosFornecedores(token);
            return View(fornecedor);
        }

        // GET: FornecedorController/Create
        [Authorize]
        public ActionResult Create()
        {
            var fornecedor = new FornecedorViewModel
            {
                Estados = _fornecedorService.TodosEstados()
            };
            return View(fornecedor);
        }

        // POST: FornecedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var token = await GetToken();
                var result = await _fornecedorService.Adicionar(fornecedorViewModel, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FornecedorController/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var token = await GetToken();
            var fornecedor = await _fornecedorService.ObterFornecedorPorId(id, token);
            fornecedor.Estados = _fornecedorService.TodosEstados();
            return View(fornecedor);
        }

        // POST: FornecedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var token = await GetToken();
            var result = await _fornecedorService.Atualizar(fornecedorViewModel, token);

            return RedirectToAction(nameof(Index));
        }

        // GET: FornecedorController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var fornecedor = await _fornecedorService.ObterFornecedorPorId(id, token);
            return View(fornecedor);
        }
    }
}