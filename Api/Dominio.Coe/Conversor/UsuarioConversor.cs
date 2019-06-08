using Dominio.Core.ViewModel;
using Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Core.Conversor
{
    public class UsuarioConversor : IParse<UsuarioViewModel, Usuario>, IParse<Usuario, UsuarioViewModel>
    {
        public Usuario Parse(UsuarioViewModel origem)
        {
            if (origem == null)
                return new Usuario();

            return new Usuario
            {
                Nome = origem.Nome,
                Id = origem.Id.HasValue ? origem.Id.Value : 0,
                Login = origem.Login,
                Senha = origem.Senha
            };
        }

        public UsuarioViewModel Parse(Usuario origem)
        {
            if (origem == null)
                return new UsuarioViewModel();

            return new UsuarioViewModel
            {
                Id = origem.Id,
                Login = origem.Login,
                Nome = origem.Nome,
                Senha = origem.Senha
            };
        }

        public List<Usuario> ParseList(List<UsuarioViewModel> origem)
        {
            if (origem == null)
                return new List<Usuario>();

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<UsuarioViewModel> ParseList(List<Usuario> origem)
        {
            if (origem == null)
                return new List<UsuarioViewModel>();

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
