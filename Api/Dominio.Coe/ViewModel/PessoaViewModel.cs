using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace Dominio.Core.ViewModel
{
    public class PessoaViewModel : ISupportsHyperMedia
    {
        public PessoaViewModel()
        {
            Links = new List<HyperMediaLink>();
        }

        public long? Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Endereco { get; set; }

        public string Sexo { get; set; }

        public List<HyperMediaLink> Links { get; set; } 
    }
}
