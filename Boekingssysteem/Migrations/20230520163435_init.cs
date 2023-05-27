using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boekingssysteem.Migrations
{
<<<<<<<< HEAD:Boekingssysteem/Migrations/20230520112121_int.cs
    public partial class @int : Migration
========
    public partial class init : Migration
>>>>>>>> 7bb493216398f255f93da3745eb33fbce127fab8:Boekingssysteem/Migrations/20230520163435_init.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BS");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "BS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "BS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Rnummer = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
<<<<<<<< HEAD:Boekingssysteem/Migrations/20230520112121_int.cs
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
========
>>>>>>>> 7bb493216398f255f93da3745eb33fbce127fab8:Boekingssysteem/Migrations/20230520163435_init.cs
                name: "AspNetRoleClaims",
                schema: "BS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BS",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
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
<<<<<<<< HEAD:Boekingssysteem/Migrations/20230520112121_int.cs
                    Rnummer = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true)
========
                    Rnummer = table.Column<string>(nullable: false)
>>>>>>>> 7bb493216398f255f93da3745eb33fbce127fab8:Boekingssysteem/Migrations/20230520163435_init.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afwezigheid", x => x.AfwezigheidId);
                    table.ForeignKey(
                        name: "FK_Afwezigheid_AspNetUsers_Rnummer",
                        column: x => x.Rnummer,
                        principalSchema: "BS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "BS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "BS",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "BS",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BS",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "BS",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                        name: "FK_DocentRichting_AspNetUsers_Rnummer",
                        column: x => x.Rnummer,
                        principalSchema: "BS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

<<<<<<<< HEAD:Boekingssysteem/Migrations/20230520112121_int.cs
            migrationBuilder.CreateTable(
                name: "Gebruiker",
                schema: "BS",
                columns: table => new
                {
                    Rnummer = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
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

========
>>>>>>>> 7bb493216398f255f93da3745eb33fbce127fab8:Boekingssysteem/Migrations/20230520163435_init.cs
            migrationBuilder.CreateIndex(
                name: "IX_Afwezigheid_Rnummer",
                schema: "BS",
                table: "Afwezigheid",
                column: "Rnummer");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "BS",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "BS",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "BS",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "BS",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "BS",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "BS",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "BS",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
<<<<<<<< HEAD:Boekingssysteem/Migrations/20230520112121_int.cs

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_RolId",
                schema: "BS",
                table: "Gebruiker",
                column: "RolId");
========
>>>>>>>> 7bb493216398f255f93da3745eb33fbce127fab8:Boekingssysteem/Migrations/20230520163435_init.cs
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afwezigheid",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "DocentRichting",
                schema: "BS");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:Boekingssysteem/Migrations/20230520112121_int.cs
                name: "Gebruiker",
                schema: "BS");

            migrationBuilder.DropTable(
========
>>>>>>>> 7bb493216398f255f93da3745eb33fbce127fab8:Boekingssysteem/Migrations/20230520163435_init.cs
                name: "AspNetRoles",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "Richting",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "BS");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "BS");
        }
    }
}
