using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class PredmetSkola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkolaID",
                table: "Predmeti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 12, 11, 32, 35, 519, DateTimeKind.Local).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 12, 11, 32, 35, 519, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 1,
                column: "SkolaID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 2,
                column: "SkolaID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 12, 11, 32, 35, 519, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 12, 11, 32, 35, 519, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 12, 11, 32, 35, 519, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 12, 11, 32, 35, 519, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_SkolaID",
                table: "Predmeti",
                column: "SkolaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Predmeti_Skola_SkolaID",
                table: "Predmeti",
                column: "SkolaID",
                principalTable: "Skola",
                principalColumn: "SkolaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predmeti_Skola_SkolaID",
                table: "Predmeti");

            migrationBuilder.DropIndex(
                name: "IX_Predmeti_SkolaID",
                table: "Predmeti");

            migrationBuilder.DropColumn(
                name: "SkolaID",
                table: "Predmeti");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 8, 17, 32, 7, 378, DateTimeKind.Local).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 8, 8, 17, 32, 7, 378, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 32, 7, 378, DateTimeKind.Local).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 32, 7, 378, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 32, 7, 378, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 8, 8, 17, 32, 7, 378, DateTimeKind.Local).AddTicks(9628));
        }
    }
}
