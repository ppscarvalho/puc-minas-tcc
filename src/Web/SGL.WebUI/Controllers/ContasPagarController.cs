using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.WebUI.Controllers
{
    public class ContasPagarController : BaseController
    {
        private readonly IContasPagarService _contasPagarService;

        public ContasPagarController(IContasPagarService contasPagarService)
        {
            _contasPagarService = contasPagarService;
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
        public ActionResult Create()
        {
            var contasPagar = new ContasPagarViewModel();
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
            return View(contasPagar);
        }

        // POST: ContasPagarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(ContasPagarViewModel ContasPagarViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var token = await GetToken();
            var result = await _contasPagarService.Atualizar(ContasPagarViewModel, token);

            return RedirectToAction(nameof(Index));
        }

        // GET: ContasPagarController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var ContasPagar = await _contasPagarService.ObterContasPagarPorId(id, token);
            return View(ContasPagar);
        }
    }
}