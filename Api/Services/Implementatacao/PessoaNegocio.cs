using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repositorio;

namespace Negocio.Implementacao
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private IPessoaRepositorio _repositorio;

        public PessoaNegocio(IPessoaRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            try
            {
                return await _repositorio.Atualizar(pessoa);
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

        public async Task<Pessoa> ListarPeloId(long id)
        {
            try
            {
                return await _repositorio.ListarPeloId(id);
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

        public async Task<bool> Remover(long id)
        {
            try
            {
               return await _repositorio.Remover(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
