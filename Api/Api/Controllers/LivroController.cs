using Dominio.Model;
using Dominio.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Negocio.Contratos;
using Negocio.Implementatacao;
using Repositorio;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class LivroController : ControllerBase
    {
        private ILivroNegocio _negocio;

        public LivroController(IRepositorio<Livro> repositorio)
        {
            _negocio = new LivroNegocio(repositorio);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarPorID(long id)
        {
            var livro =  _negocio.ListarPeloId(id);

            if (livro == null)
                return NoContent();

            return Ok(livro);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var livros =  _negocio.ListarTodos();

            if (livros.Count <= 0)
                return NoContent();

            return Ok(livros);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] LivroViewModel livro)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O modelo não é válido!");

                var resultado =  _negocio.Criar(livro);

                if (resultado == null)
                    return BadRequest("Não foi possível criar uma novo livro!");

                return Ok(livro);

            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possível criar um novo livro: {e.InnerException.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] LivroViewModel livro)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O modelo não é válido!");

                return Ok(_negocio.Atualizar(livro));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remover([FromQuery] long id)
        {
            return Ok( _negocio.Remover(id));
        }


    }
}
