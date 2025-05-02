using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IReadOnlyList<ProdutoRequestDto>> GetAllProdutosAsync();
        Task<ProdutoRequestDto> GetProdutoByIdAsync(int id);
        Task<ProdutoRequestDto> AddProdutoAsync(ProdutoRequestDto dto);
        Task<ProdutoRequestDto> UpdateProdutoAsync(int id, ProdutoRequestDto dto);
        Task<bool> DeleteProdutoAsync(int id);
    }
}
