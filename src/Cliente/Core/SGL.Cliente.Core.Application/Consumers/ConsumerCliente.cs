#nullable disable

using AutoMapper;
using MediatR;
using SGL.Cliente.Core.Application.Queries.Cliente;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Operators;
using SGL.MessageQueue.Models.Cliente;

namespace SGL.Cliente.Core.Application.Consumers
{
    public class ConsumerCliente : Consumer<RequestIn>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatorQuery;

        public ConsumerCliente(
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
                case "ObterClientePorId":
                    await ObterClientePorId(context);
                    break;

                case "ObterTodosClientes":
                    await ObterTodosClientes(context);
                    break;

                default:
                    await ObterTodosClientes(context);
                    break;
            }
        }

        private async Task ObterClientePorId(ConsumerContext<RequestIn> context)
        {
            var id = Guid.Parse(context.Message.Result);
            var query = new ObterClientePorIdQuery(id);
            var result = _mapper.Map<ResponseClienteOut>(await _mediatorQuery.Send(query));
            await context.RespondAsync(result);
        }
        private async Task ObterTodosClientes(ConsumerContext<RequestIn> context)
        {
            var result = _mapper.Map<IEnumerable<ResponseClienteOut>>(await _mediatorQuery.Send(new ObterTodosClientesQuery()));
            await context.RespondAsync(result.ToArray());
        }
    }
}
