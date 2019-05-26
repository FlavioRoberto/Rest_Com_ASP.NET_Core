using Dominio.Model;
using Dominio.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Negocio.Contratos;
using Negocio.Implementacao;
using Repositorio;
using System;
using System.Threading.Tasks;
using Tapioca.HATEOAS;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class PessoaController : ControllerBase
    {
        private IPessoaNegocio _pessoaNegocio;

        public PessoaController(IRepositorio<Pessoa> pessoaRepositorio)
        {
            _pessoaNegocio = new PessoaNegocio(pessoaRepositorio);
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(List<PessoaViewModel>),200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> ListarPorID(long id)
        {
            var pessoa =  _pessoaNegocio.ListarPeloId(id);

            if (pessoa == null)
                return NoContent();

            return Ok(pessoa);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PessoaViewModel>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> ListarTodos()
        {
            var listaPessoas =  _pessoaNegocio.ListarTodos();

            if (listaPessoas.Count <= 0)
                return NoContent();

            return Ok(listaPessoas);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<PessoaViewModel>), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Criar([FromBody] PessoaViewModel pessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O modelo não é válido!");

                var resultado =  _pessoaNegocio.Criar(pessoa);

                if (resultado == null)
                    return BadRequest("Não foi possível criar uma nova pessoa!");

                return Ok(pessoa);

            }catch(Exception e)
            {
                return BadRequest($"Não foi possível criar uma nova pessoa: {e.InnerException.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<PessoaViewModel>), 200)]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Atualizar([FromBody] PessoaViewModel pessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O modelo não é válido!");

                return Ok( _pessoaNegocio.Atualizar(pessoa));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<PessoaViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Remover([FromQuery] long id)
        {
            return Ok( _pessoaNegocio.Remover(id));
        }


    }
}
