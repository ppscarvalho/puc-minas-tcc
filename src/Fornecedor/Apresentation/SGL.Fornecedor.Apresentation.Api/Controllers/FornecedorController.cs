using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.Fornecedor.Apresentation.Api.Controllers.BaseController;
using SGL.Fornecedor.Core.Application.Commands.Fornecedor;
using SGL.Fornecedor.Core.Application.Models;
using SGL.Fornecedor.Core.Application.Queries.Fornecedor;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.Fornecedor.Apresentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerConfiguration
    {
        private readonly ILogger<FornecedorController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public FornecedorController(
            ILogger<FornecedorController> logger,
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
        [ProducesResponseType(typeof(FornecedorModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterFornecedorPorId([FromQuery] Guid id)
        {
            _logger.LogInformation("Obter todos os Fornecedors");
            var result = await _mediatorQuery.Send(new ObterFornecedorPorIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        [Route("obter-todos")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FornecedorModel), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> ObterTodosFornecedores()
        {
            _logger.LogInformation("Obter todos os fornecedores");
            var result = await _mediatorQuery.Send(new ObterTodosFornecedoresQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("adicionar")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> AdicionarFornecedor([FromBody] FornecedorModel fornecedorModel)
        {
            var cmd = _mapper.Map<AdicionarFornecedorCommand>(fornecedorModel);
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
        public async Task<ActionResult<DefaultResult>> AtualizarFornecedor([FromBody] FornecedorModel fornecedorModel)
        {
            var cmd = _mapper.Map<AtualizarFornecedorCommand>(fornecedorModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }
    }
}
