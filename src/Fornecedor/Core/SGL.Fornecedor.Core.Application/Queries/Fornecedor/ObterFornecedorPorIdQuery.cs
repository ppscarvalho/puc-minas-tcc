using MediatR;
using SGL.Fornecedor.Core.Application.Models;

namespace SGL.Fornecedor.Core.Application.Queries.Fornecedor
{
    public class ObterFornecedorPorIdQuery : IRequest<FornecedorModel>
    {
        public Guid Id { get; private set; }

        public ObterFornecedorPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
