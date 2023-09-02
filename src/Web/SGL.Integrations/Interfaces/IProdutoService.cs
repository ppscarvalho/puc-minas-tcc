using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoViewModel> ObterProdutoPorId(Guid id, string token);
        Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos(string token);
        Task<IEnumerable<CategoriaViewModel>> ObterTodasCategorias();
        Task<DefaultResult> Adicionar(ProdutoViewModel produtoViewModel, string token);
        Task<DefaultResult> Atualizar(ProdutoViewModel produtoViewModel, string token);
    }
}
