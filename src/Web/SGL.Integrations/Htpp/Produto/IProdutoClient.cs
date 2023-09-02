using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Produto
{
    public interface IProdutoClient : IApiClientBase
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos(string token);

        Task<ProdutoViewModel> ObterProdutoPorId(Guid id, string token);

        Task<DefaultResult> Adicionar(ProdutoViewModel produtoViewModel, string token);

        Task<DefaultResult> Atualizar(ProdutoViewModel produtoViewModel, string token);
    }
}
