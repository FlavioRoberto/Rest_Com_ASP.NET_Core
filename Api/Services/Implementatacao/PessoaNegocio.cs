using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repositorio;

namespace Negocio.Implementacao
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private IEntidade<Pessoa> _repositorio;

        public PessoaNegocio(IEntidade<Pessoa> repositorio)
        {
            this._repositorio = repositorio;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            try
            {
                return await _repositorio.Atualizar(pessoa, lnq => lnq.Id == pessoa.Id, "Não existe a pessoa informada!");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            try
            {
                return await _repositorio.Criar(pessoa);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<Pessoa> ListarPeloId(Expression<Func<Pessoa, bool>> query)
        {
            try
            {
                return await _repositorio.ListarPeloId(query);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<Pessoa>> ListarTodos()
        {
            try
            {
                return await _repositorio.ListarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Remover(Expression<Func<Pessoa, bool>> query)
        {
            try
            {
                return await _repositorio.Remover(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
