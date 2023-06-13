using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Contexts;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Data.Repositories
{
    /// <summary>
    /// Repositorio de dados para Perfil
    /// </summary>
    public class PerfilRepository
    {
        /// <summary>
        /// Método para consultar 1 Perfil através do Nome
        /// </summary>
        public Perfil? GetByNome(string nome)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Perfil
                    .FirstOrDefault(p => p.Nome.Equals(nome));
            }
        }
    }
}
