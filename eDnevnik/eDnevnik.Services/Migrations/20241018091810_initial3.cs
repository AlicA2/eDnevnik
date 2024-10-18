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
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amina", "Smajić" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Tarik", "Mehić" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                column: "Prezime",
                value: "Musić");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 6,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 7,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 8,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 9,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 10,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 11,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 12,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 13,
                column: "OdjeljenjeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 14,
                column: "OdjeljenjeID",
                value: null);

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
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 2,
                columns: new[] { "NazivOdjeljenja", "RazrednikID" },
                values: new object[] { "1B", 2 });

            migrationBuilder.UpdateData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 3,
                columns: new[] { "NazivOdjeljenja", "RazrednikID", "SkolaID" },
                values: new object[] { "1C", 3, 1 });

            migrationBuilder.InsertData(
                table: "Odjeljenje",
                columns: new[] { "OdjeljenjeID", "NazivOdjeljenja", "RazrednikID", "SkolaID" },
                values: new object[,]
                {
                    { 4, "2A", 4, 1 },
                    { 5, "2B", 5, 1 },
                    { 6, "3A", 6, 1 },
                    { 7, "4A", 7, 1 },
                    { 8, "1A", 8, 2 },
                    { 9, "1B", 9, 2 },
                    { 10, "1C", 10, 2 },
                    { 11, "2A", 11, 2 },
                    { 12, "2B", 12, 2 },
                    { 13, "3A", 13, 2 },
                    { 14, "4A", 14, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 1,
                column: "Opis",
                value: "admin ili profesor");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 2,
                column: "Opis",
                value: "učenik ili roditelj");

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
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4733), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4736), 1 });

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
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4745), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4747), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4750), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4753), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4755), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4758), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4761), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4764), 1 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 11, 18, 9, 899, DateTimeKind.Local).AddTicks(4766), 1 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "ucenik", "ucenik" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "roditelj", "roditelj" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                column: "Prezime",
                value: "Music");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 6,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 7,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 8,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 9,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 10,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 11,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 12,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 13,
                column: "OdjeljenjeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 14,
                column: "OdjeljenjeID",
                value: 2);

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
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 2,
                columns: new[] { "NazivOdjeljenja", "RazrednikID" },
                values: new object[] { "2A", 4 });

            migrationBuilder.UpdateData(
                table: "Odjeljenje",
                keyColumn: "OdjeljenjeID",
                keyValue: 3,
                columns: new[] { "NazivOdjeljenja", "RazrednikID", "SkolaID" },
                values: new object[] { "1A", 5, 2 });

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 1,
                column: "Opis",
                value: "admin/profesor");

            migrationBuilder.UpdateData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 2,
                column: "Opis",
                value: "učenik/roditelj");

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
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2432), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2434), 2 });

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
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2440), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2442), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2444), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2446), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2448), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2450), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2452), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2454), 2 });

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                columns: new[] { "DatumIzmjene", "UlogaID" },
                values: new object[] { new DateTime(2024, 10, 18, 10, 47, 29, 910, DateTimeKind.Local).AddTicks(2456), 2 });

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
    }
}
