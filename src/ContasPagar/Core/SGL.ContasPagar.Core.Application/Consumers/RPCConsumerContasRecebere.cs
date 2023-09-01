using AutoMapper;
using MediatR;
using SGL.ContasPagar.Core.Application.Queries.ContasPagar;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.ContasPagar;
using SGL.MessageQueue.Operators;

namespace SGL.ContasPagar.Core.Application.Consumers
{
    public class RPCConsumerContasPagare : Consumer<RequestIn>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public RPCConsumerContasPagare(
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
                case "ObterContasPagarPorId":
                    await ObterContasPagarPorId(context);
                    break;

                case "ObterTodasContasPagar":
                    await ObterTodasContasPagar(context);
                    break;

                default:
                    await ObterTodasContasPagar(context);
                    break;
            }
        }

        private async Task ObterContasPagarPorId(ConsumerContext<RequestIn> context)
        {
            var id = Guid.Parse(context.Message.Result);
            var query = new ObterContasPagarPorIdQuery(id);
            var result = _mapper.Map<ResponseContasPagarOut>(await _mediatorQuery.Send(query));
            await context.RespondAsync(result);
        }
        private async Task ObterTodasContasPagar(ConsumerContext<RequestIn> context)
        {
            var result = _mapper.Map<IEnumerable<ResponseContasPagarOut>>(await _mediatorQuery.Send(new ObterTodasContasPagarQuery()));
            await context.RespondAsync(result.ToArray());
        }
    }
}
