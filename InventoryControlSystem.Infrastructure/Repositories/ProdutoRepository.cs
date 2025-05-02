using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using InventoryControlSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Produto>> GetAllAsync()
        {
            return await _context.TB_Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.TB_Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.TB_Produtos.AnyAsync(p => p.Id == id);
        }

        public async Task AddAsync(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));
            await _context.TB_Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));
            _context.TB_Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));
            _context.TB_Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}