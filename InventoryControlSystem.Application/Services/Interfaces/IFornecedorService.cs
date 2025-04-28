using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<Fornecedor> AddFornecedorAsync(Fornecedor fornecedor);
        Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync();
        Task UpdateFornecedorAsync (string cpfCnpj, Fornecedor fornecedor);
        Task DeleteFornecedorAsync(string cpfCnpj);
    }
}
