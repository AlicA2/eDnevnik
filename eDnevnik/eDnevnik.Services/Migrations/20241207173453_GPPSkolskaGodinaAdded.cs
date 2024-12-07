using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class GPPSkolskaGodinaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkolskaGodinaID",
                table: "GodisnjiPlanProgram",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 7, 18, 34, 51, 809, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.CreateIndex(
                name: "IX_GodisnjiPlanProgram_SkolskaGodinaID",
                table: "GodisnjiPlanProgram",
                column: "SkolskaGodinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_GodisnjiPlanProgram_SkolskaGodina_SkolskaGodinaID",
                table: "GodisnjiPlanProgram",
                column: "SkolskaGodinaID",
                principalTable: "SkolskaGodina",
                principalColumn: "SkolskaGodinaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GodisnjiPlanProgram_SkolskaGodina_SkolskaGodinaID",
                table: "GodisnjiPlanProgram");

            migrationBuilder.DropIndex(
                name: "IX_GodisnjiPlanProgram_SkolskaGodinaID",
                table: "GodisnjiPlanProgram");

            migrationBuilder.DropColumn(
                name: "SkolskaGodinaID",
                table: "GodisnjiPlanProgram");

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 4, 20, 28, 27, 638, DateTimeKind.Local).AddTicks(4193));
        }
    }
}
