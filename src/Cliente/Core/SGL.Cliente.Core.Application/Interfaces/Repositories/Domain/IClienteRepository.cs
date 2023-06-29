using SGL.Resource.Data;

namespace SGL.Cliente.Core.Application.Interfaces.Repositories.Domain
{
    public interface IClienteRepository : IRepository<Core.Domain.Entities.Cliente>
    {
        Task<IEnumerable<Core.Domain.Entities.Cliente>> ObterTodosClientes();
        Task<Core.Domain.Entities.Cliente> ObterClientePorId(Guid id);
        Task<Core.Domain.Entities.Cliente> AdicionarCliente(Core.Domain.Entities.Cliente cliente);
        Task<Core.Domain.Entities.Cliente> AtualizarCliente(Core.Domain.Entities.Cliente cliente);
    }
}
