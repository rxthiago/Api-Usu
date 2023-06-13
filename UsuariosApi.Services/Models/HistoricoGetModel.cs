namespace UsuariosApi.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de histórico
    /// </summary>
    public class HistoricoGetModel
    {
        public DateTime DataHoraOperacao { get; set; }
        public string? TipoOperacao { get; set; }
    }
}
