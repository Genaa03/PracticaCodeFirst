﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Practica2CodeFirst.Context;

#nullable disable

namespace Practica2CodeFirst.Migrations
{
    [DbContext(typeof(ContextBD))]
    partial class ContextBDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Practica2CodeFirst.Models.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Ciudad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Empleado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdCargo")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdJefe")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdSucursal")
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdJefe");

                    b.HasIndex("IdSucursal");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Sucursal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdCiudad")
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudad");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Empleado", b =>
                {
                    b.HasOne("Practica2CodeFirst.Models.Cargo", "Cargo")
                        .WithMany("Empleados")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practica2CodeFirst.Models.Empleado", "Jefe")
                        .WithMany("Empleados")
                        .HasForeignKey("IdJefe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practica2CodeFirst.Models.Sucursal", "Sucursal")
                        .WithMany("Empleados")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Jefe");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Sucursal", b =>
                {
                    b.HasOne("Practica2CodeFirst.Models.Ciudad", "Ciudad")
                        .WithMany("Sucursales")
                        .HasForeignKey("IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Cargo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Ciudad", b =>
                {
                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Empleado", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Practica2CodeFirst.Models.Sucursal", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}