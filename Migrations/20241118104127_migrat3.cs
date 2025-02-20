using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class migrat3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrets_Trajets_TrajetId",
                table: "Arrets");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Arrets_Trajets_TrajetId",
                table: "Arrets",
                column: "TrajetId",
                principalTable: "Trajets",
                principalColumn: "Id");
        }
    }
}
