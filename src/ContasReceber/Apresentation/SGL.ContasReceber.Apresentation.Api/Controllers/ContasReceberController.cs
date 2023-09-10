using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.ContasReceber.Apresentation.Api.Configurations;
using SGL.ContasReceber.Apresentation.Api.Controllers.BaseController;
using SGL.ContasReceber.Core.Application.Commands.ContasReceber;
using SGL.ContasReceber.Core.Application.Models;
using SGL.ContasReceber.Core.Application.Queries.ContasReceber;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.Cliente;
using SGL.MessageQueue.Models.ContasReceber;
using SGL.MessageQueue.Operators;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.ContasReceber.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerConfiguration
    {
        private readonly ILogger<ContasReceberController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;
        private readonly IPublish _publish;
        public ContasReceberController(
            ILogger<ContasReceberController> logger,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IMapper mapper,
            IMediator mediatorQuery,
            IPublish publish) : base(notifications, mediatorHandler)
        {
            _logger = logger;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _mediatorQuery = mediatorQuery;
            _publish = publish;
        }

        [HttpGet]
        [Route("obter-por-id")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ContasReceberModel), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> ObterContasReceberPorId([FromQuery] Guid id)
        {
            _logger.LogInformation("Obter contas a receber por id");
            var result = await _mediatorQuery.Send(new ObterContasReceberPorIdQuery(id));
            result.ResponseClienteOut = await ObterClientePorClienteId(result.ClienteId);
            return Ok(result);
        }

        [HttpGet]
        [Route("obter-todas")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ContasReceberModel), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> ObterTodasContasReceber()
        {
            _logger.LogInformation("Obter todas as contas a receber");
            var result = await _mediatorQuery.Send(new ObterTodasContasReceberQuery());
            await ObterClientePorContasReceber(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("adicionar")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<DefaultResult>> AdicionarContasReceber([FromBody] ContasReceberModel contasReceberModel)
        {
            var cmd = _mapper.Map<AdicionarContasReceberCommand>(contasReceberModel);
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
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<DefaultResult>> AtualizarContasReceber([FromBody] ContasReceberModel contasReceberModel)
        {
            var cmd = _mapper.Map<AtualizarContasReceberCommand>(contasReceberModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }

        private async Task ObterClientePorContasReceber(IEnumerable<ResponseContasReceberOut> result)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "ObterTodosClientes",
            };

            var resp = await _publish.DoRPC<RequestIn, ResponseClienteOut[]>(mapIn);

            foreach (var item in result)
            {
                var cliente = resp.FirstOrDefault(f => f?.Id == item?.ClienteId);
                item.ResponseClienteOut = new ResponseClienteOut
                {
                    Id = item.ClienteId,
                    Nome = cliente?.Nome,
                    CPF = cliente?.CPF
                };
            }
        }

        private async Task<ResponseClienteOut> ObterClientePorClienteId(Guid clienteId)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = clienteId.ToString(),
                Queue = "ObterClientePorId",
            };

            var resp = await _publish.DoRPC<RequestIn, ResponseClienteOut>(mapIn);
            return _mapper.Map<ResponseClienteOut>(resp);
        }
    }
}
