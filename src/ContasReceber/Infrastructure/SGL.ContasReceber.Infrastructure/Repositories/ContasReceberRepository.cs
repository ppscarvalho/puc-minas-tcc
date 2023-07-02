#nullable disable

using Microsoft.EntityFrameworkCore;
using SGL.ContasReceber.Core.Application.Interfaces.Repositories.Domain;
using SGL.ContasReceber.Infrastructure.DbContexts;
using SGL.Resource.Data;

namespace SGL.ContasReceber.Infrastructure.Repositories
{
    public class ContasReceberRepository : IContasReceberRepository
    {
        private readonly ContasReceberDbContext _context;
        private bool disposedValue;

        public ContasReceberRepository(ContasReceberDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Core.Domain.Entities.ContasReceber>> ObterTodasContasReceber()
        {
            return await _context.ContasReceber.AsNoTracking().OrderBy(c => c.Descricao).ToListAsync();
        }

        public async Task<Core.Domain.Entities.ContasReceber> ObterContasReceberPorId(Guid id)
        {
            return await _context.ContasReceber.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Core.Domain.Entities.ContasReceber> AdicionarContasReceber(Core.Domain.Entities.ContasReceber contasReceber)
        {
            return (await _context.AddAsync(contasReceber)).Entity;
        }

        public async Task<Core.Domain.Entities.ContasReceber> AtualizarContasReceber(Core.Domain.Entities.ContasReceber contasReceber)
        {
            await Task.CompletedTask;
            _context.Entry(contasReceber).State = EntityState.Modified;
            return contasReceber;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
