using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Matricula, dto.Senha)
            {
                TipoUsuario = dto.TipoUsuario
            };

            var (jwtToken, refreshToken) = await _authService.RegisterAsync(usuario);

            return Ok(new { Token = jwtToken, RefreshToken = refreshToken });


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var (jwtToken, refreshToken) = await _authService.LoginAsync(dto.Matricula, dto.Senha);

            return Ok(new { Token = jwtToken, RefreshToken = refreshToken });
        }


        [HttpDelete("delete/{matricula}")]
        public async Task<IActionResult> Delete(string matricula)
        {
            await _authService.DeleteUserAsync(matricula);
            return NoContent();
        }

    }
}
