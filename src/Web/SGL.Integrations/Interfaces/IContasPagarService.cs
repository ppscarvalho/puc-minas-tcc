using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Interfaces
{
    public interface IContasPagarService
    {
        Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id, string token);
        Task<IEnumerable<ContasPagarViewModel>> ObterTodosContasPagars(string token);
        Task<DefaultResult> Adicionar(ContasPagarViewModel contasPagarViewModel, string token);
        Task<DefaultResult> Atualizar(ContasPagarViewModel contasPagarViewModel, string token);
    }
}
