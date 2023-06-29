using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Cliente
{
    public interface IClienteClient : IApiClientBase
    {
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes();
        Task<ClienteViewModel> ObterClientePorId(Guid id);
    }
}
