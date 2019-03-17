﻿// <auto-generated />
using System;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20190317153332_Versao 01.00")]
    partial class Versao0100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("Data.Model.Livro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Autor")
                        .IsRequired();

                    b.Property<DateTime>("DataLancamento");

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Data.Model.Pessoa", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("Endereco");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnName("PrimeiroNome");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnName("Sexo");

                    b.Property<string>("UltimoNome")
                        .HasColumnName("UltimoNome");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}