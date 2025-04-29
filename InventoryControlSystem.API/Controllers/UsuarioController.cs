using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _authService;

        public UsuarioController(IUsuarioService authService)
        {
            _authService = authService;
        }

        // Registra um novo usuário no sistema
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = Usuario.Criar(dto.Nome, dto.Matricula, dto.Senha);
                usuario.DefinirTipoUsuario(dto.TipoUsuario);

                var (jwtToken, refreshToken) = await _authService.RegisterAsync(usuario);

                return Ok(new
                {
                    Token = jwtToken,
                    RefreshToken = refreshToken
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // Realiza o login de um usuário.
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var (jwtToken, refreshToken) = await _authService.LoginAsync(dto.Matricula, dto.Senha);

                return Ok(new
                {
                    Token = jwtToken,
                    RefreshToken = refreshToken
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }

        // Deleta um usuário pelo número da matrícula.
        [HttpDelete("delete/{matricula}")]
        public async Task<IActionResult> Delete(string matricula)
        {
            try
            {
                await _authService.DeleteUserAsync(matricula);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
