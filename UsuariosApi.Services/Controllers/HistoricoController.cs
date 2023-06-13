using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;

namespace UsuariosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var historicoRepository = new HistoricoRepository();

                //capturando o email do usuário autenticado, contido no TOKEN
                var email = User.Identity.Name;

                //consultar o usuário no banco de dados através do email
                var usuario = usuarioRepository.GetByEmail(email);

                //consultar todos os históricos do usuário
                var historicos = historicoRepository.GetAllByUsuario(usuario.IdUsuario);

                var model = new List<HistoricoGetModel>();
                foreach (var item in historicos)
                {
                    model.Add(new HistoricoGetModel
                    {
                        DataHoraOperacao = item.DataHoraOperacao,
                        TipoOperacao = item.TipoOperacao
                    });
                }

                return StatusCode(200, model);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao consultar histórico: {e.Message}" });
            }
        }
    }
}
