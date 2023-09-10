using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Interfaces
{
    public interface IContasReceberService
    {
        Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id, string token);
        Task<IEnumerable<ContasReceberViewModel>> ObterTodosContasRecebers(string token);
        IEnumerable<ContasReceberSituacaoViewModel> TodosStatus();
        Task<DefaultResult> Adicionar(ContasReceberViewModel contasReceberViewModel, string token);
        Task<DefaultResult> Atualizar(ContasReceberViewModel contasReceberViewModel, string token);
    }
}
