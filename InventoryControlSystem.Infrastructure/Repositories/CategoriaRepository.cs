using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using InventoryControlSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Usa AsNoTracking para melhorar performance em consultas de leitura.
        // Retorna IReadOnlyList para evitar modificações externas.
        public async Task<IReadOnlyList<Categoria>> GetAllAsync()
        {
            return await _context.TB_Categorias
                .AsNoTracking()
                .ToListAsync();
        }

        // Retorna nullable (Categoria?) para indicar que pode não encontrar resultado.
        // Usa AsNoTracking para leitura.
        public async Task<Categoria?> GetByNomeAsync(string nome)
        {
            return await _context.TB_Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.TB_Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.TB_Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        // Checa se a categoria existe antes de remover para evitar exceção.
        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.TB_Categorias.FindAsync(id);
            if (categoria is null) return; // Ou lance uma exceção customizada
            _context.TB_Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        // Retorna nullable (Categoria?) e usa AsNoTracking para leitura.
        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _context.TB_Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

