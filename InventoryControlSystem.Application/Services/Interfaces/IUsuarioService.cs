using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<(string JwtToken, string RefreshToken)> RegisterAsync(Usuario usuario);
        Task<(string JwtToken, string RefreshToken)> LoginAsync(string matricula, string senha); 
        Task DeleteUserAsync(string matricula);
    }
}
