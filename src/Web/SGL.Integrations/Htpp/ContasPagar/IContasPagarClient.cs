using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.ContasPagar
{
    public interface IContasPagarClient : IApiClientBase
    {
        Task<IEnumerable<ContasPagarViewModel>> ObterTodasContasPagar(string token);
        Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id, string token);
        Task<DefaultResult> Adicionar(ContasPagarViewModel contasPagarViewModel, string token);
        Task<DefaultResult> Atualizar(ContasPagarViewModel contasPagarViewModel, string token);
    }
}
