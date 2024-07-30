using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class ReTry01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 29, 14, 35, 49, 206, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 29, 14, 35, 49, 206, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 35, 49, 206, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 35, 49, 206, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 35, 49, 206, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 35, 49, 206, DateTimeKind.Local).AddTicks(6634));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 29, 14, 17, 10, 233, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 29, 14, 17, 10, 233, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 17, 10, 233, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 17, 10, 233, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 17, 10, 233, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 29, 14, 17, 10, 233, DateTimeKind.Local).AddTicks(1406));
        }
    }
}
