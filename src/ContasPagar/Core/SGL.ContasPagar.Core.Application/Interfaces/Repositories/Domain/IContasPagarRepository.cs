using SGL.Resource.Data;

namespace SGL.ContasPagar.Core.Application.Interfaces.Repositories.Domain
{
    public interface IContasPagarRepository : IRepository<Core.Domain.Entities.ContasPagar>
    {
        Task<IEnumerable<Core.Domain.Entities.ContasPagar>> ObterTodasContasPagar();
        Task<Core.Domain.Entities.ContasPagar> ObterContasPagarPorId(Guid id);
        Task<Core.Domain.Entities.ContasPagar> AdicionarContasPagar(Core.Domain.Entities.ContasPagar contasPagar);
        Task<Core.Domain.Entities.ContasPagar> AtualizarContasPagar(Core.Domain.Entities.ContasPagar contasPagar);
    }
}
