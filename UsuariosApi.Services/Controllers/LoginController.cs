using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;
using UsuariosApi.Services.Security;

namespace UsuariosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginPostModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var historicoRepository = new HistoricoRepository();

                //buscar o usuário através do email e da senha
                var usuario = usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha);

                //verificar se o usuário não foi encontrado
                if (usuario == null)
                    //HTTP STATUS CODE 401 (UNAUTHORIZED)
                    return StatusCode(401, new { mensagem = "Acesso negado, usuário inválido." });

                //gerando o TOKEN do usuário
                var accessToken = JwtTokenSecurity.GenerateToken(usuario);

                //gravando o hitórico
                var historico = new Historico
                {
                    IdHistorico = Guid.NewGuid(),
                    DataHoraOperacao = DateTime.Now,
                    TipoOperacao = "Autenticação de usuário",
                    IdUsuario = usuario.IdUsuario
                };

                historicoRepository.Create(historico);

                //retornando STATUS OK (200 - SUCESSO)
                return StatusCode(200, new 
                { 
                    mensagem = "Usuário autenticado com sucesso",
                    nome = usuario.Nome,
                    email = usuario.Email,
                    token = accessToken,
                    dataHora = DateTime.Now
                });
            }
            catch(Exception e)
            {
                //STATUS CODE 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { mensagem = $"Falha ao autenticar: {e.Message}" });
            }
        }
    }
}
