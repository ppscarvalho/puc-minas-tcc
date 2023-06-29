using Microsoft.AspNetCore.Mvc;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Operators;
using SGL.MessageQueue.Models.Cliente;

namespace SGL.Cliente.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerClienteController : ControllerBase
    {
        private readonly IPublish _publish;

        public ConsumerClienteController(IPublish publish)
        {
            _publish = publish;
        }

        [HttpGet]
        [Route("ObterClientePorId")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseClienteOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterClientePorId([FromQuery] Guid id)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = id.ToString(),
                Queue = "ObterClientePorId"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseClienteOut>(mapIn);
            return Ok(result);
        }

        [HttpPost]
        [Route("ObterTodosClientes")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseClienteOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterTodosClientes()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "ObterTodosClientes"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseClienteOut[]>(mapIn);
            return Ok(result);
        }
    }
}