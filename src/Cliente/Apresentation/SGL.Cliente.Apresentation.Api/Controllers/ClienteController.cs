using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGL.Cliente.Apresentation.Api.Controllers.BaseController;
using SGL.Cliente.Core.Application.Commands.Cliente;
using SGL.Cliente.Core.Application.Models;
using SGL.Cliente.Core.Application.Queries.Cliente;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.Cliente.Apresentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerConfiguration
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public ClienteController(
            ILogger<ClienteController> logger,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IMapper mapper,
            IMediator mediatorQuery) : base(notifications, mediatorHandler)
        {
            _logger = logger;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _mediatorQuery = mediatorQuery;
        }

        [HttpGet]
        [Route("obter-por-id")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterClientePorId([FromQuery] Guid id)
        {
            _logger.LogInformation("Obter todos os clientes");
            var result = await _mediatorQuery.Send(new ObterClientePorIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        [Route("obter-todos")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterTodosClientes()
        {
            _logger.LogInformation("Obter todos os clientes");
            var result = await _mediatorQuery.Send(new ObterTodosClientesQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("adicionar")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> AdicionarCliente([FromBody] ClienteModel clienteModel)
        {
            var cmd = _mapper.Map<AdicionarClienteCommand>(clienteModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }

        [HttpPost]
        [Route("atualizar")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> AtualizarCliente([FromBody] ClienteModel clienteModel)
        {
            var cmd = _mapper.Map<AtualizarClienteCommand>(clienteModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }
    }
}