using System;
using System.Runtime.Serialization;

namespace Dominio.Core.ViewModel
{
    [DataContract]
    public class LivroViewModel
    {
        [DataMember(Order = 1,Name = "codigo")]
        public long Id { get; set; }

        [DataMember(Order = 2)]
        public string Titulo { get; set; }

        [DataMember(Order = 3)]
        public string Autor { get; set; }

        [DataMember(Order = 4)]
        public decimal Valor { get; set; }

        [DataMember(Order = 5)]
        public DateTime DataLancamento { get; set; }
    }
}
