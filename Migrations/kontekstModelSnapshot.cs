﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt.Data;

#nullable disable

namespace Projekt.Migrations
{
    [DbContext(typeof(kontekst))]
    partial class kontekstModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("projekt.Models.Avtor", b =>
                {
                    b.Property<int>("AvtorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvtorID"), 1L, 1);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priimek")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvtorID");

                    b.ToTable("Avtor", (string)null);
                });

            modelBuilder.Entity("projekt.Models.Dokument", b =>
                {
                    b.Property<int?>("DokumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DokumentID"), 1L, 1);

                    b.Property<int?>("AvtorID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SteviloVrstic")
                        .HasColumnType("int");

                    b.Property<int>("SteviloZnakov")
                        .HasColumnType("int");

                    b.Property<int?>("TipID")
                        .HasColumnType("int");

                    b.Property<int>("Velikost")
                        .HasColumnType("int");

                    b.HasKey("DokumentID");

                    b.HasIndex("AvtorID");

                    b.HasIndex("TipID");

                    b.ToTable("Dokument", (string)null);
                });

            modelBuilder.Entity("projekt.Models.Tip", b =>
                {
                    b.Property<int>("TipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipID"), 1L, 1);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipID");

                    b.ToTable("Tip", (string)null);
                });

            modelBuilder.Entity("projekt.Models.Dokument", b =>
                {
                    b.HasOne("projekt.Models.Avtor", "Avtor")
                        .WithMany("Dokumenti")
                        .HasForeignKey("AvtorID");

                    b.HasOne("projekt.Models.Tip", "Tip")
                        .WithMany("Dokumenti")
                        .HasForeignKey("TipID");

                    b.Navigation("Avtor");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("projekt.Models.Avtor", b =>
                {
                    b.Navigation("Dokumenti");
                });

            modelBuilder.Entity("projekt.Models.Tip", b =>
                {
                    b.Navigation("Dokumenti");
                });
#pragma warning restore 612, 618
        }
    }
}
