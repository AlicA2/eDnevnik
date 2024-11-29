using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class UserDetailsNullableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 17, 40, 21, 442, DateTimeKind.Local).AddTicks(1982));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 16, 30, 33, 969, DateTimeKind.Local).AddTicks(2012));
        }
    }
}
