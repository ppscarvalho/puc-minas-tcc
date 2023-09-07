using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.WebUI.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorService _fornecedorService;

        public ProdutoController(IProdutoService ProdutoService, IFornecedorService fornecedorService)
        {
            _produtoService = ProdutoService;
            _fornecedorService = fornecedorService;
        }

        // GET: ProdutoController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = await GetToken();
            var Produto = await _produtoService.ObterTodosProdutos(token);
            return View(Produto);
        }

        // GET: ProdutoController/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var token = await GetToken();
            var fornecedor = await _fornecedorService.ObterTodosFornecedores(token);
            var categoria = await _produtoService.ObterTodasCategorias();
            var produto = new ProdutoViewModel
            {
                FornecedorViewModels = fornecedor.ToList(),
                CategoriaViewModels = categoria.ToList()
            };

            return View(produto);
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                produtoViewModel.PrecoCompra /= 100.0M;
                produtoViewModel.PrecoVenda /= 100.0M;
                produtoViewModel.MargemLucro /= 100.0M;

                var token = await GetToken();
                var result = await _produtoService.Adicionar(produtoViewModel, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var token = await GetToken();
            var produto = await _produtoService.ObterProdutoPorId(id, token);

            var fornecedor = await _fornecedorService.ObterTodosFornecedores(token);
            var categoria = await _produtoService.ObterTodasCategorias();

            produto.FornecedorViewModels = fornecedor.ToList();
            produto.CategoriaViewModels = categoria.ToList();

            return View(produto);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                produtoViewModel.PrecoCompra /= 100.0M;
                produtoViewModel.PrecoVenda /= 100.0M;
                produtoViewModel.MargemLucro /= 100.0M;

                var token = await GetToken();
                var result = await _produtoService.Atualizar(produtoViewModel, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await GetToken();
            var produto = await _produtoService.ObterProdutoPorId(id, token);
            return View(produto);
        }
    }
}