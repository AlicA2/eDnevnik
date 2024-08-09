using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class OdjeljenjeUpdate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RazrednikID",
                table: "Odjeljenje",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 8, 17, 16, 44, 95, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 8, 17, 16, 44, 95, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 1,
                column: "RazrednikID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 2,
                column: "RazrednikID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 16, 44, 95, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 16, 44, 95, DateTimeKind.Local).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 16, 44, 95, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 16, 44, 95, DateTimeKind.Local).AddTicks(2943));

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_RazrednikID",
                table: "Odjeljenje",
                column: "RazrednikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Odjeljenje_Korisnici_RazrednikID",
                table: "Odjeljenje",
                column: "RazrednikID",
                principalTable: "Korisnici",
                principalColumn: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Odjeljenje_Korisnici_RazrednikID",
                table: "Odjeljenje");

            migrationBuilder.DropIndex(
                name: "IX_Odjeljenje_RazrednikID",
                table: "Odjeljenje");

            migrationBuilder.DropColumn(
                name: "RazrednikID",
                table: "Odjeljenje");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 8, 15, 35, 19, 482, DateTimeKind.Local).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 8, 15, 35, 19, 482, DateTimeKind.Local).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 15, 35, 19, 482, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 15, 35, 19, 482, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 15, 35, 19, 482, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 15, 35, 19, 482, DateTimeKind.Local).AddTicks(854));
        }
    }
}
