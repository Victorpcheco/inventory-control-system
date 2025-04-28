using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetByIdAsync(int id);
        Task<Produto> AddProdutoAsync(ProdutoRequestDto dto);
        Task UpdateProdutoAsync(int id, ProdutoRequestDto dto);
        Task DeleteProdutoAsync(int id);
    }
}
