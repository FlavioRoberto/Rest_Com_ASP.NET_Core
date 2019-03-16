using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapeamento
{
    public class PessoaMapeamento
    {
        private EntityTypeBuilder<Pessoa> _builder;

        public PessoaMapeamento(EntityTypeBuilder<Pessoa> builder)
        {
            _builder = builder;
        }

        public PessoaMapeamento Map()
        {
            _builder.HasKey(lnq => lnq.Id);

            _builder.Property(lnq => lnq.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            _builder.Property(lnq => lnq.Endereco)
                .IsRequired()
                .HasColumnName("Endereco");

            _builder.Property(lnq => lnq.PrimeiroNome)
            .IsRequired()
            .HasColumnName("PrimeiroNome");

            _builder.Property(lnq => lnq.Sexo)
            .IsRequired()
            .HasColumnName("Sexo");

            _builder.Property(lnq => lnq.UltimoNome)
            .HasColumnName("UltimoNome");

            _builder.ToTable("Pessoa");

            return this;
        }
    }
}
