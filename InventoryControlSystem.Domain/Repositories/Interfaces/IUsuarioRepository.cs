using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<Usuario> GetByMatriculaAndSenhaAsync(string matricula, string senha);
        Task<bool> MatriculaExisteAsync(string matricula);
        Task AddUsuarioAsync (Usuario usuario);
        Task AddRefreshTokenAsync (RefreshTokens refreshToken);

        Task deleteUserAsync(string matricula);

    }
}
