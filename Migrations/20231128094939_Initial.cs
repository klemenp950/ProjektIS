using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avtor",
                columns: table => new
                {
                    AvtorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avtor", x => x.AvtorID);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.TipID);
                });

            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SteviloVrstic = table.Column<int>(type: "int", nullable: false),
                    SteviloZnakov = table.Column<int>(type: "int", nullable: false),
                    Velikost = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipID = table.Column<int>(type: "int", nullable: true),
                    AvtorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                    table.ForeignKey(
                        name: "FK_Dokument_Avtor_AvtorID",
                        column: x => x.AvtorID,
                        principalTable: "Avtor",
                        principalColumn: "AvtorID");
                    table.ForeignKey(
                        name: "FK_Dokument_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "TipID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_AvtorID",
                table: "Dokument",
                column: "AvtorID");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_TipID",
                table: "Dokument",
                column: "TipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "Avtor");

            migrationBuilder.DropTable(
                name: "Tip");
        }
    }
}
