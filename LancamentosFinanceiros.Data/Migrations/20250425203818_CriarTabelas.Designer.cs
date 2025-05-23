﻿// <auto-generated />
using System;
using LancamentosFinanceiros.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LancamentosFinanceiros.Data.Migrations
{
    [DbContext(typeof(DbContexto))]
    [Migration("20250425203818_CriarTabelas")]
    partial class CriarTabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LancamentosFinanceiros.Dominio.Dominio.Financeiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Banco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf_cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_Lancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_de_conta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_pagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor_lancamento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Financeiros");
                });
#pragma warning restore 612, 618
        }
    }
}
