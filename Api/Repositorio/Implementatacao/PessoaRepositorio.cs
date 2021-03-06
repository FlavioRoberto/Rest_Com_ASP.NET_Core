﻿using Data.Contexto;
using Dominio.Model;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementatacao
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>
    {

        public PessoaRepositorio( MySqlContext contexto) : base(contexto)
        {       
        }

        protected override DbSet<Pessoa> GetDbSet()
        {
            return _contexto.Pessoa;
        }
    }
}
