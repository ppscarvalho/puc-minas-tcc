#nullable disable

using AutoMapper;
using MediatR;
using SGL.Fornecedor.Core.Application.Queries.Fornecedor;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.Fornecedor;
using SGL.MessageQueue.Operators;

namespace SGL.Fornecedor.Core.Application.Consumers
{
    public class ConsumerFornecedor : Consumer<RequestIn>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public ConsumerFornecedor(
            IMapper mapper,
            IMediator mediatorQuery)
        {
            _mapper = mapper;
            _mediatorQuery = mediatorQuery;
        }

        public override async Task ConsumeContex(ConsumerContext<RequestIn> context)
        {
            switch (context.Message.Queue)
            {
                case "ObterFornecedorPorId":
                    await ObterFornecedorPorId(context);
                    break;

                case "ObterTodosFornecedores":
                    await ObterTodosFornecedores(context);
                    break;

                default:
                    await ObterTodosFornecedores(context);
                    break;
            }
        }

        private async Task ObterFornecedorPorId(ConsumerContext<RequestIn> context)
        {
            var id = Guid.Parse(context.Message.Result);
            var query = new ObterFornecedorPorIdQuery(id);
            var result = _mapper.Map<ResponseFornecedorOut>(await _mediatorQuery.Send(query));
            await context.RespondAsync(result);
        }

        private async Task ObterTodosFornecedores(ConsumerContext<RequestIn> context)
        {
            var result = _mapper.Map<IEnumerable<ResponseFornecedorOut>>(await _mediatorQuery.Send(new ObterTodosFornecedoresQuery()));
            await context.RespondAsync(result.ToArray());
        }
    }
}
