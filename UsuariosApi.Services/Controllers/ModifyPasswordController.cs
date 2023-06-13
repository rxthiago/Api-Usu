using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;

namespace UsuariosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModifyPasswordController : ControllerBase
    {
        [HttpPut]
        public IActionResult Put(ModifyPasswordPutModel model)
        {
            try
            {
                //capturar o email do usuário que está autenticado
                var email = User.Identity.Name;

                //pesquisando o usuário no banco de dados através do email e da senha
                var usuarioRepository = new UsuarioRepository();
                var usuario = usuarioRepository.GetByEmailAndSenha(email, model.SenhaAtual);

                //verificar se o usuário não foi encontrado
                if (usuario == null)
                    //BAD REQUEST (HTTP 400) -> CLIENT ERROR
                    return StatusCode(400, new { mensagem = "Usuário não encontrado, verifique a senha atual informada." });

                //alterar a senha do usuário
                usuario.Senha = model.NovaSenha;
                usuarioRepository.Update(usuario);

                //gravando o histórico da operação
                var historico = new Historico
                {
                    IdHistorico = Guid.NewGuid(),
                    DataHoraOperacao = DateTime.Now,
                    TipoOperacao = "Alteração da Senha de acesso",
                    IdUsuario = usuario.IdUsuario
                };

                var historicoRepository = new HistoricoRepository();
                historicoRepository.Create(historico);

                return StatusCode(200, new { mensagem = "Senha atualizada com sucesso." });
            }
            catch(Exception e)
            {
                //INTERNAL SERVER ERROR (HTTP 500) -> SERVER ERROR
                return StatusCode(500, new { mensagem = $"Falha ao autenticar: {e.Message}" });
            }
        }
    }
}
