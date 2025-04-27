using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface ICategoriaService
    {


        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetCategoriaByNome(string nome);
        Task<CategoriaRequestDto> CreateCategoriaAsync(CategoriaRequestDto dto);
        Task<bool> UpdateCategoriaAsync(int id, CategoriaRequestDto dto);
        Task<bool> DeleteCategoriaAsync(int id);










    }
}
