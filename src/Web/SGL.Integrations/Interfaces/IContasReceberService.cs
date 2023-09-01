using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Interfaces
{
    public interface IContasReceberService
    {
        Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id);
        Task<IEnumerable<ContasReceberViewModel>> ObterTodasContasReceber();
    }
}
