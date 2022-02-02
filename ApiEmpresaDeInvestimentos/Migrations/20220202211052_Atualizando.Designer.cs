﻿// <auto-generated />
using ApiEmpresaDeInvestimentos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiEmpresaDeInvestimentos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220202211052_Atualizando")]
    partial class Atualizando
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ApiEmpresaDeInvestimentos.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApiEmpresaDeInvestimentos.Models.Contas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("ApiEmpresaDeInvestimentos.Models.Depositos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContaDestinoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Depositos");
                });

            modelBuilder.Entity("ApiEmpresaDeInvestimentos.Models.Saques", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Saques");
                });
#pragma warning restore 612, 618
        }
    }
}
