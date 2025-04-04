﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP3;

#nullable disable

namespace TP3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118203404_AjoutTableTrajet")]
    partial class AjoutTableTrajet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TP3.Models.Arret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("TrajetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrajetId");

                    b.ToTable("Arret");
                });

            modelBuilder.Entity("TP3.Models.Trajet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreationTrajet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trajets");
                });

            modelBuilder.Entity("TP3.Models.Arret", b =>
                {
                    b.HasOne("TP3.Models.Trajet", "Trajet")
                        .WithMany("PointsArret")
                        .HasForeignKey("TrajetId");

                    b.Navigation("Trajet");
                });

            modelBuilder.Entity("TP3.Models.Trajet", b =>
                {
                    b.Navigation("PointsArret");
                });
#pragma warning restore 612, 618
        }
    }
}
