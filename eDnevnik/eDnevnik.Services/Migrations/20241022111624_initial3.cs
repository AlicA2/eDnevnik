using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 16,
                column: "IsOdrzan",
                value: false);

            migrationBuilder.UpdateData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 17,
                column: "IsOdrzan",
                value: false);

            migrationBuilder.InsertData(
                table: "CasoviUcenici",
                columns: new[] { "CasoviUceniciID", "CasoviID", "IsPrisutan", "UcenikID", "zakljucan" },
                values: new object[,]
                {
                    { 1, 1, true, 15, true },
                    { 2, 1, true, 16, true },
                    { 3, 1, true, 17, true },
                    { 4, 1, true, 18, true },
                    { 5, 1, true, 19, true },
                    { 6, 1, true, 42, true },
                    { 7, 1, true, 43, true },
                    { 8, 1, true, 44, true },
                    { 9, 1, true, 45, true },
                    { 10, 1, true, 46, true },
                    { 11, 2, true, 15, true },
                    { 12, 2, true, 16, true },
                    { 13, 2, true, 17, true },
                    { 14, 2, true, 18, true },
                    { 15, 2, true, 19, true },
                    { 16, 2, true, 42, true },
                    { 17, 2, true, 43, true },
                    { 18, 2, true, 44, true },
                    { 19, 2, true, 45, true },
                    { 20, 2, true, 46, true },
                    { 21, 3, true, 15, true },
                    { 22, 3, true, 16, true },
                    { 23, 3, true, 17, true },
                    { 24, 3, true, 18, true },
                    { 25, 3, true, 19, true },
                    { 26, 3, true, 42, true },
                    { 27, 3, true, 43, true },
                    { 28, 3, true, 44, true },
                    { 29, 3, true, 45, true },
                    { 30, 3, true, 46, true },
                    { 31, 4, true, 15, true },
                    { 32, 4, true, 16, true },
                    { 33, 4, true, 17, true },
                    { 34, 4, true, 18, true },
                    { 35, 4, true, 19, true },
                    { 36, 4, true, 42, true },
                    { 37, 4, true, 43, true },
                    { 38, 4, true, 44, true },
                    { 39, 4, true, 45, true },
                    { 40, 4, true, 46, true }
                });

            migrationBuilder.InsertData(
                table: "CasoviUcenici",
                columns: new[] { "CasoviUceniciID", "CasoviID", "IsPrisutan", "UcenikID", "zakljucan" },
                values: new object[,]
                {
                    { 41, 5, true, 15, true },
                    { 42, 5, true, 16, true },
                    { 43, 5, true, 17, true },
                    { 44, 5, true, 18, true },
                    { 45, 5, true, 19, true },
                    { 46, 5, true, 42, true },
                    { 47, 5, true, 43, true },
                    { 48, 5, true, 44, true },
                    { 49, 5, true, 45, true },
                    { 50, 5, true, 46, true },
                    { 51, 6, true, 15, true },
                    { 52, 6, true, 16, true },
                    { 53, 6, true, 17, true },
                    { 54, 6, true, 18, true },
                    { 55, 6, true, 19, true },
                    { 56, 6, true, 42, true },
                    { 57, 6, true, 43, true },
                    { 58, 6, true, 44, true },
                    { 59, 6, true, 45, true },
                    { 60, 6, true, 46, true },
                    { 61, 7, true, 15, true },
                    { 62, 7, true, 16, true },
                    { 63, 7, true, 17, true },
                    { 64, 7, true, 18, true },
                    { 65, 7, true, 19, true },
                    { 66, 7, true, 42, true },
                    { 67, 7, true, 43, true },
                    { 68, 7, true, 44, true },
                    { 69, 7, true, 45, true },
                    { 70, 7, true, 46, true },
                    { 71, 8, true, 15, true },
                    { 72, 8, true, 16, true },
                    { 73, 8, true, 17, true },
                    { 74, 8, true, 18, true },
                    { 75, 8, true, 19, true },
                    { 76, 8, true, 42, true },
                    { 77, 8, true, 43, true },
                    { 78, 8, true, 44, true },
                    { 79, 8, true, 45, true },
                    { 80, 8, true, 46, true },
                    { 81, 9, true, 15, true },
                    { 82, 9, true, 16, true }
                });

            migrationBuilder.InsertData(
                table: "CasoviUcenici",
                columns: new[] { "CasoviUceniciID", "CasoviID", "IsPrisutan", "UcenikID", "zakljucan" },
                values: new object[,]
                {
                    { 83, 9, true, 17, true },
                    { 84, 9, true, 18, true },
                    { 85, 9, true, 19, true },
                    { 86, 9, true, 42, true },
                    { 87, 9, true, 43, true },
                    { 88, 9, true, 44, true },
                    { 89, 9, true, 45, true },
                    { 90, 9, true, 46, true },
                    { 91, 10, true, 15, true },
                    { 92, 10, true, 16, true },
                    { 93, 10, true, 17, true },
                    { 94, 10, true, 18, true },
                    { 95, 10, true, 19, true },
                    { 96, 10, true, 42, true },
                    { 97, 10, true, 43, true },
                    { 98, 10, true, 44, true },
                    { 99, 10, true, 45, true },
                    { 100, 10, true, 46, true },
                    { 101, 11, true, 15, true },
                    { 102, 11, true, 16, true },
                    { 103, 11, true, 17, true },
                    { 104, 11, true, 18, true },
                    { 105, 11, true, 19, true },
                    { 106, 11, true, 42, true },
                    { 107, 11, true, 43, true },
                    { 108, 11, true, 44, true },
                    { 109, 11, true, 45, true },
                    { 110, 11, true, 46, true },
                    { 111, 12, true, 15, true },
                    { 112, 12, true, 16, true },
                    { 113, 12, true, 17, true },
                    { 114, 12, true, 18, true },
                    { 115, 12, true, 19, true },
                    { 116, 12, true, 42, true },
                    { 117, 12, true, 43, true },
                    { 118, 12, true, 44, true },
                    { 119, 12, true, 45, true },
                    { 120, 12, true, 46, true },
                    { 121, 13, true, 15, true },
                    { 122, 13, true, 16, true },
                    { 123, 13, true, 17, true },
                    { 124, 13, true, 18, true }
                });

            migrationBuilder.InsertData(
                table: "CasoviUcenici",
                columns: new[] { "CasoviUceniciID", "CasoviID", "IsPrisutan", "UcenikID", "zakljucan" },
                values: new object[,]
                {
                    { 125, 13, true, 19, true },
                    { 126, 13, true, 42, true },
                    { 127, 13, true, 43, true },
                    { 128, 13, true, 44, true },
                    { 129, 13, true, 45, true },
                    { 130, 13, true, 46, true },
                    { 131, 14, true, 15, true },
                    { 132, 14, true, 16, true },
                    { 133, 14, true, 17, true },
                    { 134, 14, true, 18, true },
                    { 135, 14, true, 19, true },
                    { 136, 14, true, 42, true },
                    { 137, 14, true, 43, true },
                    { 138, 14, true, 44, true },
                    { 139, 14, true, 45, true },
                    { 140, 14, true, 46, true },
                    { 141, 15, true, 15, true },
                    { 142, 15, true, 16, true },
                    { 143, 15, true, 17, true },
                    { 144, 15, true, 18, true },
                    { 145, 15, true, 19, true },
                    { 146, 15, true, 42, true },
                    { 147, 15, true, 43, true },
                    { 148, 15, true, 44, true },
                    { 149, 15, true, 45, true },
                    { 150, 15, true, 46, true }
                });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 43,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 2, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 10, 7, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 10, 9, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 10, 14, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 6,
                column: "Datum",
                value: new DateTime(2024, 9, 30, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 7,
                column: "Datum",
                value: new DateTime(2024, 10, 2, 11, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 8,
                column: "Datum",
                value: new DateTime(2024, 10, 7, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 9,
                column: "Datum",
                value: new DateTime(2024, 10, 9, 11, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 10,
                column: "Datum",
                value: new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 11,
                column: "Datum",
                value: new DateTime(2024, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 12,
                column: "Datum",
                value: new DateTime(2024, 10, 3, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 13,
                column: "Datum",
                value: new DateTime(2024, 10, 8, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 14,
                column: "Datum",
                value: new DateTime(2024, 10, 10, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 15,
                column: "Datum",
                value: new DateTime(2024, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 16,
                column: "Datum",
                value: new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 13, 16, 22, 386, DateTimeKind.Local).AddTicks(3146));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 150);

            migrationBuilder.UpdateData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 16,
                column: "IsOdrzan",
                value: true);

            migrationBuilder.UpdateData(
                table: "Casovi",
                keyColumn: "CasoviID",
                keyValue: 17,
                column: "IsOdrzan",
                value: true);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 43,
                column: "OdjeljenjeID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 5,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 6,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 7,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 8,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 9,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 10,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 11,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 12,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 13,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 14,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 15,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 16,
                column: "Datum",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 22, 12, 7, 7, 774, DateTimeKind.Local).AddTicks(6790));
        }
    }
}
