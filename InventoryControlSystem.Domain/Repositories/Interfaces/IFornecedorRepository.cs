using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task AddAsync(Fornecedor fornecedor);
        Task<Fornecedor> GetByCpfCnpj(string  cpf);
        Task<IEnumerable<Fornecedor>> GetAllAsync();
        Task UpdateAsync(Fornecedor fornecedor);
    }
}
