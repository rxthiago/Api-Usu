using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Services.Security
{
    /// <summary>
    /// Classe para geração dos TOKENS de autenticação
    /// </summary>
    public class JwtTokenSecurity
    {
        #region Atributos para parametrizar a geração dos tokens

        /// <summary>
        /// Chave secreta antifalsificação, utilizada para assinar os TOKENS
        /// </summary>
        public static string SecretKey = "aeb718a2-e0be-4b95-9dcc-0f8712db6ee7";

        /// <summary>
        /// Tempo de expiração do TOKEN em horas
        /// </summary>
        public static int ExpirationInHours = 24;

        #endregion

        /// <summary>
        /// Método utilizado para fazer a geração dos TOKENs
        /// </summary>
        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Gravando o email do usuário como identificação no corpo do TOKEN
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Email) }),

                //Definindo a data e hora de expiração do token
                Expires = DateTime.Now.AddHours(ExpirationInHours),

                //criptografando o token utilizando a chave secreta antifalsificação
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
