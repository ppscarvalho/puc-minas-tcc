using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;

namespace SGL.WebUI.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var fornecedor = await _fornecedorService.ObterTodosFornecedores();
            return View(fornecedor);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedor = await _fornecedorService.ObterFornecedorPorId(id);
            return View(fornecedor);
        }
    }
}