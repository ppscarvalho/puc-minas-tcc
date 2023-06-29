using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteViewModel> ObterClientePorId(Guid id);
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes();
        IEnumerable<EstadoViewModel> TodosEstados();
    }
}
