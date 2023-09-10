using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.ContasReceber
{
    public interface IContasReceberClient : IApiClientBase
    {
        Task<IEnumerable<ContasReceberViewModel>> ObterTodasContasReceber(string token);
        Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id, string token);
        Task<DefaultResult> Adicionar(ContasReceberViewModel contasReceberViewModel, string token);
        Task<DefaultResult> Atualizar(ContasReceberViewModel contasReceberViewModel, string token);
    }
}
