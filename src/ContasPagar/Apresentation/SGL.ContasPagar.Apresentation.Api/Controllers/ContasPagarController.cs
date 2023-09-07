using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.ContasPagar.Apresentation.Api.Configurations;
using SGL.ContasPagar.Apresentation.Api.Controllers.BaseController;
using SGL.ContasPagar.Core.Application.Commands.ContasPagar;
using SGL.ContasPagar.Core.Application.Models;
using SGL.ContasPagar.Core.Application.Queries.ContasPagar;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.ContasPagar;
using SGL.MessageQueue.Models.Fornecedor;
using SGL.MessageQueue.Operators;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.ContasPagar.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasPagarController : ControllerConfiguration
    {
        private readonly ILogger<ContasPagarController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;
        private readonly IPublish _publish;
        public ContasPagarController(
            ILogger<ContasPagarController> logger,
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
        [ProducesResponseType(typeof(ContasPagarModel), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> ObterContasPagarPorId([FromQuery] Guid id)
        {
            _logger.LogInformation("Obter contas a Pagar por id");
            var result = await _mediatorQuery.Send(new ObterContasPagarPorIdQuery(id));
            result.ResponseFornecedorOut = await ObterFornecedorPorFornecedorId(result.FornecedorId);
            return Ok(result);
        }

        [HttpGet]
        [Route("obter-todas")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ContasPagarModel), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> ObterTodasContasPagar()
        {
            _logger.LogInformation("Obter todas as contas a Pagar");
            var result = await _mediatorQuery.Send(new ObterTodasContasPagarQuery());
            await ObterFornecedorPorContaPagar(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("adicionar")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<DefaultResult>> AdicionarContasPagar([FromBody] ContasPagarModel contasPagarModel)
        {
            var cmd = _mapper.Map<AdicionarContasPagarCommand>(contasPagarModel);
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
        public async Task<ActionResult<DefaultResult>> AtualizarContasPagar([FromBody] ContasPagarModel contasPagarModel)
        {
            var cmd = _mapper.Map<AtualizarContasPagarCommand>(contasPagarModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }

        [HttpGet]
        [Route("baixar-contas-a-pagar-por-id")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> BaixarContasPagar([FromQuery] Guid id)
        {
            await Task.CompletedTask;
            return Ok(id);
        }

        private async Task ObterFornecedorPorContaPagar(IEnumerable<ResponseContasPagarOut> result)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "ObterTodosFornecedores",
            };

            var resp = await _publish.DoRPC<RequestIn, ResponseFornecedorOut[]>(mapIn);

            foreach (var item in result)
            {
                var fornecedor = resp.FirstOrDefault(f => f?.Id == item?.FornecedorId);
                item.ResponseFornecedorOut = new ResponseFornecedorOut
                {
                    Id = item.FornecedorId,
                    NomeFantasia = fornecedor?.NomeFantasia,
                    CNPJ = fornecedor?.CNPJ
                };
            }
        }

        private async Task<ResponseFornecedorOut> ObterFornecedorPorFornecedorId(Guid fornecedorId)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = fornecedorId.ToString(),
                Queue = "ObterFornecedorPorId",
            };

            var resp = await _publish.DoRPC<RequestIn, ResponseFornecedorOut>(mapIn);
            return _mapper.Map<ResponseFornecedorOut>(resp);
        }
    }
}
