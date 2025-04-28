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



        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.TB_Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.TB_Produtos
                .Include(p => p.Categoria) // Inclui as informações da Categoria
                .Include(p => p.Fornecedor) // Inclui as informações do Fornecedor
                .FirstOrDefaultAsync(p => p.Id == id); // Filtra pelo ID do produto
        }


        public async Task AddAsync(Produto produto)
        {
            await _context.TB_Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.TB_Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produto produto)
        {
           
            _context.TB_Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            
        }

    }
}
