﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservasAPI.Data;

#nullable disable

namespace ReservasAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220915025128_Relacion_Hotel_Reservas_Turista")]
    partial class Relacion_Hotel_Reservas_Turista
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReservasAPI.Data.Entities.ContratoSucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.Property<int>("IdTurista")
                        .HasColumnType("int");

                    b.Property<int>("SucursalId")
                        .HasColumnType("int");

                    b.Property<int>("TuristaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SucursalId");

                    b.HasIndex("TuristaId");

                    b.ToTable("ContratosSucursales");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("CodHotel")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumeroPlazas")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TuristaId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.ReservaHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.Property<int>("IdTurista")
                        .HasColumnType("int");

                    b.Property<string>("Regimen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TuristaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TuristaId");

                    b.ToTable("ReservaHotel");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("CodSucursal")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Turista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("CodTurista")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Turistas");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.ContratoSucursal", b =>
                {
                    b.HasOne("ReservasAPI.Data.Entities.Sucursal", "Sucursal")
                        .WithMany("ContratosSucursal")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservasAPI.Data.Entities.Turista", "Turista")
                        .WithMany("ContratosSucursal")
                        .HasForeignKey("TuristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursal");

                    b.Navigation("Turista");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Hotel", b =>
                {
                    b.HasOne("ReservasAPI.Data.Entities.Turista", null)
                        .WithMany("Hoteles")
                        .HasForeignKey("TuristaId");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.ReservaHotel", b =>
                {
                    b.HasOne("ReservasAPI.Data.Entities.Hotel", "Hotel")
                        .WithMany("Reservas")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservasAPI.Data.Entities.Turista", "Turista")
                        .WithMany()
                        .HasForeignKey("TuristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Turista");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Hotel", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Sucursal", b =>
                {
                    b.Navigation("ContratosSucursal");
                });

            modelBuilder.Entity("ReservasAPI.Data.Entities.Turista", b =>
                {
                    b.Navigation("ContratosSucursal");

                    b.Navigation("Hoteles");
                });
#pragma warning restore 612, 618
        }
    }
}
