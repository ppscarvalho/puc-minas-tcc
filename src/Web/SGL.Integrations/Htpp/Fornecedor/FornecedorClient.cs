using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;
using SGL.Util.Extensions;
using SGL.Util.Options;

namespace SGL.Integrations.Htpp.Fornecedor
{
    public class FornecedorClient : ApiClientBase, IFornecedorClient
    {
        private readonly APIsOptions _apisOptions;

        public FornecedorClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores(string token)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {token}" } };
            var result = await Get($"{_apisOptions.BaseUrlFornecedor}/api/fornecedor/obter-todos", null, headers);
            return result.DeserializeObject<IEnumerable<FornecedorViewModel>>();
        }

        public async Task<FornecedorViewModel> ObterFornecedorPorId(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Get($"{_apisOptions.BaseUrlFornecedor}/api/fornecedor/obter-por-id", new { Id = id }, headers);
            return result.DeserializeObject<FornecedorViewModel>();
        }
    }
}
