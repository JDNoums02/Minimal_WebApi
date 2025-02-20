using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTableTrajet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chauffeur",
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
                    table.PrimaryKey("PK_Chauffeur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trajets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreationTrajet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arret",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrajetId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arret_Trajets_TrajetId",
                        column: x => x.TrajetId,
                        principalTable: "Trajets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChauffeurTrajet",
                columns: table => new
                {
                    ChauffeursFormesId = table.Column<int>(type: "int", nullable: false),
                    TrajetsFormationRecueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChauffeurTrajet", x => new { x.ChauffeursFormesId, x.TrajetsFormationRecueId });
                    table.ForeignKey(
                        name: "FK_ChauffeurTrajet_Chauffeur_ChauffeursFormesId",
                        column: x => x.ChauffeursFormesId,
                        principalTable: "Chauffeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChauffeurTrajet_Trajets_TrajetsFormationRecueId",
                        column: x => x.TrajetsFormationRecueId,
                        principalTable: "Trajets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arret_TrajetId",
                table: "Arret",
                column: "TrajetId");

            migrationBuilder.CreateIndex(
                name: "IX_ChauffeurTrajet_TrajetsFormationRecueId",
                table: "ChauffeurTrajet",
                column: "TrajetsFormationRecueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arret");

            migrationBuilder.DropTable(
                name: "ChauffeurTrajet");

            migrationBuilder.DropTable(
                name: "Chauffeur");

            migrationBuilder.DropTable(
                name: "Trajets");
        }
    }
}
