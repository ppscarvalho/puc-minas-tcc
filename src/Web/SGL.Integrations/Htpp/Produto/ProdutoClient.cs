using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
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

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos()
        {
            var result = await Get($"{_apisOptions.BaseUrlProduto}/api/produto/obter-todos");
            var produto = result.DeserializeObject<IEnumerable<ProdutoViewModel>>();
            return produto;
        }

        public async Task<ProdutoViewModel> ObterProdutoPorId(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlProduto}/api/produto/obter-por-id", new { Id = id }, headers);
            return result.DeserializeObject<ProdutoViewModel>();
        }
    }
}
