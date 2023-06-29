#nullable disable

using Microsoft.EntityFrameworkCore;
using SGL.Produto.Core.Application.Interfaces.Repositories.Domain;
using SGL.Produto.Infrastructure.DbContexts;
using SGL.Resource.Data;

namespace SGL.Produto.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _context;
        private bool disposedValue;

        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Core.Domain.Entities.Produto>> ObterTodosProdutos()
        {
            return await _context.Produto
                .AsNoTracking()
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Core.Domain.Entities.Produto> ObterProdutoPorId(Guid id)
        {
            return await _context.Produto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Core.Domain.Entities.Produto> AdicionarProduto(Core.Domain.Entities.Produto produto)
        {
            return (await _context.AddAsync(produto)).Entity;
        }

        public async Task<Core.Domain.Entities.Produto> AtualizarProduto(Core.Domain.Entities.Produto produto)
        {
            await Task.CompletedTask;
            return (_context.Produto.Update(produto)).Entity;
        }

        //public Task<Core.Domain.Entities.Produto> AtualizarEstoque(Guid id, int estoque)
        //{
        //    throw new NotImplementedException();
        //}

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
