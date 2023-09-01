using MediatR;
using SGL.MessageQueue.Models.ContasReceber;

namespace SGL.ContasReceber.Core.Application.Queries.ContasReceber
{
    public class ObterContasReceberPorIdQuery : IRequest<ResponseContasReceberOut>
    {
        public Guid Id { get; private set; }
        public ObterContasReceberPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
