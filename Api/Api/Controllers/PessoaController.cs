using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Implementacao;
using Repositorio;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class PessoaController : ControllerBase
    {
        private IPessoaNegocio _pessoaNegocio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaNegocio = new PessoaNegocio(pessoaRepositorio);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarPorID(long id)
        {
            var pessoa = await _pessoaNegocio.ListarPeloId(id);

            if (pessoa == null)
                return NoContent();

            return Ok(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var listaPessoas = await _pessoaNegocio.ListarTodos();

            if (listaPessoas.Count <= 0)
                return NoContent();

            return Ok(listaPessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Pessoa pessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O modelo não é válido!");

                var resultado = await _pessoaNegocio.Criar(pessoa);

                if (resultado == null)
                    return BadRequest("Não foi possível criar uma nova pessoa!");

                return Ok(pessoa);

            }catch(Exception e)
            {
                return BadRequest($"Não foi possível criar uma nova pessoa: {e.InnerException.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest("O modelo não é válido!");

            return Ok(await _pessoaNegocio.Atualizar(pessoa));
        }

        [HttpDelete]
        public async Task<IActionResult> Remover([FromQuery] long id)
        {
            return Ok(await _pessoaNegocio.Remover(id));
        }


    }
}
