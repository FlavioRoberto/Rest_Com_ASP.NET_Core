using System;
using System.Collections.Generic;
using Dominio.Core.Conversor;
using Dominio.Core.ViewModel;
using Dominio.Model;
using Negocio.Contratos;
using Repositorio;

namespace Negocio.Implementacao
{
    public class PessoaNegocio : IPessoaNegocio
    {
        private IRepositorio<Pessoa> _repositorio;
        private readonly PessoaConversor conversor;

        public PessoaNegocio(IRepositorio<Pessoa> repositorio)
        {
            this._repositorio = repositorio;
            conversor = new PessoaConversor();
        }

        public PessoaViewModel Atualizar(PessoaViewModel pessoa)
        {
            try
            {
                var resultado = _repositorio.ListarPeloId(lnq => lnq.Id == pessoa.Id).Result;
                bool existeEntidade = resultado != null;
                if (!existeEntidade)
                    throw new Exception("Não foi encontrada a pessoa informada");

                var entidade = conversor.Parse(pessoa);
                var resultadoAtualizacao = _repositorio.Atualizar(entidade).Result;
                return conversor.Parse(resultadoAtualizacao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PessoaViewModel Criar(PessoaViewModel pessoa)
        {
            try
            {
                var entidade = conversor.Parse(pessoa);
                var resultado = _repositorio.Criar(entidade).Result;
                return conversor.Parse(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public PessoaViewModel ListarPeloId(long id)
        {
            try
            {
                return conversor.Parse(_repositorio.ListarPeloId(lnq => lnq.Id == id).Result);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<PessoaViewModel> ListarTodos()
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
