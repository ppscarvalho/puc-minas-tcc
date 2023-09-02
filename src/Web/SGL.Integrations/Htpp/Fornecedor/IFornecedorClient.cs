using SGL.Integrations.ViewModels;
using SGL.Resource.Util;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.Fornecedor
{
    public interface IFornecedorClient : IApiClientBase
    {
        Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores(string token);
        Task<FornecedorViewModel> ObterFornecedorPorId(Guid id, string token);
        Task<DefaultResult> Adicionar(FornecedorViewModel fornecedorViewModel, string token);
        Task<DefaultResult> Atualizar(FornecedorViewModel fornecedorViewModel, string token);
    }
}
