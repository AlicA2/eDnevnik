using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class CasoviUpdate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        DELETE FROM [GodisnjiPlanProgram] WHERE [GodisnjiPlanProgramID] = 1;
        DELETE FROM [GodisnjiPlanProgram] WHERE [GodisnjiPlanProgramID] = 2;
    ");
            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[,]
                {
                    { 1, "Plan 1", 1, 1, 1, 5 },
                    { 2, "Plan 2", 2, 2, 2, 7 }
                });

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
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 1,
                column: "StateMachine",
                value: "draft");

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 2,
                column: "StateMachine",
                value: "draft");

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

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "GodisnjiPlanProgramID", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 1, 1, "Cas 1", "Opis Casa 1" },
                    { 2, 1, "Cas 2", "Opis Casa 2" },
                    { 3, 1, "Cas 3", "Opis Casa 3" },
                    { 4, 1, "Cas 4", "Opis Casa 4" },
                    { 5, 1, "Cas 5", "Opis Casa 5" },
                    { 6, 2, "Cas 1", "Opis Casa 6" },
                    { 7, 2, "Cas 2", "Opis Casa 7" },
                    { 8, 2, "Cas 3", "Opis Casa 8" },
                    { 9, 2, "Cas 4", "Opis Casa 9" },
                    { 10, 2, "Cas 5", "Opis Casa 10" },
                    { 11, 2, "Cas 6", "Opis Casa 11" },
                    { 12, 2, "Cas 7", "Opis Casa 12" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 2);

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
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 1,
                column: "StateMachine",
                value: null);

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 2,
                column: "StateMachine",
                value: null);

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
        }
    }
}
