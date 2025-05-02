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

        public async Task<IReadOnlyList<Fornecedor>> GetAllAsync()
        {
            return await _context.TB_Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .ToListAsync();
        }

        public async Task<Fornecedor?> GetByCpfCnpjAsync(string cpfCnpj)
        {
            return await _context.TB_Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.CpfCnpj == cpfCnpj);
        }

        public async Task AddAsync(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            await _context.TB_Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            _context.TB_Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            _context.TB_Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string cpfCnpj)
        {
            return await _context.TB_Fornecedores.AnyAsync(f => f.CpfCnpj == cpfCnpj);
        }
    }
}