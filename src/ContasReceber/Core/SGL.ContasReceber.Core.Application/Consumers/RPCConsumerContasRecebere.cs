using AutoMapper;
using MediatR;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Operators;
using SGL.ContasReceber.Core.Application.Queries.ContasReceber;
using SGL.MessageQueue.Models.ContasReceber;

namespace SGL.ContasReceber.Core.Application.Consumers
{
    public class RPCConsumerContasRecebere : Consumer<RequestIn>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public RPCConsumerContasRecebere(
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
                case "ObterContasReceberPorId":
                    await ObterContasReceberPorId(context);
                    break;

                case "ObterTodasContasReceber":
                    await ObterTodasContasReceber(context);
                    break;

                default:
                    await ObterTodasContasReceber(context);
                    break;
            }
        }

        private async Task ObterContasReceberPorId(ConsumerContext<RequestIn> context)
        {
            var id = Guid.Parse(context.Message.Result);
            var query = new ObterContasReceberPorIdQuery(id);
            var result = _mapper.Map<ResponseContasReceberOut>(await _mediatorQuery.Send(query));
            await context.RespondAsync(result);
        }
        private async Task ObterTodasContasReceber(ConsumerContext<RequestIn> context)
        {
            var result = _mapper.Map<IEnumerable<ResponseContasReceberOut>>(await _mediatorQuery.Send(new ObterTodasContasReceberQuery()));
            await context.RespondAsync(result.ToArray());
        }
    }
}
