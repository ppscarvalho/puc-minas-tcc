using Microsoft.AspNetCore.Mvc;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Operators;
using SGL.MessageQueue.Models.Fornecedor;

namespace SGL.Fornecedor.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerFornecedorController : ControllerBase
    {
        private readonly IPublish _publish;

        public ConsumerFornecedorController(IPublish publish)
        {
            _publish = publish;
        }

        [HttpGet]
        [Route("ObterFornecedorPorId")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseFornecedorOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterFornecedorPorId([FromQuery] Guid id)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = id.ToString(),
                Queue = "ObterFornecedorPorId"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseFornecedorOut>(mapIn);
            return Ok(result);
        }

        [HttpPost]
        [Route("ObterTodosFornecedores")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseFornecedorOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterTodosFornecedores()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "ObterTodosFornecedores"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseFornecedorOut[]>(mapIn);
            return Ok(result);
        }
    }
}
