using InventoryControlSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task AddAsync(Fornecedor fornecedor);
        Task<Fornecedor?> GetByCpfCnpjAsync(string cpfCnpj);
        Task<IReadOnlyList<Fornecedor>> GetAllAsync();
        Task UpdateAsync(Fornecedor fornecedor);
        Task DeleteAsync(Fornecedor fornecedor);
        Task<bool> ExistsAsync(string cpfCnpj);
    }
}