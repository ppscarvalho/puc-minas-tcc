using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Interfaces
{
    public interface IFornecedorService
    {
        Task<FornecedorViewModel> ObterFornecedorPorId(Guid id, string token);
        Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores(string token);
        IEnumerable<EstadoViewModel> TodosEstados();
        Task<DefaultResult> Adicionar(FornecedorViewModel fornecedorViewModel, string token);
        Task<DefaultResult> Atualizar(FornecedorViewModel fornecedorViewModel, string token);
    }
}
