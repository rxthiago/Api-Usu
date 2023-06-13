using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Contexts;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Helpers;

namespace UsuariosApi.Data.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para Usuário
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Método para inserir um usuário no banco de dados
        /// </summary>
        public void Create(Usuario usuario)
        {
            //Criptografando a senha do usuário
            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Usuario.Add(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar um usuário no banco de dados
        /// </summary>
        public void Update(Usuario usuario)
        {
            //Criptografando a senha do usuário
            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(usuario).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para consultar 1 usuário baseado no email
        /// </summary>
        public Usuario? GetByEmail(string email)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        /// <summary>
        /// Método para consultar 1 usuário baseado no email e na senha
        /// </summary>
        public Usuario? GetByEmailAndSenha(string email, string senha)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(MD5Helper.Encrypt(senha)));
            }
        }
    }
}
