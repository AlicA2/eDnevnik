using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class UpdateKomentar01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Komentar",
                value: "Odličan rezultat.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Komentar",
                value: "Vrlo dobar.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 3,
                column: "Komentar",
                value: "Zadovoljavajući rezultat.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 4,
                column: "Komentar",
                value: "Odličan uspjeh.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 5,
                column: "Komentar",
                value: "Vrlo dobar.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 6,
                column: "Komentar",
                value: "Solidan trud.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 7,
                column: "Komentar",
                value: "Potrebno više truda.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 8,
                column: "Komentar",
                value: "Odličan rezultat.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 9,
                column: "Komentar",
                value: "Vrlo dobar.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 10,
                column: "Komentar",
                value: "Zadovoljavajući.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 11,
                column: "Komentar",
                value: "Odličan rad.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 12,
                column: "Komentar",
                value: "Nedovoljno zalaganje.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 13,
                column: "Komentar",
                value: "Dobar uspjeh.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 14,
                column: "Komentar",
                value: "Zadovoljavajući rezultat.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 15,
                column: "Komentar",
                value: "Vrlo dobar.");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 16,
                column: "Komentar",
                value: "Izuzetan uspjeh.");

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5469));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 31, 43, 922, DateTimeKind.Local).AddTicks(5534));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 3,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 4,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 5,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 6,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 7,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 8,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 9,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 10,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 11,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 12,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 13,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 14,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 15,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 16,
                column: "Komentar",
                value: null);

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3361));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3465));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 27, 10, 18, 51, 949, DateTimeKind.Local).AddTicks(3497));
        }
    }
}
