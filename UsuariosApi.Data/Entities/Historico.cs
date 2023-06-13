using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Entities
{
    /// <summary>
    ///  Modelo de dados para a entidade Historico
    /// </summary>
    public class Historico
    {
        #region Propriedades

        public Guid IdHistorico { get; set; }
        public DateTime DataHoraOperacao { get; set; }
        public string? TipoOperacao { get; set; }
        public Guid IdUsuario { get; set; }

        #endregion

        #region Relacionamentos

        public Usuario? Usuario { get; set; }

        #endregion
    }
}
