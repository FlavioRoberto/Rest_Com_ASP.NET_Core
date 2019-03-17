using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;
using Negocio.Contratos;
using Repositorio;

namespace Negocio.Implementacao
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private IRepositorio<Pessoa> _repositorio;

        public PessoaNegocio(IRepositorio<Pessoa> repositorio)
        {
            this._repositorio = repositorio;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            try
            {
                bool existeEntidade = await _repositorio.ListarPeloId(lnq => lnq.Id == pessoa.Id) != null;
                if (!existeEntidade)
                    throw new Exception("Não foi encontrada a pessoa informada");

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
                return await _repositorio.ListarPeloId(lnq => lnq.Id == id);
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
                return await _repositorio.Remover(lnq => lnq.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
