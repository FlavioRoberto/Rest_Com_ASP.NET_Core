using Data.Contexto;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementatacao
{
    public class LivroRepositorio : RepositorioBase<Livro>
    {
        public LivroRepositorio(MySqlContext contexto) : base( contexto)
        {
        }

        protected override DbSet<Livro> GetDbSet()
        {
            return _contexto.Livro;
        }
    }
}
