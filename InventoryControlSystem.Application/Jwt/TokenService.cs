using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InventoryControlSystem.Application.Jwt
{
    public  class TokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _tokenexpirationMinutes;

        public TokenService(IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            _secretKey = jwtSettings["SecretKey"];
            _issuer = jwtSettings["Issuer"];
            _audience = jwtSettings["Audience"];
            _tokenexpirationMinutes = int.Parse(jwtSettings["TokenExpirationInMinutes"]);
        }

        public string GenerateJwtToken(Usuario usuario)

        {   // busca as informações do usuario no banco de dados 
            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // cria o token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_tokenexpirationMinutes),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = credentials
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            // gera o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // retorna o token em string
            return tokenHandler.WriteToken(token);

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }
    }
}

