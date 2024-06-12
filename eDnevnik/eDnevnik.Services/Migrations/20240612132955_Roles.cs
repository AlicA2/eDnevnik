using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LozinkaHask",
                table: "Korisnici",
                newName: "LozinkaHash");

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "korisniciUloges",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UlogaID = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisniciUloges", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "FK_korisniciUloges_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_korisniciUloges_Uloge_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Status", "Telefon" },
                values: new object[,]
                {
                    { 1, "adminadmin@gmail.com", "admin", "admin", "", "", "admin", null, "+38700000000" },
                    { 2, "ucenik@gmail.com", "ucenik", "ucenik", "", "", "ucenik", null, "+38700000000" },
                    { 3, "roditelj@gmail.com", "roditelj", "roditelj", "", "", "roditelj", null, "+38700000000" }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "admin", "admin ili profesor" },
                    { 2, "učenik", "učenik/ca" },
                    { 3, "roditelj", "roditelj" }
                });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[] { 1, new DateTime(2024, 6, 12, 15, 29, 55, 192, DateTimeKind.Local).AddTicks(2152), 1, 1 });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[] { 2, new DateTime(2024, 6, 12, 15, 29, 55, 192, DateTimeKind.Local).AddTicks(2237), 2, 2 });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[] { 3, new DateTime(2024, 6, 12, 15, 29, 55, 192, DateTimeKind.Local).AddTicks(2240), 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_korisniciUloges_KorisnikID",
                table: "korisniciUloges",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_korisniciUloges_UlogaID",
                table: "korisniciUloges",
                column: "UlogaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "korisniciUloges");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "LozinkaHash",
                table: "Korisnici",
                newName: "LozinkaHask");
        }
    }
}
