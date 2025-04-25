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

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.TB_Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> DeleteAsync(string nome)
        {
            var categoria = await GetCategoriaByNome(nome);
            if (categoria == null)
                return false;
            _context.TB_Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }




    }
}
