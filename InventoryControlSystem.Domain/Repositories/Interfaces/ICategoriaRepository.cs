using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {

        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task<Categoria> GetCategoriaByNome(string nome);
        Task AddAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
       
    }
}
