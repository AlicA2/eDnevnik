using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class NewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 1,
                column: "ProfesorID",
                value: 69);

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 6,
                column: "ProfesorID",
                value: 69);

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "OdjeljenjeID", "Prezime", "Telefon" },
                values: new object[] { 69, "hamza.memic@gmail.com", "Hamza", "hamza", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", null, "Memić", "+38700000000" });

            migrationBuilder.UpdateData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 1,
                column: "RazrednikID",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 1,
                columns: new[] { "Naziv", "Opis" },
                values: new object[] { "profesor", "profesor" });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv", "Opis" },
                values: new object[] { 3, "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1567), 3 });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[] { 69, new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1905), 69, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 69);

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 1,
                column: "ProfesorID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GodisnjiPlanProgram",
                keyColumn: "GodisnjiPlanProgramID",
                keyValue: 6,
                column: "ProfesorID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 1,
                column: "RazrednikID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 1,
                columns: new[] { "Naziv", "Opis" },
                values: new object[] { "admin", "admin ili profesor" });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4195), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 28, 21, 55, 12, 20, DateTimeKind.Local).AddTicks(4519));
        }
    }
}
