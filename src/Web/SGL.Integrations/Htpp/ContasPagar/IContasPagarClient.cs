using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.ContasPagar
{
    public interface IContasPagarClient : IApiClientBase
    {
        Task<IEnumerable<ContasPagarViewModel>> ObterTodasContasPagar();
        Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id);
    }
}
