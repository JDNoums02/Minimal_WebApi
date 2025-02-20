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
    [Migration("20241118203858_AjoutTableChauffeurs")]
    partial class AjoutTableChauffeurs
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

                    b.ToTable("Arrets");
                });

            modelBuilder.Entity("TP3.Models.Chauffeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Couriel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFinEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoLicence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SalaireHoraire")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Chauffeurs");
                });

            modelBuilder.Entity("TP3.Models.Trajet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChauffeurId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreationTrajet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChauffeurId");

                    b.ToTable("Trajets");
                });

            modelBuilder.Entity("TP3.Models.Arret", b =>
                {
                    b.HasOne("TP3.Models.Trajet", "Trajet")
                        .WithMany("PointsArret")
                        .HasForeignKey("TrajetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Trajet");
                });

            modelBuilder.Entity("TP3.Models.Trajet", b =>
                {
                    b.HasOne("TP3.Models.Chauffeur", null)
                        .WithMany("TrajetsFormationRecue")
                        .HasForeignKey("ChauffeurId");
                });

            modelBuilder.Entity("TP3.Models.Chauffeur", b =>
                {
                    b.Navigation("TrajetsFormationRecue");
                });

            modelBuilder.Entity("TP3.Models.Trajet", b =>
                {
                    b.Navigation("PointsArret");
                });
#pragma warning restore 612, 618
        }
    }
}
