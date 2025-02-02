﻿// <auto-generated />
using System;
using JobCoinAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JobCoinAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220505175722_MigrationInicial")]
    partial class MigrationInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("JobCoinAPI.Models.Funcionalidade", b =>
                {
                    b.Property<Guid>("IdFuncionalidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdFuncionalidade");

                    b.Property<string>("NomeFuncionalidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NomeFuncionalidade");

                    b.HasKey("IdFuncionalidade");

                    b.ToTable("FUNCIONALIDADES");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Perfil", b =>
                {
                    b.Property<Guid>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdPerfil");

                    b.Property<string>("NomePerfil")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NomePerfil");

                    b.HasKey("IdPerfil");

                    b.ToTable("PERFIS");
                });

            modelBuilder.Entity("JobCoinAPI.Models.PerfilFuncionalidade", b =>
                {
                    b.Property<Guid>("IdPerfil")
                        .HasColumnType("uuid")
                        .HasColumnName("IdPerfil");

                    b.Property<Guid>("IdFuncionalidade")
                        .HasColumnType("uuid")
                        .HasColumnName("IdFuncionalidade");

                    b.Property<Guid?>("PerfilIdPerfil")
                        .HasColumnType("uuid");

                    b.HasKey("IdPerfil", "IdFuncionalidade");

                    b.HasIndex("IdFuncionalidade");

                    b.HasIndex("PerfilIdPerfil");

                    b.ToTable("PERFIL_FUNCIONALIDADES");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<Guid>("IdPerfil")
                        .HasColumnType("uuid")
                        .HasColumnName("IdPerfil");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Senha");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPerfil");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Vaga", b =>
                {
                    b.Property<Guid>("IdVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdVaga");

                    b.Property<DateTime>("DataAtualizacaoVaga")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("DataAtualizacaoVaga");

                    b.Property<DateTime>("DataCriacaoVaga")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("DataCriacaoVaga");

                    b.Property<string>("DescricaoVaga")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescricaoVaga");

                    b.Property<Guid>("IdUsuarioCriacaoVaga")
                        .HasColumnType("uuid")
                        .HasColumnName("IdUsuarioCriacaoVaga");

                    b.Property<string>("NomeVaga")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NomeVaga");

                    b.Property<float>("ValorVaga")
                        .HasColumnType("real")
                        .HasColumnName("ValorVaga");

                    b.HasKey("IdVaga");

                    b.HasIndex("IdUsuarioCriacaoVaga");

                    b.ToTable("VAGAS");
                });

            modelBuilder.Entity("JobCoinAPI.Models.VagaFavoritadaUsuario", b =>
                {
                    b.Property<Guid>("IdVaga")
                        .HasColumnType("uuid")
                        .HasColumnName("IdVaga");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid")
                        .HasColumnName("IdUsuario");

                    b.HasKey("IdVaga", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("VAGAS_FAVORITADAS");
                });

            modelBuilder.Entity("JobCoinAPI.Models.PerfilFuncionalidade", b =>
                {
                    b.HasOne("JobCoinAPI.Models.Funcionalidade", "Funcionalidade")
                        .WithMany()
                        .HasForeignKey("IdFuncionalidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobCoinAPI.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobCoinAPI.Models.Perfil", null)
                        .WithMany("Funcionalidades")
                        .HasForeignKey("PerfilIdPerfil");

                    b.Navigation("Funcionalidade");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Usuario", b =>
                {
                    b.HasOne("JobCoinAPI.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Vaga", b =>
                {
                    b.HasOne("JobCoinAPI.Models.Usuario", "UsuarioCriacaoVaga")
                        .WithMany("VagasCriadas")
                        .HasForeignKey("IdUsuarioCriacaoVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCriacaoVaga");
                });

            modelBuilder.Entity("JobCoinAPI.Models.VagaFavoritadaUsuario", b =>
                {
                    b.HasOne("JobCoinAPI.Models.Usuario", "Usuario")
                        .WithMany("VagasFavoritadas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobCoinAPI.Models.Vaga", "Vaga")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Perfil", b =>
                {
                    b.Navigation("Funcionalidades");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Usuario", b =>
                {
                    b.Navigation("VagasCriadas");

                    b.Navigation("VagasFavoritadas");
                });

            modelBuilder.Entity("JobCoinAPI.Models.Vaga", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
