using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Helpers
{
    /// <summary>
    /// Classe auxiliar para criptografia de dados em MD5
    /// </summary>
    public static class MD5Helper
    {
        public static string Encrypt(string value)
        {
            using (var md5 = MD5.Create())
            {
                //criptografando o valor
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

                //converter o resultado da criptografia para string (texto)
                var result = string.Empty;
                foreach (var item in hash)
                {
                    result += item.ToString("X2"); //hexadecimal
                }

                return result;
            }
        }
    }
}
