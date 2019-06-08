using Data.Contexto;
using Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Implementatacao
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public UsuarioRepositorio(MySqlContext contexto) : base(contexto)
        {
        }

        protected override DbSet<Usuario> GetDbSet()
        {
            return _contexto.Usuario;
        }
    }
}
