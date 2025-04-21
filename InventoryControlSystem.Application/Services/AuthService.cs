using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using InventoryControlSystem.Application.Jwt;

namespace InventoryControlSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenService _tokenService;
        public AuthService(IUsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<(string JwtToken, string RefreshToken)> RegisterAsync(Usuario usuario)
        {

            if (await _usuarioRepository.MatriculaExisteAsync(usuario.Matricula))
                throw new ArgumentException("Matrícula já está em uso.");

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            await _usuarioRepository.AddUsuarioAsync(usuario);

            var jwtToken = _tokenService.GenerateJwtToken(usuario);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _usuarioRepository.AddRefreshTokenAsync(new RefreshTokens
            {
                Token = refreshToken,
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                UsuarioId = usuario.Id
            });

            return (jwtToken, refreshToken);
        }

        public async Task<(string JwtToken, string RefreshToken)> LoginAsync(string matricula, string senha)
        {
            var usuario = await _usuarioRepository.GetByMatriculaAndSenhaAsync(matricula, senha);

           if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            var jwtToken = _tokenService.GenerateJwtToken(usuario);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _usuarioRepository.AddRefreshTokenAsync(new RefreshTokens
            {
                Token = refreshToken,
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                UsuarioId = usuario.Id
            });

            return (jwtToken, refreshToken);
        }


        public async Task DeleteUserAsync(string matricula)
        {
            await _usuarioRepository.deleteUserAsync(matricula);
        }

    }
}
