using SGL.Resource.Data;

namespace SGL.Produto.Core.Application.Interfaces.Repositories.Domain
{
    public interface IProdutoRepository : IRepository<Core.Domain.Entities.Produto>
    {
        Task<IEnumerable<Core.Domain.Entities.Produto>> ObterTodosProdutos();
        Task<Core.Domain.Entities.Produto> ObterProdutoPorId(Guid id);
        Task<Core.Domain.Entities.Produto> AdicionarProduto(Core.Domain.Entities.Produto produto);
        Task<Core.Domain.Entities.Produto> AtualizarProduto(Core.Domain.Entities.Produto produto);
        //Task<Core.Domain.Entities.Produto> AtualizarEstoque(Guid id, int estoque);
    }
}
