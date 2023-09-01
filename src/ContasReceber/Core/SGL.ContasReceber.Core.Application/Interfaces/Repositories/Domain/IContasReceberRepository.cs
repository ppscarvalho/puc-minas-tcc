using SGL.Resource.Data;

namespace SGL.ContasReceber.Core.Application.Interfaces.Repositories.Domain
{
    public interface IContasReceberRepository : IRepository<Core.Domain.Entities.ContasReceber>
    {
        Task<IEnumerable<Core.Domain.Entities.ContasReceber>> ObterTodasContasReceber();
        Task<Core.Domain.Entities.ContasReceber> ObterContasReceberPorId(Guid id);
        Task<Core.Domain.Entities.ContasReceber> AdicionarContasReceber(Core.Domain.Entities.ContasReceber contasReceber);
        Task<Core.Domain.Entities.ContasReceber> AtualizarContasReceber(Core.Domain.Entities.ContasReceber contasReceber);
    }
}
