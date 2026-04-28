using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API02.Presentation.Configurations
{
    public class TokenSettings
    {
        private readonly JwtSettings jwtSettings;

        public TokenSettings(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //usuario para o qual o TOKEN foi gerado
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),

                //data de expiração do TOKEN
                Expires = DateTime.Now.AddDays(1),

                //criptografia do TOKEN
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
