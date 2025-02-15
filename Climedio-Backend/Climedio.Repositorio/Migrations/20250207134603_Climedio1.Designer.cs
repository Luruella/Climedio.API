﻿// <auto-generated />
using System;
using Climedio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Climedio.Repositorio.Migrations
{
    [DbContext(typeof(ClimedioContexto))]
    [Migration("20250207134603_Climedio1")]
    partial class Climedio1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Climedio.Dominio.Entidades.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgendamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataHora");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observacao");

                    b.Property<int>("UsuarioIdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioIdPaciente");

                    b.Property<int>("UsuarioIdProfissional")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioIdProfissional");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioIdPaciente");

                    b.HasIndex("UsuarioIdProfissional");

                    b.ToTable("Agendamentos", (string)null);
                });

            modelBuilder.Entity("Climedio.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Senha");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("TipoUsuario");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Climedio.Dominio.Entidades.Agendamento", b =>
                {
                    b.HasOne("Climedio.Dominio.Entidades.Usuario", "UsuarioPaciente")
                        .WithMany("AgendamentosPaciente")
                        .HasForeignKey("UsuarioIdPaciente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Climedio.Dominio.Entidades.Usuario", "UsuarioProfissional")
                        .WithMany("AgendamentosProfissional")
                        .HasForeignKey("UsuarioIdProfissional")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioPaciente");

                    b.Navigation("UsuarioProfissional");
                });

            modelBuilder.Entity("Climedio.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("AgendamentosPaciente");

                    b.Navigation("AgendamentosProfissional");
                });
#pragma warning restore 612, 618
        }
    }
}
