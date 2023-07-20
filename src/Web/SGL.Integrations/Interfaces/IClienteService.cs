using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteViewModel> ObterClientePorId(Guid id, string token);
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes(string token);
        IEnumerable<EstadoViewModel> TodosEstados();
    }
}
