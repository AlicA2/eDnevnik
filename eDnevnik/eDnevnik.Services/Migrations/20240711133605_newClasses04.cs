using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class newClasses04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 15, 36, 5, 205, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 15, 36, 5, 205, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 36, 5, 205, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 36, 5, 205, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 36, 5, 205, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 36, 5, 205, DateTimeKind.Local).AddTicks(1813));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 15, 33, 13, 237, DateTimeKind.Local).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 15, 33, 13, 237, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 33, 13, 237, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 33, 13, 237, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 33, 13, 237, DateTimeKind.Local).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 33, 13, 237, DateTimeKind.Local).AddTicks(6692));
        }
    }
}
