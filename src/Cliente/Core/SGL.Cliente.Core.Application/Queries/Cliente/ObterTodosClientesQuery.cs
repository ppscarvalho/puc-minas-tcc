using MediatR;
using SGL.Cliente.Core.Application.Models;

namespace SGL.Cliente.Core.Application.Queries.Cliente
{
    public class ObterTodosClientesQuery : IRequest<IEnumerable<ClienteModel>>
    {
    }
}
