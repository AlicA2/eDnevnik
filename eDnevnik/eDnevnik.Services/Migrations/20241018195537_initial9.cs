using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "DogadjajId",
                keyValue: 3,
                column: "NazivDogadjaja",
                value: "Proslava završene godine");

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "DogadjajId",
                keyValue: 4,
                column: "NazivDogadjaja",
                value: "Predavanje o sigurnosti");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 55, 35, 406, DateTimeKind.Local).AddTicks(4423));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "DogadjajId",
                keyValue: 3,
                column: "NazivDogadjaja",
                value: "Zabava povodom kraja školske godine");

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "DogadjajId",
                keyValue: 4,
                column: "NazivDogadjaja",
                value: "Predavanje o sigurnosti na internetu");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(6945));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 18, 21, 22, 4, 974, DateTimeKind.Local).AddTicks(7117));
        }
    }
}
