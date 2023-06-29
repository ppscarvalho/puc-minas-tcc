#nullable disable

using Microsoft.EntityFrameworkCore;
using SGL.Cliente.Core.Application.Interfaces.Repositories.Domain;
using SGL.Cliente.Infrastructure.DbContexts;
using SGL.Resource.Data;

namespace SGL.Cliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;
        private bool disposedValue;

        public ClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Core.Domain.Entities.Cliente>> ObterTodosClientes()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }

        public async Task<Core.Domain.Entities.Cliente> ObterClientePorId(Guid id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Core.Domain.Entities.Cliente> AdicionarCliente(Core.Domain.Entities.Cliente cliente)
        {
            return (await _context.AddAsync(cliente)).Entity;
        }

        public async Task<Core.Domain.Entities.Cliente> AtualizarCliente(Core.Domain.Entities.Cliente cliente)
        {
            await Task.CompletedTask;
            return (_context.Cliente.Update(cliente)).Entity;
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
