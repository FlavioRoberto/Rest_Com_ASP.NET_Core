using Dominio.Model;
using Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Conversor
{
    public class PessoaConversor : IParse<PessoaViewModel, Pessoa>, IParse<Pessoa, PessoaViewModel>
    {
        public PessoaViewModel Parse(Pessoa origem)
        {
            if (origem == null)
                return new PessoaViewModel();

            return new PessoaViewModel
            {
                Endereco = origem.Endereco,
                Id = origem.Id,
                PrimeiroNome = origem.PrimeiroNome,
                Sexo = origem.Sexo,
                UltimoNome = origem.UltimoNome
            };
        }

        public Pessoa Parse(PessoaViewModel origem)
        {
            if (origem == null)
                return new Pessoa();

            return new Pessoa
            {
                Endereco = origem.Endereco,
                Id = origem.Id,
                PrimeiroNome = origem.PrimeiroNome,
                Sexo = origem.Sexo,
                UltimoNome = origem.UltimoNome
            };
        }

        public List<PessoaViewModel> ParseList(List<Pessoa> origem)
        {
            if (origem == null)
                return new List<PessoaViewModel>();

            return origem.Select(lnq => Parse(lnq)).ToList();
        }

        public List<Pessoa> ParseList(List<PessoaViewModel> origem)
        {
            if (origem == null)
                return new List<Pessoa>();

            return origem.Select(lnq => Parse(lnq)).ToList();
        }
    }
}
