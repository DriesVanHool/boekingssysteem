using Microsoft.EntityFrameworkCore.Migrations;

namespace Boekingssysteem.Migrations
{
    public partial class customUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                schema: "BS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rnummer",
                schema: "BS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "BS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                schema: "BS",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achternaam",
                schema: "BS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rnummer",
                schema: "BS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "BS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                schema: "BS",
                table: "AspNetUsers");
        }
    }
}
