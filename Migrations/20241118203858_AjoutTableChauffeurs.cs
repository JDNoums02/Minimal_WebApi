using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTableChauffeurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChauffeurId",
                table: "Trajets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Couriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaireHoraire = table.Column<float>(type: "real", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoLicence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinEmbauche = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trajets_ChauffeurId",
                table: "Trajets",
                column: "ChauffeurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trajets_Chauffeurs_ChauffeurId",
                table: "Trajets",
                column: "ChauffeurId",
                principalTable: "Chauffeurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trajets_Chauffeurs_ChauffeurId",
                table: "Trajets");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropIndex(
                name: "IX_Trajets_ChauffeurId",
                table: "Trajets");

            migrationBuilder.DropColumn(
                name: "ChauffeurId",
                table: "Trajets");
        }
    }
}
