using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarPorID(long id)
        {
            var pessoa = await _pessoaService.ListarPeloId(id);

            if (pessoa == null)
                return NoContent();

            return Ok(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var listaPessoas = await _pessoaService.ListarTodos();

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

                var resultado = await _pessoaService.Criar(pessoa);

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

            return Ok(await _pessoaService.Atualizar(pessoa));
        }

        [HttpDelete]
        public async Task<IActionResult> Remover([FromQuery] long id)
        {
            return Ok(await _pessoaService.Remover(id));
        }


    }
}
