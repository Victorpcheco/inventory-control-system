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
        private const int RefreshTokenExpirationDays = 7;

        public AuthService(IUsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        /// Registra um novo usuário no sistema.
        public async Task<(string JwtToken, string RefreshToken)> RegisterAsync(Usuario usuario)
        {
            await ValidarMatriculaUnicaAsync(usuario.Matricula);

            usuario.DefinirSenha(usuario.Senha);
            //usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            await _usuarioRepository.AddUsuarioAsync(usuario);

            var jwtToken = _tokenService.GenerateJwtToken(usuario);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _usuarioRepository.AddRefreshTokenAsync(new RefreshTokens
            {
                Token = refreshToken,
                ExpirationDate = DateTime.UtcNow.AddDays(RefreshTokenExpirationDays),
                UsuarioId = usuario.Id
            });

            return (jwtToken, refreshToken);
        }


        /// Realiza o login de um usuário.
        public async Task<(string JwtToken, string RefreshToken)> LoginAsync(string matricula, string senha)
        {
            var usuario = await _usuarioRepository.GetByMatriculaAsync(matricula);

            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);

            if (!senhaValida)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            var jwtToken = _tokenService.GenerateJwtToken(usuario);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _usuarioRepository.AddRefreshTokenAsync(new RefreshTokens
            {
                Token = refreshToken,
                ExpirationDate = DateTime.UtcNow.AddDays(RefreshTokenExpirationDays),
                UsuarioId = usuario.Id
            });
            return (jwtToken, refreshToken);
        }

        public async Task DeleteUserAsync(string matricula)
        {
            await _usuarioRepository.deleteUserAsync(matricula);
        }

        /// movido para um método privado para melhorar a legibilidade.
        private async Task ValidarMatriculaUnicaAsync(string matricula)
        {
            if (await _usuarioRepository.MatriculaExisteAsync(matricula))
                throw new ArgumentException("Matrícula já está em uso.");
        }

       
    }
}
