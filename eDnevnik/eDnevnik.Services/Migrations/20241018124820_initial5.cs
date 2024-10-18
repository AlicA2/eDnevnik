using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "amina.smajic@gmail.com", "amina" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                column: "Email",
                value: "tarik.mehic@gmail.com");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                column: "Email",
                value: "denis.music@gmail.com");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "amar.alic@gmail.com", "amar" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 6,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "almir.gogolo@gmail.com", "almir" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 7,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "sefer.seferovic@gmail.com", "sefer" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 8,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "sinan.ahmedovski@gmail.com", "sinan" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 9,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "iman.gosto@gmail.com", "iman" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 10,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "imad.alic@gmail.com", "imad" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 11,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "benaid.ahmetovic@gmail.com", "benaid" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 12,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "azer.sultanović@gmail.com", "azer" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 13,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "goran.skondric@gmail.com", "goran" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 14,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "emina.junuz@gmail.com", "emina" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 15,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student1@gmail.com", "student1", 1, "+38700000001" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 16,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student2@gmail.com", "student2", 1, "+38700000002" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 17,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student3@gmail.com", "student3", 1, "+38700000003" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 18,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student4@gmail.com", "student4", 1, "+38700000004" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 19,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student5@gmail.com", "student5", 1, "+38700000005" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "OdjeljenjeID", "Prezime", "StateMachine", "Status", "Telefon" },
                values: new object[,]
                {
                    { 20, "student6@gmail.com", "Sanja", "student6", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Kovač", null, null, "+38700000006" },
                    { 21, "student7@gmail.com", "Faruk", "student7", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Hasanović", null, null, "+38700000007" },
                    { 22, "student8@gmail.com", "Amra", "student8", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Smajović", null, null, "+38700000008" },
                    { 23, "student9@gmail.com", "Nina", "student9", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Hajrović", null, null, "+38700000009" },
                    { 24, "student10@gmail.com", "Denis", "student10", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Vuković", null, null, "+38700000010" },
                    { 25, "student11@gmail.com", "Emina", "student11", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Avdić", null, null, "+38700000011" },
                    { 26, "student12@gmail.com", "Anja", "student12", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Blagojević", null, null, "+38700000012" },
                    { 27, "student13@gmail.com", "Omer", "student13", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Fetić", null, null, "+38700000013" },
                    { 28, "student14@gmail.com", "Lana", "student14", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Hodžić", null, null, "+38700000014" },
                    { 29, "student15@gmail.com", "Tarik", "student15", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Krajišnik", null, null, "+38700000015" },
                    { 30, "student16@gmail.com", "Iva", "student16", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Milenić", null, null, "+38700000016" },
                    { 31, "student17@gmail.com", "Bojan", "student17", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Pavlović", null, null, "+38700000017" },
                    { 32, "student18@gmail.com", "Maja", "student18", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Savić", null, null, "+38700000018" },
                    { 33, "student19@gmail.com", "Alen", "student19", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Todorović", null, null, "+38700000019" },
                    { 34, "student20@gmail.com", "Dina", "student20", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Barić", null, null, "+38700000020" },
                    { 35, "student21@gmail.com", "Nedim", "student21", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Kalinović", null, null, "+38700000021" },
                    { 36, "student22@gmail.com", "Mina", "student22", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Milin", null, null, "+38700000022" },
                    { 37, "student23@gmail.com", "Semir", "student23", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Džafić", null, null, "+38700000023" },
                    { 38, "student24@gmail.com", "Tamara", "student24", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Nikolić", null, null, "+38700000024" },
                    { 39, "student25@gmail.com", "Zoran", "student25", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Cvjetković", null, null, "+38700000025" },
                    { 40, "student26@gmail.com", "Anja", "student26", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Lukić", null, null, "+38700000026" },
                    { 41, "student27@gmail.com", "Ramo", "student27", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Hukić", null, null, "+38700000027" },
                    { 42, "student28@gmail.com", "Maida", "student28", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Sulejmanović", null, null, "+38700000028" },
                    { 43, "student29@gmail.com", "Mirela", "student29", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Bajramović", null, null, "+38700000029" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "OdjeljenjeID", "Prezime", "StateMachine", "Status", "Telefon" },
                values: new object[,]
                {
                    { 44, "student30@gmail.com", "Filip", "student30", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 4, "Lukić", null, null, "+38700000030" },
                    { 45, "student31@gmail.com", "Mirza", "student31", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Redžović", null, null, "+38700000031" },
                    { 46, "student32@gmail.com", "Sara", "student32", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Bulić", null, null, "+38700000032" },
                    { 47, "student33@gmail.com", "Svetlana", "student33", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Trivić", null, null, "+38700000033" },
                    { 48, "student34@gmail.com", "Tarik", "student34", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Banjac", null, null, "+38700000034" },
                    { 49, "student35@gmail.com", "Jasmina", "student35", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Kovačević", null, null, "+38700000035" },
                    { 50, "student36@gmail.com", "Dino", "student36", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 3, "Hodžić", null, null, "+38700000036" }
                });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(42));

            migrationBuilder.InsertData(
                table: "Poruke",
                columns: new[] { "PorukaID", "DatumSlanja", "Odgovor", "ProfesorID", "SadrzajPoruke", "UcenikID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(625), null, 1, "Dobar dan, ovo je poruka.", 1 },
                    { 2, new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(630), null, 1, "Ne zaboravite na domaći zadatak.", 2 },
                    { 3, new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(633), null, 2, "Molim vas pregledajte materijale za lekciju.", 3 },
                    { 4, new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(636), null, 2, "Dobar posao na vašem posljednjem zadatku!", 4 },
                    { 5, new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(640), null, 3, "Hajde da zakažemo sastanak.", 5 },
                    { 6, new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(643), null, 3, "Obavezno se pripremite za predstojeći test.", 6 }
                });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 20, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8632), 20, 2 },
                    { 21, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8635), 21, 2 },
                    { 22, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8639), 22, 2 },
                    { 23, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8642), 23, 2 },
                    { 24, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8645), 24, 2 },
                    { 25, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8649), 25, 2 },
                    { 26, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8652), 26, 2 },
                    { 27, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8655), 27, 2 },
                    { 28, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8659), 28, 2 },
                    { 29, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8662), 29, 2 },
                    { 30, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8665), 30, 2 },
                    { 31, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8668), 31, 2 },
                    { 32, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8672), 32, 2 },
                    { 33, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8675), 33, 2 },
                    { 34, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8678), 34, 2 },
                    { 35, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8682), 35, 2 },
                    { 36, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8685), 36, 2 },
                    { 37, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8688), 37, 2 },
                    { 38, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8692), 38, 2 },
                    { 39, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8695), 39, 2 },
                    { 40, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8698), 40, 2 },
                    { 41, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8702), 41, 2 },
                    { 42, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8705), 42, 2 },
                    { 43, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8708), 43, 2 },
                    { 44, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8711), 44, 2 },
                    { 45, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8715), 45, 2 },
                    { 46, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8718), 46, 2 },
                    { 47, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8721), 47, 2 },
                    { 48, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8725), 48, 2 },
                    { 49, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8728), 49, 2 },
                    { 50, new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8731), 50, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "ucenik@gmail.com", "ucenik" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                column: "Email",
                value: "roditelj@gmail.com");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                column: "Email",
                value: "denismusic@gmail.com");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student1@gmail.com", "student1" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 6,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student2@gmail.com", "student2" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 7,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student3@gmail.com", "student3" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 8,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student4@gmail.com", "student4" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 9,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student5@gmail.com", "student5" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 10,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student6@gmail.com", "student6" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 11,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student7@gmail.com", "student7" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 12,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student8@gmail.com", "student8" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 13,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student9@gmail.com", "student9" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 14,
                columns: new[] { "Email", "KorisnickoIme" },
                values: new object[] { "student10@gmail.com", "student10" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 15,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student11@gmail.com", "student11", 2, "+38700000011" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 16,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student12@gmail.com", "student12", 2, "+38700000012" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 17,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student13@gmail.com", "student13", 2, "+38700000013" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 18,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student14@gmail.com", "student14", 2, "+38700000014" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 19,
                columns: new[] { "Email", "KorisnickoIme", "OdjeljenjeID", "Telefon" },
                values: new object[] { "student15@gmail.com", "student15", 2, "+38700000015" });

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
    }
}
