using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.Fornecedor;
using SGL.MessageQueue.Models.Produto;
using SGL.MessageQueue.Operators;
using SGL.Produto.Apresentation.Api.Controllers.BaseController;
using SGL.Produto.Core.Application.Commands.Produto;
using SGL.Produto.Core.Application.Models;
using SGL.Produto.Core.Application.Queries.Produto;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.Produto.Apresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerConfiguration
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;
        private readonly IPublish _publish;
        public ProdutoController(
            ILogger<ProdutoController> logger,
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
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterProdutoPorId([FromQuery] Guid id)
        {
            _logger.LogInformation("Obter todos os produtos");
            var result = await _mediatorQuery.Send(new ObterProdutoPorIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        [Route("obter-todos")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseProdutoOut), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> ObterTodosProdutos()
        {
            _logger.LogInformation("Obter todos os Produtos");
            var result = await _mediatorQuery.Send(new ObterTodosProdutosQuery());
            await ObterFornecedorPorIdProduto(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("adicionar")]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DefaultResult>> AdicionarProduto([FromBody] ProdutoModel produtoModel)
        {
            var cmd = _mapper.Map<AdicionarProdutoCommand>(produtoModel);
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
        public async Task<ActionResult<DefaultResult>> AtualizarProduto([FromBody] ProdutoModel ProdutoModel)
        {
            var cmd = _mapper.Map<AtualizarProdutoCommand>(ProdutoModel);
            var result = await _mediatorHandler.SendCommand(cmd);

            if (ValidOperation())
                return Ok(result);
            else
                return BadRequest(GetMessageError());
        }

        private async Task ObterFornecedorPorIdProduto(IEnumerable<ResponseProdutoOut> result)
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
                    RazaoSocial = fornecedor?.RazaoSocial,
                    NomeFantasia = fornecedor?.NomeFantasia,
                    CNPJ = fornecedor?.CNPJ
                };
            }
        }
    }
}
