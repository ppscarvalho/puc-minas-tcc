using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Fornecedor
{
    public interface IFornecedorClient : IApiClientBase
    {
        Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores();
        Task<FornecedorViewModel> ObterFornecedorPorId(Guid id);
    }
}
