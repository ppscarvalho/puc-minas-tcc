using Microsoft.Extensions.Options;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
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

        public async Task<IEnumerable<ClienteViewModel>> ObterTodosClientes(string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlCliente}/api/cliente/obter-todos", null, headers);
            return result.DeserializeObject<IEnumerable<ClienteViewModel>>();
        }

        public async Task<ClienteViewModel> ObterClientePorId(Guid id, string token)
        {
            var headers = SetHeaders(token);
            var result = await Get($"{_apisOptions.BaseUrlCliente}/api/cliente/obter-por-id?id={id}", null, headers);
            return result.DeserializeObject<ClienteViewModel>();
        }

        public async Task<DefaultResult> Adicionar(ClienteViewModel clienteViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlCliente}/api/cliente/adicionar", clienteViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }

        public async Task<DefaultResult> Atualizar(ClienteViewModel clienteViewModel, string token)
        {
            var headers = SetHeaders(token);
            var result = await Post($"{_apisOptions.BaseUrlCliente}/api/cliente/atualizar", clienteViewModel, headers);
            return result.DeserializeObject<DefaultResult>();
        }
    }
}
