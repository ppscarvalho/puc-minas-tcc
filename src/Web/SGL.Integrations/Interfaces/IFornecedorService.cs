using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Interfaces
{
    public interface IFornecedorService
    {
        Task<FornecedorViewModel> ObterFornecedorPorId(Guid id);
        Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores(string token);
        IEnumerable<EstadoViewModel> TodosEstados();
    }
}
