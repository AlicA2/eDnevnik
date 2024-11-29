using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class UserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KorisnikDetalji",
                columns: table => new
                {
                    KorisnikDetaljiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    GodinaUpisa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GodinaStudija = table.Column<int>(type: "int", nullable: true),
                    ObnavljaGodinu = table.Column<bool>(type: "bit", nullable: true),
                    ProsjecnaOcjena = table.Column<double>(type: "float", nullable: true),
                    UpisanaSkolskaGodina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikDetalji", x => x.KorisnikDetaljiID);
                    table.ForeignKey(
                        name: "FK_KorisnikDetalji_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 15, 59, 43, 322, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikDetalji_KorisnikID",
                table: "KorisnikDetalji",
                column: "KorisnikID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikDetalji");

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
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1567));

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
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 11, 29, 0, 10, 40, 544, DateTimeKind.Local).AddTicks(1905));
        }
    }
}
