using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Cliente
{
    public interface IClienteClient : IApiClientBase
    {
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes(string token);
        Task<ClienteViewModel> ObterClientePorId(Guid id, string token);
    }
}
