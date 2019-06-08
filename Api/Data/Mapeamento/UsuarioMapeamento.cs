using Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapeamento
{
    public class UsuarioMapeamento : EntidadeMapeamento<Usuario>
    {
        public UsuarioMapeamento(EntityTypeBuilder<Usuario> builder):base(builder)
        { }

        public override EntidadeMapeamento<Usuario> Map()
        {
            builder.HasKey(lnq => lnq.Id);

            builder.Property(lnq => lnq.Id)
                         .ValueGeneratedOnAdd()
                         .HasColumnName("Id");

            builder.Property(lnq => lnq.Login)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(lnq => lnq.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(lnq => lnq.Senha)
                .IsRequired();
            
            return this;
        }
    }
}
