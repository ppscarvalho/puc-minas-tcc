using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Interfaces
{
    public interface IContasPagarService
    {
        Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id);
        Task<IEnumerable<ContasPagarViewModel>> ObterTodasContasPagar();
    }
}
