using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;
using Negocio.Contratos;
using Repositorio;

namespace Negocio.Implementatacao
{
    public class LivroNegocio : ILivroNegocio
    {
        private IRepositorio<Livro> _repositorio;

        public LivroNegocio(IRepositorio<Livro> repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<Livro> Atualizar(Livro livro)
        {
            try
            {
                return _repositorio.Atualizar(livro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<Livro> Criar(Livro livro)
        {
            try
            {
                return _repositorio.Criar(livro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<Livro> ListarPeloId(long id)
        {
            try
            {
                return _repositorio.ListarPeloId(lnq => lnq.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<List<Livro>> ListarTodos()
        {
            try
            {
                return _repositorio.ListarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<bool> Remover(long id)
        {
            try
            {
                return _repositorio.Remover(lnq => lnq.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
