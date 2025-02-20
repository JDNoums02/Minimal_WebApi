using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class LiaisonChauffeurTrajet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trajets_Chauffeurs_ChauffeurId",
                table: "Trajets");

            migrationBuilder.DropIndex(
                name: "IX_Trajets_ChauffeurId",
                table: "Trajets");

            migrationBuilder.DropColumn(
                name: "ChauffeurId",
                table: "Trajets");

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
                        name: "FK_ChauffeurTrajet_Chauffeurs_ChauffeursFormesId",
                        column: x => x.ChauffeursFormesId,
                        principalTable: "Chauffeurs",
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
                name: "IX_ChauffeurTrajet_TrajetsFormationRecueId",
                table: "ChauffeurTrajet",
                column: "TrajetsFormationRecueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChauffeurTrajet");

            migrationBuilder.AddColumn<int>(
                name: "ChauffeurId",
                table: "Trajets",
                type: "int",
                nullable: true);

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
    }
}
