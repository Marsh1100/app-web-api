﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(IncidenciasContext))]
    partial class IncidenciasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdDepFK")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreCiu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepFK");

                    b.ToTable("Ciudad", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdPaisFK")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreDep")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPaisFK");

                    b.HasIndex("NombreDep")
                        .IsUnique();

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdPersonaFK")
                        .HasColumnType("longtext");

                    b.Property<string>("IdSalonFK")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdSalonFK");

                    b.ToTable("Matricula", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<string>("IdCiudadFK")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdTipoPersonaFK")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudadFK");

                    b.HasIndex("IdTipoPersonaFK");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Salon", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreSalon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Salon", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.ToTable("TipoPersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TrainerSalon", b =>
                {
                    b.Property<string>("IdSalonFK")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdPersonaFK")
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdSalonFK", "IdPersonaFK");

                    b.HasIndex("IdPersonaFK");

                    b.ToTable("TrainerSalones");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepFK");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("Dominio.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFK");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("Matriculas")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Salon", "Salon")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdSalonFK");

                    b.Navigation("Persona");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.Ciudad", "Ciudad")
                        .WithMany("Personas")
                        .HasForeignKey("IdCiudadFK");

                    b.HasOne("Dominio.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonaFK");

                    b.Navigation("Ciudad");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Dominio.Entities.TrainerSalon", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("TrainerSalones")
                        .HasForeignKey("IdPersonaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Salon", "Salon")
                        .WithMany("TrainerSalones")
                        .HasForeignKey("IdSalonFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("TrainerSalones");
                });

            modelBuilder.Entity("Dominio.Entities.Salon", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("TrainerSalones");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}