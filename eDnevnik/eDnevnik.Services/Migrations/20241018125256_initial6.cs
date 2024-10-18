using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                columns: new[] { "DatumSlanja", "Odgovor", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7799), "Dobar dan, ovo je odgovor", 15 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                columns: new[] { "DatumSlanja", "Odgovor", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7804), "Uredu", 16 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7807), 1, 17 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7811), 1, 18 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7814), 1, 19 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7817), 1, 20 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 52, 55, 504, DateTimeKind.Local).AddTicks(7240));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                columns: new[] { "DatumSlanja", "Odgovor", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(625), null, 1 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                columns: new[] { "DatumSlanja", "Odgovor", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(630), null, 2 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(633), 2, 3 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(636), 2, 4 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(640), 3, 5 });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                columns: new[] { "DatumSlanja", "ProfesorID", "UcenikID" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 48, 19, 67, DateTimeKind.Local).AddTicks(643), 3, 6 });

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

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 14, 48, 19, 66, DateTimeKind.Local).AddTicks(8731));
        }
    }
}
