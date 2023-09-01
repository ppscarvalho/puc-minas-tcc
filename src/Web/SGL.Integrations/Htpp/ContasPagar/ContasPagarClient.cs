using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
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

        public async Task<IEnumerable<ContasPagarViewModel>> ObterTodasContasPagar()
        {
            var result = await Get($"{_apisOptions.BaseUrlContasPagar}/api/contaspagar/obter-todas");
            var ContasPagar = result.DeserializeObject<IEnumerable<ContasPagarViewModel>>();
            return ContasPagar;
        }

        public async Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Get($"{_apisOptions.BaseUrlContasPagar}/api/contaspagar/obter-por-id", new { Id = id }, headers);
            return result.DeserializeObject<ContasPagarViewModel>();
        }
    }
}
