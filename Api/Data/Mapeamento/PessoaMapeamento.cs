using Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamento
{
    public class PessoaMapeamento : EntidadeMapeamento<Pessoa>
    {

        public PessoaMapeamento(EntityTypeBuilder<Pessoa> builder) : base(builder)
        { }

        public override EntidadeMapeamento<Pessoa> Map()
        {
            builder.HasKey(lnq => lnq.Id);

            builder.Property(lnq => lnq.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(lnq => lnq.Endereco)
                .IsRequired()
                .HasColumnName("Endereco");

            builder.Property(lnq => lnq.PrimeiroNome)
            .IsRequired()
            .HasColumnName("PrimeiroNome");

            builder.Property(lnq => lnq.Sexo)
            .IsRequired()
            .HasColumnName("Sexo");

            builder.Property(lnq => lnq.UltimoNome)
            .HasColumnName("UltimoNome");

            builder.ToTable("Pessoa");

            return this;
        }
    }
}
