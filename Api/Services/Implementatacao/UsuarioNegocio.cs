using Dominio.Core.Conversor;
using Dominio.Core.ViewModel;
using Dominio.Model;
using Negocio.Contratos;
using Repositorio;
using System;
using System.Collections.Generic;

namespace Negocio.Implementatacao
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private IRepositorio<Usuario> _repositorio;
        private readonly UsuarioConversor conversor;

        public UsuarioNegocio(IRepositorio<Usuario> repositorio)
        {
            _repositorio = repositorio;
            conversor = new UsuarioConversor();
        }

        public UsuarioViewModel Criar(UsuarioViewModel entidade)
        {
            try
            {
                var usuario = conversor.Parse(entidade);
                var result = _repositorio.Criar(usuario).Result;
                return conversor.Parse(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UsuarioViewModel ListarPeloId(long id)
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

        public List<UsuarioViewModel> ListarTodos()
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

        public UsuarioViewModel Atualizar(UsuarioViewModel entidade)
        {
            try
            {
                var usuario = conversor.Parse(entidade);
                var resultado = _repositorio.Atualizar(usuario).Result;
                return conversor.Parse(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UsuarioViewModel FindByLogin(string login)
        {
            try
            {
                var resultado =  _repositorio.ListarPeloId(x => x.Login.Equals(login)).Result;
                return conversor.Parse(resultado);
            }
            catch(Exception e)
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
