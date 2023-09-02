using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;
using SGL.Util.Extensions;
using SGL.Util.Options;

namespace SGL.Integrations.Htpp.Produto
{
    public class ProdutoClient : ApiClientBase, IProdutoClient
    {
        private readonly APIsOptions _apisOptions;

        public ProdutoClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos(string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlProduto}/api/produto/obter-todos", null, headers);
            return result.DeserializeObject<IEnumerable<ProdutoViewModel>>();
        }

        public async Task<ProdutoViewModel> ObterProdutoPorId(Guid id, string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlProduto}/api/produto/obter-por-id?id={id}", null, headers);
            return result.DeserializeObject<ProdutoViewModel>();
        }



        public async Task<DefaultResult> Adicionar(ProdutoViewModel produtoViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlProduto}/api/produto/adicionar", produtoViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }

        public async Task<DefaultResult> Atualizar(ProdutoViewModel produtoViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlProduto}/api/produto/atualizar", produtoViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }
    }
}
