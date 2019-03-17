using Data.Contexto;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementatacao
{
    public class LivroRepositorio : RepositorioBase<Livro>
    {
        private MySqlContext contexto;

        public LivroRepositorio(MySqlContext contexto) : base( contexto)
        {
            this.contexto = contexto;
        }

        protected override DbSet<Livro> GetDbSet()
        {
            return contexto.Livro;
        }
    }
}
