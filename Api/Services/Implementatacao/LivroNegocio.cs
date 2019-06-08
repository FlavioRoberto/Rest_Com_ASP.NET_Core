using System;
using System.Collections.Generic;
using Dominio.Core.Conversor;
using Dominio.Core.ViewModel;
using Dominio.Model;
using Negocio.Contratos;
using Repositorio;

namespace Negocio.Implementatacao
{
    public class LivroNegocio : ILivroNegocio
    {
        private readonly LivroConversor conversor;
        private IRepositorio<Livro> _repositorio;

        public LivroNegocio(IRepositorio<Livro> repositorio)
        {
            _repositorio = repositorio;
            conversor = new LivroConversor();
        }

        public LivroViewModel Atualizar(LivroViewModel livroViewModel)
        {
            try
            {
                var livro = conversor.Parse(livroViewModel);
                var resultado = _repositorio.Atualizar(livro).Result;
                return  conversor.Parse(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public LivroViewModel Criar(LivroViewModel livro)
        {
            try
            {
                var entidade = conversor.Parse(livro);
                var result =  _repositorio.Criar(entidade).Result;
                return conversor.Parse(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public LivroViewModel ListarPeloId(long id)
        {
            try
            {
                var resultado = _repositorio.ListarPeloId(lnq => lnq.Id == id).Result;
                return conversor.Parse(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<LivroViewModel> ListarTodos()
        {
            try
            {
                return conversor.ParseList(_repositorio.ListarTodos().Result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Remover(long id)
        {
            try
            {
                return _repositorio.Remover(lnq => lnq.Id == id).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
