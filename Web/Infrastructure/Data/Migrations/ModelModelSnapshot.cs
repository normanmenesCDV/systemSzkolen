﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAppService.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.PracownikAggregate.Pracownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DataUrodzenia")
                        .HasColumnType("date");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PESEL")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Plec")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid");

                    b.ToTable("Pracownicy");
                });

            modelBuilder.Entity("Domain.SzkolenieAggregate.Szkolenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DataRozpoczecia")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DataZakonczenia")
                        .HasColumnType("date");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Organizator")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid");

                    b.ToTable("Szkolenia");
                });

            modelBuilder.Entity("Domain.SzkolenieAggregate.SzkoleniePracownik", b =>
                {
                    b.Property<int>("SzkolenieId")
                        .HasColumnType("int");

                    b.Property<int>("PracownikId")
                        .HasColumnType("int");

                    b.Property<decimal?>("WynikWProc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SzkolenieId", "PracownikId");

                    b.HasIndex("PracownikId");

                    b.ToTable("SzkoleniaPracownicy");
                });

            modelBuilder.Entity("Domain.SzkolenieAggregate.SzkoleniePracownik", b =>
                {
                    b.HasOne("Domain.PracownikAggregate.Pracownik", "Pracownik")
                        .WithMany("SzkoleniaPracownicy")
                        .HasForeignKey("PracownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.SzkolenieAggregate.Szkolenie", "Szkolenie")
                        .WithMany("SzkoleniaPracownicy")
                        .HasForeignKey("SzkolenieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracownik");

                    b.Navigation("Szkolenie");
                });

            modelBuilder.Entity("Domain.PracownikAggregate.Pracownik", b =>
                {
                    b.Navigation("SzkoleniaPracownicy");
                });

            modelBuilder.Entity("Domain.SzkolenieAggregate.Szkolenie", b =>
                {
                    b.Navigation("SzkoleniaPracownicy");
                });
#pragma warning restore 612, 618
        }
    }
}
