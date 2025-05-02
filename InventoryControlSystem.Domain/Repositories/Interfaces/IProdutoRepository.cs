using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IReadOnlyList<Produto>> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}
