using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 1,
                columns: new[] { "Naziv", "Opis", "StateMachine" },
                values: new object[] { "Matematika I", "Sabiranje, oduzimanje, množenje i dijeljenje", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 2,
                columns: new[] { "Naziv", "Opis", "StateMachine" },
                values: new object[] { "Biologija I", "Biljke i životni procesi", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 3,
                columns: new[] { "Naziv", "Opis", "StateMachine" },
                values: new object[] { "Fizika I", "Osnovne fizike i zakoni", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 4,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Fizika I", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 5,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Hemija I", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 6,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Hemija I", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 7,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Informatika I", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 8,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Informatika I", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 9,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Engleski I", "active" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 10,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Elektrotehnika I", "active" });

            migrationBuilder.InsertData(
                table: "Predmeti",
                columns: new[] { "PredmetID", "Naziv", "Opis", "SkolaID", "StateMachine", "ZakljucnaOcjena" },
                values: new object[,]
                {
                    { 11, "Matematika II", "Linearne funkcije i sistemi jednadžbi", 1, "active", null },
                    { 12, "Fizika II", "Kinetika i termodinamika", 1, "active", null },
                    { 13, "Hemija II", "Napredne hemijske reakcije i spojevi", 1, "active", null },
                    { 14, "Informatika II", "Algoritmi i strukture podataka", 1, "active", null },
                    { 15, "Engleski II", "Napredno pisanje i komunikacija", 1, "active", null },
                    { 16, "Matematika III", "Integrali i diferencijali", 1, "active", null },
                    { 17, "Fizika III", "Elektromagnetizam", 1, "active", null },
                    { 18, "Hemija III", "Organska hemija", 1, "active", null },
                    { 19, "Informatika III", "Objektno orijentisano programiranje", 1, "active", null },
                    { 20, "Engleski III", "Tehnički engleski jezik", 1, "active", null },
                    { 21, "Matematika IV", "Napredni matematički modeli", 1, "active", null },
                    { 22, "Fizika IV", "Kvantna mehanika", 1, "active", null },
                    { 23, "Hemija IV", "Analitička hemija", 1, "active", null },
                    { 24, "Informatika IV", "Umjetna inteligencija", 1, "active", null },
                    { 25, "Engleski IV", "Poslovna komunikacija", 1, "active", null },
                    { 26, "Biologija II", "Životni ciklusi i evolucija", 2, "active", null },
                    { 27, "Fizika II", "Termodinamika i optika", 2, "active", null },
                    { 28, "Hemija II", "Napredni hemijski spojevi", 2, "active", null },
                    { 29, "Informatika II", "Programski jezici i paradigme", 2, "active", null },
                    { 30, "Elektrotehnika II", "Elektronski uređaji", 2, "active", null },
                    { 31, "Biologija III", "Genetika i molekularna biologija", 2, "active", null },
                    { 32, "Fizika III", "Elektromagnetizam i optika", 2, "active", null },
                    { 33, "Hemija III", "Organska hemija", 2, "active", null },
                    { 34, "Informatika III", "Računarske mreže i sigurnost", 2, "active", null },
                    { 35, "Elektrotehnika III", "Digitalna elektronika", 2, "active", null },
                    { 36, "Biologija IV", "Ekologija i biotehnologija", 2, "active", null },
                    { 37, "Fizika IV", "Kvantna mehanika i moderna fizika", 2, "active", null },
                    { 38, "Hemija IV", "Analitička i industrijska hemija", 2, "active", null },
                    { 39, "Informatika IV", "Umjetna inteligencija i mašinsko učenje", 2, "active", null },
                    { 40, "Elektrotehnika IV", "Mikrokontroleri i automatski sistemi", 2, "active", null }
                });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2466));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 1,
                columns: new[] { "Naziv", "Opis", "StateMachine" },
                values: new object[] { "Matematika", "Sabiranje, oduzimanje, množenje, dijeljenje", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 2,
                columns: new[] { "Naziv", "Opis", "StateMachine" },
                values: new object[] { "Biologija", "Biljke i životne procese", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 3,
                columns: new[] { "Naziv", "Opis", "StateMachine" },
                values: new object[] { "Fizika", "Osnovne fizikalne pojave i zakoni", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 4,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Fizika", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 5,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Hemija", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 6,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Hemija", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 7,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Informatika", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 8,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Informatika", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 9,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Engleski", "draft" });

            migrationBuilder.UpdateData(
                table: "Predmeti",
                keyColumn: "PredmetID",
                keyValue: 10,
                columns: new[] { "Naziv", "StateMachine" },
                values: new object[] { "Elektrotehnika", "draft" });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 10, 22, 31, 135, DateTimeKind.Local).AddTicks(5238));
        }
    }
}
