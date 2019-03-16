using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexto
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) :base(options)
        {

        }

      

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
