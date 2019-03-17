using Data.Mapeamento;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexto
{
    public class MySqlContext : DbContext , IContexto
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) :base(options)
        {       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(b => new PessoaMapeamento(b).Map());
            modelBuilder.Entity<Livro>(b => new LivroMapeamento(b).Map());
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Livro> Livro { get; set; }

    }
}
