using MediatR;
using SGL.MessageQueue.Models.Produto;

namespace SGL.Produto.Core.Application.Queries.Produto
{
    public class ObterProdutoPorIdQuery : IRequest<ResponseProdutoOut>
    {
        public Guid Id { get; private set; }

        public ObterProdutoPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
