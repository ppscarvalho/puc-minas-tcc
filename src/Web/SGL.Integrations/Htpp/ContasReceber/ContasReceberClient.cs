using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
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

        public async Task<IEnumerable<ContasReceberViewModel>> ObterTodasContasReceber()
        {
            var result = await Get($"{_apisOptions.BaseUrlContasReceber}/api/contasreceber/obter-todas");
            var ContasReceber = result.DeserializeObject<IEnumerable<ContasReceberViewModel>>();
            return ContasReceber;
        }

        public async Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlContasReceber}/api/contasreceber/obter-por-id", new { Id = id }, headers);
            return result.DeserializeObject<ContasReceberViewModel>();
        }
    }
}
