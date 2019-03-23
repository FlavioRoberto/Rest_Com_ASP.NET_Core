using Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapeamento
{
    public class LivroMapeamento : EntidadeMapeamento<Livro>
    {
        public LivroMapeamento(EntityTypeBuilder<Livro> builder) : base(builder)
        {
        }

        public override EntidadeMapeamento<Livro> Map()
        {
            builder.HasKey(lnq => lnq.Id);

            builder.Property(lnq => lnq.Autor)
                .IsRequired();

            builder.Property(lnq => lnq.DataLancamento)
              .IsRequired();

            builder.Property(lnq => lnq.Titulo)
              .IsRequired();

            builder.Property(lnq => lnq.Valor)
              .IsRequired();

            builder.ToTable("Livros");

            return this;
        }
    }
}
