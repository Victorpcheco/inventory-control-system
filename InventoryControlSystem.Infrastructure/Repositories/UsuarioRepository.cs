using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using InventoryControlSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Domain.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        // Busca o usuário pelo número da matrícula e senha
        public async Task<Usuario> GetByMatriculaAndSenhaAsync(string matricula, string senha)
        {
            return await _context.TB_Usuarios
                .FirstOrDefaultAsync(u => u.Matricula == matricula && u.Senha == senha);
        }
        // Verifica se a matrícula já existe
        public async Task<bool> MatriculaExisteAsync(string matricula)
        {
           return  await _context.TB_Usuarios.AnyAsync(u => u.Matricula == matricula);
        }
        // Adiciona um novo usuário
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _context.TB_Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        // Adiciona um novo refresh token
        public async Task AddRefreshTokenAsync(RefreshTokens refreshToken)
        {
            await _context.TB_RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

    }
}
