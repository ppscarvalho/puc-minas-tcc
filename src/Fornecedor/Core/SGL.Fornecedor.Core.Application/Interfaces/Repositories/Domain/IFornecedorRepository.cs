using SGL.Resource.Data;

namespace SGL.Fornecedor.Core.Application.Interfaces.Repositories.Domain
{
    public interface IFornecedorRepository : IRepository<Core.Domain.Entities.Fornecedor>
    {
        Task<IEnumerable<Core.Domain.Entities.Fornecedor>> ObterTodosFornecedores();
        Task<Core.Domain.Entities.Fornecedor> ObterFornecedorPorId(Guid id);
        Task<Core.Domain.Entities.Fornecedor> AdicionarFornecedor(Core.Domain.Entities.Fornecedor fornecedor);
        Task<Core.Domain.Entities.Fornecedor> AtualizarFornecedor(Core.Domain.Entities.Fornecedor fornecedor);
    }
}
