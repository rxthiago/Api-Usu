using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Entities
{
    /// <summary>
    /// Modelo de dados para a entidade Usuario
    /// </summary>
    public class Usuario
    {
        #region Propriedades

        public Guid IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public Guid? IdPerfil { get; set; }

        #endregion

        #region Relacionamentos

        public Perfil? Perfil { get; set; }
        public List<Historico>? Historicos { get; set; }

        #endregion
    }
}
