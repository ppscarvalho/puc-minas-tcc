using MediatR;
using SGL.Cliente.Core.Application.Models;

namespace SGL.Cliente.Core.Application.Queries.Cliente
{
    public class ObterClientePorIdQuery : IRequest<ClienteModel>
    {
        public Guid Id { get; private set; }

        public ObterClientePorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
