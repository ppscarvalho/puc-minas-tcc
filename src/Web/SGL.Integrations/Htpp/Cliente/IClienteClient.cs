using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Cliente
{
    public interface IClienteClient : IApiClientBase
    {
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes(string token);
        Task<ClienteViewModel> ObterClientePorId(Guid id, string token);
        Task<DefaultResult> Adicionar(ClienteViewModel clienteViewModel, string token);
        Task<DefaultResult> Atualizar(ClienteViewModel clienteViewModel, string token);
    }
}
