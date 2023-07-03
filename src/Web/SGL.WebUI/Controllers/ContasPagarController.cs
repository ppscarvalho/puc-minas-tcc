using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;

namespace SGL.WebUI.Controllers
{
    public class ContasPagarController : Controller
    {
        private readonly IContasPagarService _contasPagarService;

        public ContasPagarController(IContasPagarService contasPagarService)
        {
            _contasPagarService = contasPagarService;
        }

        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var contasPagar = await _contasPagarService.ObterTodasContasPagar();
            return View(contasPagar);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var contasPagar = await _contasPagarService.ObterContasPagarPorId(id);
            return View(contasPagar);
        }
    }
}