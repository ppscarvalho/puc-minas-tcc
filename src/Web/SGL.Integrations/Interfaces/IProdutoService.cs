using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoViewModel> ObterProdutoPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos();
    }
}
