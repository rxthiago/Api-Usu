using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;

namespace UsuariosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(RegisterPostModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var historicoRepository = new HistoricoRepository();

                //Não é permitido criar usuários com email já cadastrado
                if(usuarioRepository.GetByEmail(model.Email) != null)
                    //HTTP 400 (BAD REQUEST)
                    return StatusCode(400, new { mensagem = "Não é permitido criar usuários com email já cadastrado." });

                //Cadastrando o usuário
                var usuario = new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    DataHoraCriacao = DateTime.Now
                };

                usuarioRepository.Create(usuario);

                //Cadastrando o histórico desta operação
                var historico = new Historico
                {
                    IdHistorico = Guid.NewGuid(),
                    DataHoraOperacao = DateTime.Now,
                    TipoOperacao = "Cadastro de usuário",
                    IdUsuario = usuario.IdUsuario
                };

                historicoRepository.Create(historico);

                //HTTP STATUS CODE CREATED (201)
                return StatusCode(201, new { mensagem = $"Usuário {usuario.Nome}, cadastrado com sucesso." });
            }
            catch(Exception e)
            {
                //HTTP STATUS INTERNAL SERVER ERROR (500)
                return StatusCode(500, new { mensagem = $"Falha ao cadastrar usuário: {e.Message}." });
            }
        }
    }
}
