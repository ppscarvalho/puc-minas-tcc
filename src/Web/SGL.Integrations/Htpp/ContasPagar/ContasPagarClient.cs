
using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;
using SGL.Util.Extensions;
using SGL.Util.Options;

namespace SGL.Integrations.Htpp.ContasPagar
{
    public class ContasPagarClient : ApiClientBase, IContasPagarClient
    {
        private readonly APIsOptions _apisOptions;

        public ContasPagarClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<ContasPagarViewModel>> ObterTodasContasPagar(string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlContasPagar}/api/contaspagar/obter-todas", null, headers);
            return result.DeserializeObject<IEnumerable<ContasPagarViewModel>>();
        }

        public async Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id, string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlContasPagar}/api/contaspagar/obter-por-id?id={id}", null, headers);
            return result.DeserializeObject<ContasPagarViewModel>();
        }

        public async Task<DefaultResult> Adicionar(ContasPagarViewModel contasPagarViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlContasPagar}/api/contaspagar/adicionar", contasPagarViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }

        public async Task<DefaultResult> Atualizar(ContasPagarViewModel contasPagarViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlContasPagar}/api/contaspagar/atualizar", contasPagarViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }
    }
}
