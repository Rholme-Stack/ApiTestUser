﻿// <auto-generated />
using System;
using ApiTestUser.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTestUser.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250225123948_Update nombre tabla")]
    partial class Updatenombretabla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiTestUser.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("SalarioBase")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias", (string)null);

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            Descripcion = "Puesto de inicio",
                            Nivel = 1,
                            Nombre = "Programador jr",
                            SalarioBase = 1000m
                        },
                        new
                        {
                            IdCategoria = 2,
                            Descripcion = "Puesto intermedio",
                            Nivel = 2,
                            Nombre = "Programador sr",
                            SalarioBase = 2000m
                        },
                        new
                        {
                            IdCategoria = 3,
                            Descripcion = "Puesto avanzado",
                            Nivel = 3,
                            Nombre = "Programador pl",
                            SalarioBase = 3000m
                        },
                        new
                        {
                            IdCategoria = 4,
                            Descripcion = "Puesto de liderazgo",
                            Nivel = 4,
                            Nombre = "Arquitecto",
                            SalarioBase = 4000m
                        });
                });

            modelBuilder.Entity("ApiTestUser.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<DateTime>("FechaNasc")
                        .HasColumnType("date");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idUsuario");

                    b.HasIndex("idCategoria");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("ApiTestUser.Models.Usuario", b =>
                {
                    b.HasOne("ApiTestUser.Models.Categoria", "CategoriaReferencia")
                        .WithMany("UsuariosReferencia")
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaReferencia");
                });

            modelBuilder.Entity("ApiTestUser.Models.Categoria", b =>
                {
                    b.Navigation("UsuariosReferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
