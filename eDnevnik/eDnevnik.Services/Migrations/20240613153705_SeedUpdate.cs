using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class SeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Odjeljenje",
                columns: new[] { "OdjeljenjeID", "NazivOdjeljenja", "RazrednikID" },
                values: new object[] { 1, "1A", 1 });

            migrationBuilder.InsertData(
                table: "Predmeti",
                columns: new[] { "PredmetID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Matematika", "Sabiranje,oduzimanje,množenje,dijeljenje" },
                    { 2, "Biologija", "Biljke" }
                });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 6, 13, 17, 37, 4, 803, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 6, 13, 17, 37, 4, 803, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 6, 13, 17, 37, 4, 803, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.InsertData(
                table: "Ocjene",
                columns: new[] { "OcjenaID", "Datum", "Ocjena", "PredmetID", "ProfesorID", "UcenikID" },
                values: new object[] { 1, new DateTime(2024, 6, 13, 17, 37, 4, 803, DateTimeKind.Local).AddTicks(8225), 5, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Ocjene",
                columns: new[] { "OcjenaID", "Datum", "Ocjena", "PredmetID", "ProfesorID", "UcenikID" },
                values: new object[] { 2, new DateTime(2024, 6, 13, 17, 37, 4, 803, DateTimeKind.Local).AddTicks(8232), 4, 2, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 6, 13, 16, 34, 15, 447, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 6, 13, 16, 34, 15, 447, DateTimeKind.Local).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 6, 13, 16, 34, 15, 447, DateTimeKind.Local).AddTicks(9243));
        }
    }
}
