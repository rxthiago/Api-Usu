using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisiçao de recuperação de senha do usuário
    /// </summary>
    public class PasswordRecoverPostModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string? Email { get; set; }
    }
}
