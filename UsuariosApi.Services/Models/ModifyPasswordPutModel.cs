using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisiçao de alteração de senha de usuários
    /// </summary>
    public class ModifyPasswordPutModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha atual.")]
        public string? SenhaAtual { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a nova senha.")]
        public string? NovaSenha { get; set; }
    }
}
