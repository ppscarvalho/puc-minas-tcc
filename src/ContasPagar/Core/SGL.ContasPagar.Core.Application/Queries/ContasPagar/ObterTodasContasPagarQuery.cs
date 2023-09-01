using MediatR;
using SGL.MessageQueue.Models.ContasPagar;

namespace SGL.ContasPagar.Core.Application.Queries.ContasPagar
{
    public class ObterTodasContasPagarQuery : IRequest<IEnumerable<ResponseContasPagarOut>>
    {
    }
}
