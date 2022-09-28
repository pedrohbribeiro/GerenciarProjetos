﻿// <auto-generated />
using System;
using GerenciarProjetos.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciarProjetos.Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.EmpregadoEntity", b =>
                {
                    b.Property<int>("IdEmpregado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_empregado");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEmpregado"));

                    b.Property<string>("Endereco")
                        .HasColumnType("text")
                        .HasColumnName("endereco");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean")
                        .HasColumnName("excluido");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("text")
                        .HasColumnName("primeiro-nome");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint")
                        .HasColumnName("telefone");

                    b.Property<string>("UltimoNome")
                        .HasColumnType("text")
                        .HasColumnName("ultimo-nome");

                    b.HasKey("IdEmpregado");

                    b.HasIndex("Endereco")
                        .IsUnique();

                    b.ToTable("empregado");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.MembrosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEmpregado")
                        .HasColumnType("integer")
                        .HasColumnName("id_empregado");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("integer")
                        .HasColumnName("id_projeto");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpregado");

                    b.HasIndex("IdProjeto");

                    b.ToTable("membros");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.ProjetoEntity", b =>
                {
                    b.Property<int>("IdProjeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_projeto");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProjeto"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("date")
                        .HasColumnName("data-criacao");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("date")
                        .HasColumnName("data-termino");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean")
                        .HasColumnName("excluido");

                    b.Property<int>("IdGerente")
                        .HasColumnType("integer")
                        .HasColumnName("gerente");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("IdProjeto");

                    b.HasIndex("IdGerente");

                    b.ToTable("projeto");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.RefreshTokenEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Token")
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.HasKey("ID");

                    b.HasIndex("IdUsuario");

                    b.ToTable("refresh_token");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("SenhaHash")
                        .HasColumnType("text")
                        .HasColumnName("senha-hash");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.MembrosEntity", b =>
                {
                    b.HasOne("GerenciarProjetos.Database.Entities.EmpregadoEntity", "Empregado")
                        .WithMany("Membro")
                        .HasForeignKey("IdEmpregado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciarProjetos.Database.Entities.ProjetoEntity", "Projeto")
                        .WithMany("Membro")
                        .HasForeignKey("IdProjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empregado");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.ProjetoEntity", b =>
                {
                    b.HasOne("GerenciarProjetos.Database.Entities.EmpregadoEntity", "Empregado")
                        .WithMany("Projeto")
                        .HasForeignKey("IdGerente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empregado");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.RefreshTokenEntity", b =>
                {
                    b.HasOne("GerenciarProjetos.Database.Entities.UsuarioEntity", "Usuario")
                        .WithMany("RefreshToken")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.EmpregadoEntity", b =>
                {
                    b.Navigation("Membro");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.ProjetoEntity", b =>
                {
                    b.Navigation("Membro");
                });

            modelBuilder.Entity("GerenciarProjetos.Database.Entities.UsuarioEntity", b =>
                {
                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
