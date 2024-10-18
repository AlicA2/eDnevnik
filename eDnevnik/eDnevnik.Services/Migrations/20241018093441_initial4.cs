using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 1,
                column: "Naziv",
                value: "Plan i program za Matematiku I");

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 2,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Plan i program za Fiziku I", 6 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 3,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Plan i program za Hemiju I", 7 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 4,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Plan i program za Informatiku I", 8 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 5,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Plan i program za Engleski I", 9 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 6,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID" },
                values: new object[] { "Plan i program za Matematiku II", 4, 11 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 7,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Plan i program za Fiziku II", 4, 12, 6 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 8,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Plan i program za Hemiju II", 4, 13, 7 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 9,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Plan i program za Informatiku II", 4, 14, 8 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 10,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Plan i program za Engleski II", 4, 15, 9 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 11,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID" },
                values: new object[] { "Plan i program za Matematiku III", 6, 16, 1 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 12,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Plan i program za Fiziku III", 6, 17, 1, 6 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 13,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Plan i program za Hemiju III", 6, 18, 1, 7 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 14,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Plan i program za Informatiku III", 6, 19, 1, 8 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 15,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Plan i program za Engleski III", 6, 20, 1, 9 });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "ProfesorID", "SkolaID", "brojCasova" },
                values: new object[,]
                {
                    { 16, "Plan i program za Matematiku IV", 7, 21, null, 1, 5 },
                    { 17, "Plan i program za Fiziku IV", 7, 22, null, 1, 6 },
                    { 18, "Plan i program za Hemiju IV", 7, 23, null, 1, 7 },
                    { 19, "Plan i program za Informatiku IV", 7, 24, null, 1, 8 },
                    { 20, "Plan i program za Engleski IV", 7, 25, null, 1, 9 },
                    { 21, "Plan i program za Biologiju I", 8, 2, null, 2, 5 },
                    { 22, "Plan i program za Fiziku I", 8, 4, null, 2, 6 },
                    { 23, "Plan i program za Hemiju I", 8, 6, null, 2, 7 },
                    { 24, "Plan i program za Informatiku I", 8, 8, null, 2, 8 },
                    { 25, "Plan i program za Elektrotehniku I", 8, 10, null, 2, 9 },
                    { 26, "Plan i program za Biologiju II", 11, 26, null, 2, 5 },
                    { 27, "Plan i program za Fiziku II", 11, 27, null, 2, 6 },
                    { 28, "Plan i program za Hemiju II", 11, 28, null, 2, 7 },
                    { 29, "Plan i program za Informatiku II", 11, 29, null, 2, 8 },
                    { 30, "Plan i program za Elektrotehniku II", 11, 30, null, 2, 9 },
                    { 31, "Plan i program za Biologiju III", 13, 31, null, 2, 5 },
                    { 32, "Plan i program za Fiziku III", 13, 32, null, 2, 6 },
                    { 33, "Plan i program za Hemiju III", 13, 33, null, 2, 7 },
                    { 34, "Plan i program za Informatiku III", 13, 34, null, 2, 8 },
                    { 35, "Plan i program za Elektrotehniku III", 13, 35, null, 2, 9 },
                    { 36, "Plan i program za Biologiju IV", 14, 36, null, 2, 5 },
                    { 37, "Plan i program za Fiziku IV", 14, 37, null, 2, 6 },
                    { 38, "Plan i program za Hemiju IV", 14, 38, null, 2, 7 },
                    { 39, "Plan i program za Informatiku IV", 14, 39, null, 2, 8 },
                    { 40, "Plan i program za Elektrotehniku IV", 14, 40, null, 2, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 34, 40, 525, DateTimeKind.Local).AddTicks(4725));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 1,
                column: "Naziv",
                value: "Matematika Plan - 1A");

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 2,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Fizika Plan - 1A", 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 3,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Hemija Plan - 1A", 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 4,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Informatika Plan - 1A", 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 5,
                columns: new[] { "Naziv", "brojCasova" },
                values: new object[] { "Engleski Plan - 1A", 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 6,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID" },
                values: new object[] { "Matematika Plan - 2A", 2, 1 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 7,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Fizika Plan - 2A", 2, 3, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 8,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Hemija Plan - 2A", 2, 5, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 9,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Informatika Plan - 2A", 2, 7, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 10,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "brojCasova" },
                values: new object[] { "Engleski Plan - 2A", 2, 9, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 11,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID" },
                values: new object[] { "Biologija Plan - 1A", 3, 2, 2 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 12,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Fizika Plan - 1A", 3, 4, 2, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 13,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Hemija Plan - 1A", 3, 6, 2, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 14,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Informatika Plan - 1A", 3, 8, 2, 5 });

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 15,
                columns: new[] { "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { "Elektrotehnika Plan - 1A", 3, 10, 2, 5 });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4780));
        }
    }
}
