using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleProjetos.Usuarios
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GeraToken(Usuario usuario) 
        {
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
                new Claim(ClaimTypes.Role, usuario.Role),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                        };
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["chaveSecreta"]));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                //issuer: _configuration["Jwt:Issuer"],
                claims : claims,
                expires :DateTime.Now.AddMinutes(30),
                signingCredentials: credencial);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
