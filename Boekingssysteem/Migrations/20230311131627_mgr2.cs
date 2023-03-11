using Microsoft.EntityFrameworkCore.Migrations;

namespace Boekingssysteem.Migrations
{
    public partial class mgr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Voonraam",
                schema: "BS",
                table: "Gebruiker");

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                schema: "BS",
                table: "Gebruiker",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Voornaam",
                schema: "BS",
                table: "Gebruiker");

            migrationBuilder.AddColumn<string>(
                name: "Voonraam",
                schema: "BS",
                table: "Gebruiker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
