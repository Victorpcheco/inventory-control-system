using InventoryControlSystem.Application.DTOS;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IReadOnlyList<CategoriaRequestDto>> GetAllAsync();
        Task<CategoriaRequestDto> GetCategoriaByNome(string nome);
        Task<CategoriaRequestDto> CreateCategoriaAsync(CategoriaRequestDto dto);
        Task<bool> UpdateCategoriaAsync(int id, CategoriaRequestDto dto);
        Task<bool> DeleteCategoriaAsync(int id);
    }
}
