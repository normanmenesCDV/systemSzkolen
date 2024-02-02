using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Imie = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Plec = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DataUrodzenia = table.Column<DateOnly>(type: "date", nullable: true),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.Id);
                    table.UniqueConstraint("AK_Pracownicy_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Szkolenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Nazwa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Organizator = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataRozpoczecia = table.Column<DateOnly>(type: "date", nullable: true),
                    DataZakonczenia = table.Column<DateOnly>(type: "date", nullable: true),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szkolenia", x => x.Id);
                    table.UniqueConstraint("AK_Szkolenia_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "SzkoleniaPracownicy",
                columns: table => new
                {
                    SzkolenieId = table.Column<int>(type: "int", nullable: false),
                    PracownikId = table.Column<int>(type: "int", nullable: false),
                    WynikWProc = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SzkoleniaPracownicy", x => new { x.SzkolenieId, x.PracownikId });
                    table.ForeignKey(
                        name: "FK_SzkoleniaPracownicy_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SzkoleniaPracownicy_Szkolenia_SzkolenieId",
                        column: x => x.SzkolenieId,
                        principalTable: "Szkolenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SzkoleniaPracownicy_PracownikId",
                table: "SzkoleniaPracownicy",
                column: "PracownikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SzkoleniaPracownicy");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Szkolenia");
        }
    }
}
