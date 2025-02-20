using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTableArret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arret_Trajets_TrajetId",
                table: "Arret");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arret",
                table: "Arret");

            migrationBuilder.RenameTable(
                name: "Arret",
                newName: "Arrets");

            migrationBuilder.RenameIndex(
                name: "IX_Arret_TrajetId",
                table: "Arrets",
                newName: "IX_Arrets_TrajetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arrets",
                table: "Arrets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrets_Trajets_TrajetId",
                table: "Arrets",
                column: "TrajetId",
                principalTable: "Trajets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrets_Trajets_TrajetId",
                table: "Arrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arrets",
                table: "Arrets");

            migrationBuilder.RenameTable(
                name: "Arrets",
                newName: "Arret");

            migrationBuilder.RenameIndex(
                name: "IX_Arrets_TrajetId",
                table: "Arret",
                newName: "IX_Arret_TrajetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arret",
                table: "Arret",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arret_Trajets_TrajetId",
                table: "Arret",
                column: "TrajetId",
                principalTable: "Trajets",
                principalColumn: "Id");
        }
    }
}
