using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using InventoryControlSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync (Fornecedor fornecedor)
        {
            await _context.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Fornecedor> GetByCpfCnpj(string cpf)
        {
            return await _context.TB_Fornecedores
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.CpfCnpj == cpf);
        }

        public async Task<IEnumerable<Fornecedor>> GetAllAsync()
        {
            return await _context.TB_Fornecedores
                .Include(f => f.Endereco)
                .ToListAsync();
            
        }

        public async Task UpdateAsync(Fornecedor fornecedor)
        {
            _context.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Fornecedor fornecedor)
        {
            _context.Remove(fornecedor);
            await _context.SaveChangesAsync();
        }







    }
}
