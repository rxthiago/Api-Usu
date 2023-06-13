using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Entities
{
    /// <summary>
    /// Modelo de dados para a entidade Perfil
    /// </summary>
    public class Perfil
    {
        #region Propriedades

        public Guid IdPerfil { get; set; }
        public string? Nome { get; set; }

        #endregion

        #region Relacionamentos

        public List<Usuario>? Usuarios { get; set; }

        #endregion
    }
}
