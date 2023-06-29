using MediatR;
using SGL.MessageQueue.Models.Produto;

namespace SGL.Produto.Core.Application.Queries.Produto
{
    public class ObterTodosProdutosQuery : IRequest<IEnumerable<ResponseProdutoOut>>
    {
    }
}
