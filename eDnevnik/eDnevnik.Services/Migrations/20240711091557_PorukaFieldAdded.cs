using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class PorukaFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Odgovor",
                table: "Poruke",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8101));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odgovor",
                table: "Poruke");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 10, 13, 58, 18, 319, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 10, 13, 58, 18, 319, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 10, 13, 58, 18, 319, DateTimeKind.Local).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 10, 13, 58, 18, 319, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 10, 13, 58, 18, 319, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 10, 13, 58, 18, 319, DateTimeKind.Local).AddTicks(6470));
        }
    }
}
