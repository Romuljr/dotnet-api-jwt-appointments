using API02.Domain.Entities;
using API02.Infra.Contracts;
using API02.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API02.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AccountModel model,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                if (usuarioRepository.Get(model.Email) != null)
                    return StatusCode(403, 
                        new 
                        { message = "O email informado já encontra-se cadastrado. Tente outro." }
                        );

                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    DateCriacao = DateTime.Now
                };

                usuarioRepository.Create(usuario);

                return Ok( new { Message = "Usuário cadastrado com sucesso."});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
