using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
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
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlFornecedor}/api/fornecedor/obter-todos", null, headers);
            return result.DeserializeObject<IEnumerable<FornecedorViewModel>>();
        }

        public async Task<FornecedorViewModel> ObterFornecedorPorId(Guid id, string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlFornecedor}/api/fornecedor/obter-por-id?id={id}", null, headers);
            return result.DeserializeObject<FornecedorViewModel>();
        }

        public async Task<DefaultResult> Adicionar(FornecedorViewModel fornecedorViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlFornecedor}/api/fornecedor/adicionar", fornecedorViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }

        public async Task<DefaultResult> Atualizar(FornecedorViewModel fornecedorViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlFornecedor}/api/fornecedor/atualizar", fornecedorViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }
    }
}
