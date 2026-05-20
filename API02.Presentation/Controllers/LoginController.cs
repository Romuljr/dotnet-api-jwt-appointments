using API02.CrossCutting.Cryptography;
using API02.Infra.Contracts;
using API02.Presentation.Configurations;
using API02.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API02.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginModel model,
            [FromServices] IUsuarioRepository usuarioRepository,
            [FromServices] TokenSettings tokenSettings)
        {
            try
            {
                var usuario = usuarioRepository.Get(model.Email, MD5Cryptography.Encrypt(model.Senha));

                if (usuario == null)
                {
                    return StatusCode(401, new { Message = "Acesso Negado. Usuário inválido." });
                }

                return Ok
                    (
                        new
                        {
                            Message = "Usuário autenticado com sucesso.",
                            AcessToken = tokenSettings.GenerateToken(usuario.Email)
                        }
                    );
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
