using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class RequiredStatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GodinaUpisaID",
                table: "KorisnikDetalji",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(3315));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 32, 3, 485, DateTimeKind.Local).AddTicks(2499));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpisanaSkolskaGodinaID",
                table: "KorisnikDetalji",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GodinaUpisaID",
                table: "KorisnikDetalji",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 21, 18, 58, 543, DateTimeKind.Local).AddTicks(7745));
        }
    }
}
