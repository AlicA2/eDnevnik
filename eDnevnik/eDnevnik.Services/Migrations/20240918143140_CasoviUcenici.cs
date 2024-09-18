using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class CasoviUcenici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOdrzan",
                table: "Casovi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CasoviUcenici",
                columns: table => new
                {
                    CasoviUceniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasoviID = table.Column<int>(type: "int", nullable: false),
                    UcenikID = table.Column<int>(type: "int", nullable: false),
                    IsPrisutan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasoviUcenici", x => x.CasoviUceniciID);
                    table.ForeignKey(
                        name: "FK_CasoviUcenici_Casovi_CasoviID",
                        column: x => x.CasoviID,
                        principalTable: "Casovi",
                        principalColumn: "CasoviID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasoviUcenici_Korisnici_UcenikID",
                        column: x => x.UcenikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 18, 16, 31, 39, 709, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.CreateIndex(
                name: "IX_CasoviUcenici_CasoviID",
                table: "CasoviUcenici",
                column: "CasoviID");

            migrationBuilder.CreateIndex(
                name: "IX_CasoviUcenici_UcenikID",
                table: "CasoviUcenici",
                column: "UcenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasoviUcenici");

            migrationBuilder.DropColumn(
                name: "IsOdrzan",
                table: "Casovi");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 9, 13, 12, 13, 35, 910, DateTimeKind.Local).AddTicks(8389));
        }
    }
}
