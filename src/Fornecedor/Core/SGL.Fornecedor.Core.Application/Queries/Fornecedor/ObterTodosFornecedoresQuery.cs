using MediatR;
using SGL.Fornecedor.Core.Application.Models;

namespace SGL.Fornecedor.Core.Application.Queries.Fornecedor
{
    public class ObterTodosFornecedoresQuery : IRequest<IEnumerable<FornecedorModel>>
    {
    }
}
