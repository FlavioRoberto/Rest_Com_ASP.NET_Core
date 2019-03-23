using System.Collections.Generic;
using System.Linq;
using Dominio.Core.ViewModel;
using Dominio.Model;

namespace Dominio.Core.Conversor
{
    public class LivroConversor : IParse<LivroViewModel, Livro>, IParse<Livro,LivroViewModel>
    {
       
        public Livro Parse(LivroViewModel origem)
        {
            if (origem == null)
                return new Livro();

            return new Livro
            {
                Id = origem.Id,
                Autor = origem.Autor,
                DataLancamento = origem.DataLancamento,
                Titulo = origem.Titulo,
                Valor = origem.Valor
            };
        }

        public LivroViewModel Parse(Livro origem)
        {
            if (origem == null)
                return new LivroViewModel();

            return new LivroViewModel
            {
                Autor = origem.Autor,
                Valor = origem.Valor,
                Titulo = origem.Titulo,
                DataLancamento = origem.DataLancamento,
                Id = origem.Id
            };
        }

        public List<Livro> ParseList(List<LivroViewModel> origem)
        {
            if (origem == null)
                return new List<Livro>();

            return origem.Select(item => Parse(item)).ToList();

        }

        public List<LivroViewModel> ParseList(List<Livro> origem)
        {
            if (origem == null)
                return new List<LivroViewModel>();

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
