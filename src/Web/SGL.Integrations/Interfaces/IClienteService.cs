using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Interfaces
{
    public interface IClienteService
    {
        Task<DefaultResult> Adicionar(ClienteViewModel clienteViewModel, string token);
        Task<DefaultResult> Atualizar(ClienteViewModel clienteViewModel, string token);
        Task<ClienteViewModel> ObterClientePorId(Guid id, string token);
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes(string token);
        IEnumerable<EstadoViewModel> TodosEstados();
    }
}
