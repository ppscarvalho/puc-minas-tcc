using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;

namespace SGL.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService ProdutoService)
        {
            _produtoService = ProdutoService;
        }

        // GET: CustomerController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var Produto = await _produtoService.ObterTodosProdutos();
            return View(Produto);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var Produto = await _produtoService.ObterProdutoPorId(id);
            return View(Produto);
        }
    }
}