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
            var fornecedor = await _context.TB_Fornecedores.FirstOrDefaultAsync(f => f.CpfCnpj == cpf);
            return (fornecedor);

        }

        public async Task<IEnumerable<Fornecedor>> GetAllAsync()
        {
            return await _context.TB_Fornecedores
                .Include(f => f.Endereco)
                .ToListAsync();
            
        }








    }
}
