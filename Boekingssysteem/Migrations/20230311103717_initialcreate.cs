using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boekingssysteem.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BS");

            migrationBuilder.CreateTable(
                name: "Richting",
                schema: "BS",
                columns: table => new
                {
                    RichtingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Richting", x => x.RichtingId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "BS",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                schema: "BS",
                columns: table => new
                {
                    Rnummer = table.Column<string>(nullable: false),
                    Voonraam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Rnummer);
                    table.ForeignKey(
                        name: "FK_Gebruiker_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "BS",
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afwezigheid",
                schema: "BS",
                columns: table => new
                {
                    AfwezigheidId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begindatum = table.Column<DateTime>(nullable: false),
                    Einddatum = table.Column<DateTime>(nullable: false),
                    Opmerking = table.Column<string>(nullable: true),
                    Rnummer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afwezigheid", x => x.AfwezigheidId);
                    table.ForeignKey(
                        name: "FK_Afwezigheid_Gebruiker_Rnummer",
                        column: x => x.Rnummer,
                        principalSchema: "BS",
                        principalTable: "Gebruiker",
                        principalColumn: "Rnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocentRichting",
                schema: "BS",
                columns: table => new
                {
                    DocentRichtingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rnummer = table.Column<string>(nullable: false),
                    RichtingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocentRichting", x => x.DocentRichtingId);
                    table.ForeignKey(
                        name: "FK_DocentRichting_Richting_RichtingId",
                        column: x => x.RichtingId,
                        principalSchema: "BS",
                        principalTable: "Richting",
                        principalColumn: "RichtingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocentRichting_Gebruiker_Rnummer",
                        column: x => x.Rnummer,
                        principalSchema: "BS",
                        principalTable: "Gebruiker",
                        principalColumn: "Rnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afwezigheid_Rnummer",
                schema: "BS",
                table: "Afwezigheid",
                column: "Rnummer");

            migrationBuilder.CreateIndex(
                name: "IX_DocentRichting_RichtingId",
                schema: "BS",
                table: "DocentRichting",
                column: "RichtingId");

            migrationBuilder.CreateIndex(
                name: "IX_DocentRichting_Rnummer",
                schema: "BS",
                table: "DocentRichting",
                column: "Rnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_RolId",
                schema: "BS",
                table: "Gebruiker",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afwezigheid",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "DocentRichting",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "Richting",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "Gebruiker",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "BS");
        }
    }
}
