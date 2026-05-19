using API02.Domain.Entities;
using API02.Infra.Contracts;
using API02.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API02.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CompromissoCadastroModel model,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var usuario = usuarioRepository.Get(User.Identity.Name);

                var compromisso = new Compromisso();

                compromisso.Id = Guid.NewGuid();
                compromisso.Nome = model.Nome;
                compromisso.Data = DateTime.ParseExact(model.Data, "dd/MM/yyyy", null);
                compromisso.Hora = TimeSpan.Parse(model.Hora);
                compromisso.Descricao = model.Descricao;
                compromisso.UsuarioId = usuario.Id;

                compromissoRepository.Create(compromisso);

                return Ok("Compromisso cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPut]
        public IActionResult Put(CompromissoEdicaoModel model,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var usuario = usuarioRepository.Get(User.Identity.Name);

                var compromisso = compromissoRepository.GetById(model.Id);

                if (compromisso != null && compromisso.UsuarioId == usuario.Id)
                {
                    compromisso.Nome = model.Nome;
                    compromisso.Data = DateTime.ParseExact(model.Data, "dd/MM/yyyy", null);
                    compromisso.Hora = TimeSpan.Parse(model.Hora);
                    compromisso.Descricao = model.Descricao;

                    compromissoRepository.Update(compromisso);

                    return Ok("Compromisso atualizado com sucesso. ");
                }
                else
                {
                    return StatusCode(403, "Compromisso inválido para edição.");
                }
                    return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, 
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var usuario = usuarioRepository.Get(User.Identity.Name);

                var compromisso = compromissoRepository.GetById(id);

                if (compromisso != null && compromisso.UsuarioId == usuario.Id)
                {
                    compromissoRepository.Delete(compromisso);

                    return Ok("Compromisso excluído com sucesso.");
                }
                else
                {
                    return StatusCode(403, "Compromisso inválido para exclusão.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ProducesResponseType(typeof(List<CompromissoConsultaModel>), 200)]
        [HttpGet("{dataInicio}/{dataFim}")]
        public IActionResult GetAll(DateTime dataInicio, DateTime dataFim,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var usuario = usuarioRepository.Get(User.Identity.Name);

                var compromissos = compromissoRepository.GetByDatas(dataInicio, dataFim, usuario.Id);

                var result = new List<CompromissoConsultaModel>();

                foreach (var item in compromissos)
                {
                    result.Add(new CompromissoConsultaModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Data = item.Data.ToString("dd/MM/yyyy"),
                        Hora = item.Hora.ToString(),
                        Descricao = item.Descricao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ProducesResponseType(typeof(CompromissoConsultaModel), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id, 
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var usuario = usuarioRepository.Get(User.Identity.Name);

                var compromisso = compromissoRepository.GetById(id);

                if (compromisso != null && compromisso.UsuarioId == usuario.Id)
                {
                    var result = new CompromissoConsultaModel
                    {
                        Id = compromisso.Id,
                        Nome = compromisso.Nome,
                        Data = compromisso.Data.ToString("dd/MM/yyyy"),
                        Hora = compromisso.Hora.ToString(),
                        Descricao = compromisso.Descricao,
                    };

                    return Ok(result);
                }
                else
                {
                    return StatusCode(403, "Compromisso inválido ou não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            return Ok();
        }
    }
}
