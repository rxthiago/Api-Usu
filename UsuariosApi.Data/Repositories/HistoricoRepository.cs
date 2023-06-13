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
    /// Repositorio de dados para Histórico
    /// </summary>
    public class HistoricoRepository
    {
        /// <summary>
        /// Método para inserir um histórico na base
        /// </summary>
        public void Create(Historico historico)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Historico.Add(historico);
                sqlServerContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para listar todos os historicos de um usuário
        /// </summary>
        public List<Historico> GetAllByUsuario(Guid idUsuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Historico
                    .Where(h => h.IdUsuario == idUsuario)
                    .OrderByDescending(h => h.DataHoraOperacao)
                    .ToList();
            }
        }
    }
}
