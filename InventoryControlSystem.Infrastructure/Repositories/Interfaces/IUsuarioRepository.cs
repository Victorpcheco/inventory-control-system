using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<Usuario> GetByMatriculaAndSenhaAsync(string matricula, string senha);
        Task<bool> MatriculaExisteAsync(string matricula);
        Task AddUsuarioAsync (Usuario usuario);
        Task AddRefreshTokenAsync (RefreshTokens refreshToken);

    }
}
