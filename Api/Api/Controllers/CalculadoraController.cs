using Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {

        [Route("soma")]
        [HttpGet()]
        public async Task<IActionResult> Soma([FromQuery] string primeiroNumero, [FromQuery] string segundoNumero)
        {
            if (!primeiroNumero.EhNumerico())
                return BadRequest("Primeiro número inválido");

            if (!segundoNumero.EhNumerico())
                return BadRequest("Segundo número inválido");

            Retorno<decimal> conversaoPrimeiroNumero = primeiroNumero.ToDecimal();
            Retorno<decimal> conversaoSegundoNumero = segundoNumero.ToDecimal();

            if (conversaoPrimeiroNumero.ExisteErro())
                return BadRequest(conversaoPrimeiroNumero.GetErro());

            if (conversaoSegundoNumero.ExisteErro())
                return BadRequest(conversaoSegundoNumero.GetErro());

            return Ok("A soma dos números informados é: " +
                $"{conversaoPrimeiroNumero.Resultado + conversaoSegundoNumero.Resultado}");
        }
    }
}
