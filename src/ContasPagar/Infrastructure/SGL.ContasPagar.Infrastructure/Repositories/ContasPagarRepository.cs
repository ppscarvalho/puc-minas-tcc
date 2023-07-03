#nullable disable

using Microsoft.EntityFrameworkCore;
using SGL.ContasPagar.Core.Application.Interfaces.Repositories.Domain;
using SGL.ContasPagar.Infrastructure.DbContexts;
using SGL.Resource.Data;

namespace SGL.ContasPagar.Infrastructure.Repositories
{
    public class ContasPagarRepository : IContasPagarRepository
    {
        private readonly ContasPagarDbContext _context;
        private bool disposedValue;

        public ContasPagarRepository(ContasPagarDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Core.Domain.Entities.ContasPagar>> ObterTodasContasPagar()
        {
            return await _context.ContasPagar.AsNoTracking().OrderBy(c => c.Descricao).ToListAsync();
        }

        public async Task<Core.Domain.Entities.ContasPagar> ObterContasPagarPorId(Guid id)
        {
            return await _context.ContasPagar.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Core.Domain.Entities.ContasPagar> AdicionarContasPagar(Core.Domain.Entities.ContasPagar contasPagar)
        {
            return (await _context.AddAsync(contasPagar)).Entity;
        }

        public async Task<Core.Domain.Entities.ContasPagar> AtualizarContasPagar(Core.Domain.Entities.ContasPagar contasPagar)
        {
            await Task.CompletedTask;
            _context.Entry(contasPagar).State = EntityState.Modified;
            return contasPagar;
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
