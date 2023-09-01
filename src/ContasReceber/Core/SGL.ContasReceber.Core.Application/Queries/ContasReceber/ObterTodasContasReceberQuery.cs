using MediatR;
using SGL.MessageQueue.Models.ContasReceber;

namespace SGL.ContasReceber.Core.Application.Queries.ContasReceber
{
    public class ObterTodasContasReceberQuery : IRequest<IEnumerable<ResponseContasReceberOut>>
    {
    }
}
