﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroWebApi.DataContext;

namespace RegistroWebApi.Migrations
{
    [DbContext(typeof(RegisterDataContext))]
    partial class RegisterDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RegistroWebApi.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("RegistroWebApi.Models.Ciudadano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FotoDeCiudadano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<string>("IdCiudadano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDeTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudad");

                    b.ToTable("Ciudadanos");
                });

            modelBuilder.Entity("RegistroWebApi.Models.Ciudadano", b =>
                {
                    b.HasOne("RegistroWebApi.Models.Ciudad", "Ciudad")
                        .WithMany("Ciudadanos")
                        .HasForeignKey("IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}