using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisiçao de autenticação de usuários
    /// </summary>
    public class LoginPostModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string? Senha { get; set; }
    }
}
