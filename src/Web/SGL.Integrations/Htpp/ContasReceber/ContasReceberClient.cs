using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;
using SGL.Util.Extensions;
using SGL.Util.Options;

namespace SGL.Integrations.Htpp.ContasReceber
{
    public class ContasReceberClient : ApiClientBase, IContasReceberClient
    {
        private readonly APIsOptions _apisOptions;

        public ContasReceberClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<ContasReceberViewModel>> ObterTodasContasReceber(string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlContasReceber}/api/contasreceber/obter-todas", null, headers);
            return result.DeserializeObject<IEnumerable<ContasReceberViewModel>>();
        }

        public async Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id, string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlContasReceber}/api/contasreceber/obter-por-id?id={id}", null, headers);
            return result.DeserializeObject<ContasReceberViewModel>();
        }

        public async Task<DefaultResult> Adicionar(ContasReceberViewModel contasReceberViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlContasReceber}/api/contasreceber/adicionar", contasReceberViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }

        public async Task<DefaultResult> Atualizar(ContasReceberViewModel contasReceberViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlContasReceber}/api/contasreceber/atualizar", contasReceberViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }
    }
}
