using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;
using SGL.Util.Extensions;
using SGL.Util.Options;

namespace SGL.Integrations.Htpp.Cliente
{
    public class ClienteClient : ApiClientBase, IClienteClient
    {
        private readonly APIsOptions _apisOptions;

        public ClienteClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterTodosClientes()
        {
            var result = await Get($"{_apisOptions.BaseUrlCliente}/api/cliente/obter-todos");
            return result.DeserializeObject<IEnumerable<ClienteViewModel>>();
        }

        public async Task<ClienteViewModel> ObterClientePorId(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlCliente}/api/cliente/obter-por-id", new { Id = id }, headers);
            return result.DeserializeObject<ClienteViewModel>();
        }
    }
}
