#nullable disable

using Microsoft.EntityFrameworkCore;
using SGL.Fornecedor.Core.Application.Interfaces.Repositories.Domain;
using SGL.Fornecedor.Infrastructure.DbContexts;
using SGL.Resource.Data;

namespace SGL.Fornecedor.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly FornecedorDbContext _context;
        private bool disposedValue;

        public FornecedorRepository(FornecedorDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Core.Domain.Entities.Fornecedor>> ObterTodosFornecedores()
        {
            return await _context.Fornecedor.AsNoTracking().ToListAsync();
        }

        public async Task<Core.Domain.Entities.Fornecedor> ObterFornecedorPorId(Guid id)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Core.Domain.Entities.Fornecedor> AdicionarFornecedor(Core.Domain.Entities.Fornecedor Fornecedor)
        {
            return (await _context.AddAsync(Fornecedor)).Entity;
        }

        public async Task<Core.Domain.Entities.Fornecedor> AtualizarFornecedor(Core.Domain.Entities.Fornecedor Fornecedor)
        {
            await Task.CompletedTask;
            return (_context.Fornecedor.Update(Fornecedor)).Entity;
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
