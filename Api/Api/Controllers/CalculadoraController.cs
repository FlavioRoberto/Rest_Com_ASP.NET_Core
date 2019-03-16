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
            string numerosValidos = ValidarNumeros(primeiroNumero, segundoNumero);
            if (numerosValidos.Length > 0)
                return BadRequest(numerosValidos);
            return CalcularOperacao("adicao", primeiroNumero, segundoNumero);
        }


        [Route("subtracao")]
        [HttpGet()]
        public async Task<IActionResult> Subtracao([FromQuery] string primeiroNumero, [FromQuery] string segundoNumero)
        {
            string numerosValidos = ValidarNumeros(primeiroNumero, segundoNumero);
            if (numerosValidos.Length > 0)
                return BadRequest(numerosValidos);

            return CalcularOperacao("subtracao", primeiroNumero, segundoNumero);
        }

        [Route("multiplicacao")]
        [HttpGet()]
        public async Task<IActionResult> Multiplicacao([FromQuery] string primeiroNumero, [FromQuery] string segundoNumero)
        {
            string numerosValidos = ValidarNumeros(primeiroNumero, segundoNumero);
            if (numerosValidos.Length > 0)
                return BadRequest(numerosValidos);

            return CalcularOperacao("multiplicacao", primeiroNumero, segundoNumero);
        }

        [Route("divisao")]
        [HttpGet()]
        public async Task<IActionResult> Divisao([FromQuery] string primeiroNumero, [FromQuery] string segundoNumero)
        {
            string numerosValidos = ValidarNumeros(primeiroNumero, segundoNumero);
            if (numerosValidos.Length > 0)
                return BadRequest(numerosValidos);

            return CalcularOperacao("divisao", primeiroNumero, segundoNumero);
        }

        private IActionResult CalcularOperacao(string operacao, string primeiroNumero, string segundoNumero)
        {
            Retorno<decimal> conversaoPrimeiroNumero = primeiroNumero.ToDecimal();
            Retorno<decimal> conversaoSegundoNumero = segundoNumero.ToDecimal();

            if (conversaoPrimeiroNumero.ExisteErro())
                return BadRequest(conversaoPrimeiroNumero.GetErro());

            if (conversaoSegundoNumero.ExisteErro())
                return BadRequest(conversaoSegundoNumero.GetErro());


            switch (operacao)
            {
                case "adicao":
                    return Ok("A soma dos números informados é: " +
                             $"{conversaoPrimeiroNumero.Resultado + conversaoSegundoNumero.Resultado}");
                case "subtracao":
                    return Ok("A subtração dos números informados é: " +
                             $"{conversaoPrimeiroNumero.Resultado - conversaoSegundoNumero.Resultado}");
                case "multiplicacao":
                    return Ok("A multiplicação dos números informados é: " +
                         $"{conversaoPrimeiroNumero.Resultado * conversaoSegundoNumero.Resultado}");
                case "divisao":
                    if (conversaoSegundoNumero.Resultado == 0)
                        return BadRequest("Não é possível dividir por 0!");

                    return Ok("A divisão dos números informados é: " +
                        $"{conversaoPrimeiroNumero.Resultado / conversaoSegundoNumero.Resultado}");

                default: return BadRequest("Operação não implementada!");
            }
        }

        private string ValidarNumeros(string primeiroNumero, string segundoNumero)
        {
            if (!primeiroNumero.EhNumerico())
                return "Primeiro número inválido";

            if (!segundoNumero.EhNumerico())
                return "Segundo número inválido";

            return string.Empty;
        }

    }

}
