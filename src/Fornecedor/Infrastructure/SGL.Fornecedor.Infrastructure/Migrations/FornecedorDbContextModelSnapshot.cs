﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGL.Fornecedor.Infrastructure.DbContexts;

#nullable disable

namespace SGL.Fornecedor.Infrastructure.Migrations
{
    [DbContext(typeof(FornecedorDbContext))]
    partial class FornecedorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGL.Fornecedor.Core.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Celular")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<string>("InscricaoEstadual")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("SGL.Fornecedor.Core.Domain.Entities.Fornecedor", b =>
                {
                    b.OwnsOne("SGL.Resource.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Nome")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.OwnsOne("SGL.Resource.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("CEP")
                                .HasMaxLength(13)
                                .HasColumnType("varchar(13)")
                                .HasColumnName("CEP");

                            b1.Property<string>("Cidade")
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Complemento");

                            b1.Property<string>("Estado")
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Numero");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}