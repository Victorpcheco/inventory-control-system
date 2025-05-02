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
        // Busca usuário por matrícula
        public async Task<Usuario> GetByMatriculaAsync(string matricula)
        {
            return await _context.TB_Usuarios
                .FirstOrDefaultAsync(u => u.Matricula == matricula);
        }
        // Verifica se o usuário está cadastrado pela matrícula
        public async Task<bool> MatriculaExisteAsync(string matricula)
        {
           return  await _context.TB_Usuarios.AnyAsync(u => u.Matricula == matricula);
        }
        // Adiciona um novo usuário
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _context.TB_Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        // Adiciona o refresh token do usuário logado na tabela
        public async Task AddRefreshTokenAsync(RefreshTokens refreshToken)
        {
            await _context.TB_RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }
        // deleta um usuário.
        public async Task deleteUserAsync(string matricula)
        {
            var usuario = await _context.TB_Usuarios.FirstOrDefaultAsync(u => u.Matricula == matricula);
            if (usuario != null)
            {
                _context.TB_Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
