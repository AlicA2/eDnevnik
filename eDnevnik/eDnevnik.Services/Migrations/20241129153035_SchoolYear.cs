using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class SchoolYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GodinaUpisa",
                table: "KorisnikDetalji");

            migrationBuilder.DropColumn(
                name: "UpisanaSkolskaGodina",
                table: "KorisnikDetalji");

            migrationBuilder.AddColumn<int>(
                name: "GodinaUpisaID",
                table: "KorisnikDetalji",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SkolskaGodina",
                columns: table => new
                {
                    SkolskaGodinaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkolskaGodina", x => x.SkolskaGodinaID);
                });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.InsertData(
                table: "SkolskaGodina",
                columns: new[] { "SkolskaGodinaID", "Naziv" },
                values: new object[,]
                {
                    { 1, "2024/2025" },
                    { 2, "2025/2026" }
                });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikDetalji_GodinaUpisaID",
                table: "KorisnikDetalji",
                column: "GodinaUpisaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikDetalji_UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji",
                column: "UpisanaSkolskaGodinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikDetalji_SkolskaGodina_GodinaUpisaID",
                table: "KorisnikDetalji",
                column: "GodinaUpisaID",
                principalTable: "SkolskaGodina",
                principalColumn: "SkolskaGodinaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikDetalji_SkolskaGodina_UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji",
                column: "UpisanaSkolskaGodinaID",
                principalTable: "SkolskaGodina",
                principalColumn: "SkolskaGodinaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikDetalji_SkolskaGodina_GodinaUpisaID",
                table: "KorisnikDetalji");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikDetalji_SkolskaGodina_UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji");

            migrationBuilder.DropTable(
                name: "SkolskaGodina");

            migrationBuilder.DropIndex(
                name: "IX_KorisnikDetalji_GodinaUpisaID",
                table: "KorisnikDetalji");

            migrationBuilder.DropIndex(
                name: "IX_KorisnikDetalji_UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji");

            migrationBuilder.DropColumn(
                name: "GodinaUpisaID",
                table: "KorisnikDetalji");

            migrationBuilder.DropColumn(
                name: "UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji");

            migrationBuilder.AddColumn<DateTime>(
                name: "GodinaUpisa",
                table: "KorisnikDetalji",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpisanaSkolskaGodina",
                table: "KorisnikDetalji",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8121));
        }
    }
}
