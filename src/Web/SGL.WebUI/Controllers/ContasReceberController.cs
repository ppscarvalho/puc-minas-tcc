using Microsoft.AspNetCore.Mvc;
using SGL.Integrations.Interfaces;

namespace SGL.WebUI.Controllers
{
    public class ContasReceberController : Controller
    {
        private readonly IContasReceberService _contasReceberService;

        public ContasReceberController(IContasReceberService contasReceberService)
        {
            _contasReceberService = contasReceberService;
        }

        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var contasReceber = await _contasReceberService.ObterTodasContasRecebers();
            return View(contasReceber);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var contasReceber = await _contasReceberService.ObterContasReceberPorId(id);
            return View(contasReceber);
        }
    }
}