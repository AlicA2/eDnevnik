using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class AddedDogadjaji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogadjaji",
                columns: table => new
                {
                    DogadjajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDogadjaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisDogadjaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DatumDogadjaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JeAktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaji", x => x.DogadjajId);
                });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 30, 31, 138, DateTimeKind.Local).AddTicks(7329));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogadjaji");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2146));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 19, 21, 28, 52, 511, DateTimeKind.Local).AddTicks(2170));
        }
    }
}
