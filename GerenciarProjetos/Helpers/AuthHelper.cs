using GerenciarProjetos.Helpers.Interface;
using GerenciarProjetos.Models.DbResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GerenciarProjetos.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IConfiguration _configuration;
        public AuthHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CriarJwtToken(UsuarioAuthResult user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string secret = _configuration.GetValue<string>("JwtSecret");
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Id", user.ID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            }; 
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string CriarRefreshToken()
        {
            var tokenNumbers = new byte[256];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(tokenNumbers);
            return Convert.ToBase64String(tokenNumbers);
        }
    }
}
