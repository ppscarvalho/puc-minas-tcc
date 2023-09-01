using MediatR;
using SGL.MessageQueue.Models.ContasPagar;

namespace SGL.ContasPagar.Core.Application.Queries.ContasPagar
{
    public class ObterContasPagarPorIdQuery : IRequest<ResponseContasPagarOut>
    {
        public Guid Id { get; private set; }
        public ObterContasPagarPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
