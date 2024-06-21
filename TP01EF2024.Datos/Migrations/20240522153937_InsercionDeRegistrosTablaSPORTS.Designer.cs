﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP01EF2024.Datos;

#nullable disable

namespace TP01EF2024.Datos.Migrations
{
    [DbContext(typeof(TP01DbContext))]
    [Migration("20240522153937_InsercionDeRegistrosTablaSPORTS")]
    partial class InsercionDeRegistrosTablaSPORTS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TP01EF2024.Entidades.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrandId");

                    b.HasIndex("BrandName")
                        .IsUnique();

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "Vans"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "Adidas"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "Topper"
                        });
                });

            modelBuilder.Entity("TP01EF2024.Entidades.Colour", b =>
                {
                    b.Property<int>("ColourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColourId"));

                    b.Property<string>("ColourName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ColourId");

                    b.HasIndex("ColourName")
                        .IsUnique();

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("TP01EF2024.Entidades.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GenreId");

                    b.HasIndex("GenreName")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Femenino"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Masculino"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Unisex"
                        });
                });

            modelBuilder.Entity("TP01EF2024.Entidades.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SportId"));

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SportId");

                    b.HasIndex("SportName")
                        .IsUnique();

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            SportId = 1,
                            SportName = "Futbol"
                        },
                        new
                        {
                            SportId = 2,
                            SportName = "Tenis"
                        },
                        new
                        {
                            SportId = 3,
                            SportName = "Basquet"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
