using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _context.TB_Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByNome(string nome)
        {
            return await _context.TB_Categorias
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

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.TB_Categorias.FindAsync(id);
            _context.TB_Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.TB_Categorias.FindAsync(id);
        }




    }
}
