using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Services;
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
        public async Task<IActionResult> ListarPorID([FromQuery] long id)
        {
            var pessoa = _pessoaService.ListarPeloId(id);

            if (pessoa == null)
                return NoContent();

            return Ok(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var listaPessoas = _pessoaService.ListarTodos();

            if (listaPessoas.Count <= 0)
                return NoContent();

            return Ok(listaPessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest("O modelo não é válido!");

            return Ok(_pessoaService.Criar(pessoa));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest("O modelo não é válido!");

            return Ok(_pessoaService.Atualizar(pessoa));
        }

        [HttpDelete]
        public async Task<IActionResult> Remover([FromQuery] long id)
        {
            return Ok(_pessoaService.Remover(id));
        }


    }
}
