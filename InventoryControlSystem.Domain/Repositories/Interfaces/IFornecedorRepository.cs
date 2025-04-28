using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task AddAsync(Fornecedor fornecedor);
        Task<Fornecedor> GetByCpfCnpj(string  cpf);
    }
}
