namespace Api.Extensions
{
    public class Retorno<T>
    {
        public T Resultado { get; private set; }
        private string _erro;

        public Retorno(T resultado, string erro)
        {
            this._erro = erro;
            this.Resultado = resultado;
        }

        public bool ExisteErro()
        {
            return _erro.Length > 0 ? true : false;
        }

        public string GetErro()
        {
            return this._erro;
        }

    }
}