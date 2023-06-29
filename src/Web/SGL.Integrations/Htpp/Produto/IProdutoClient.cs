using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Produto
{
    public interface IProdutoClient : IApiClientBase
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos();
        Task<ProdutoViewModel> ObterProdutoPorId(Guid id);
    }
}
