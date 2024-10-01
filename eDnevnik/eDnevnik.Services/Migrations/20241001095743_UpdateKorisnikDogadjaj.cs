using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class UpdateKorisnikDogadjaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkolaID",
                table: "Dogadjaji",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KorisnikDogadjaj",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    DogadjajId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikDogadjaj", x => new { x.KorisnikID, x.DogadjajId });
                    table.ForeignKey(
                        name: "FK_KorisnikDogadjaj_Dogadjaji_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaji",
                        principalColumn: "DogadjajId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikDogadjaj_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 10, 1, 11, 57, 42, 310, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaji_SkolaID",
                table: "Dogadjaji",
                column: "SkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikDogadjaj_DogadjajId",
                table: "KorisnikDogadjaj",
                column: "DogadjajId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogadjaji_Skola_SkolaID",
                table: "Dogadjaji",
                column: "SkolaID",
                principalTable: "Skola",
                principalColumn: "SkolaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogadjaji_Skola_SkolaID",
                table: "Dogadjaji");

            migrationBuilder.DropTable(
                name: "KorisnikDogadjaj");

            migrationBuilder.DropIndex(
                name: "IX_Dogadjaji_SkolaID",
                table: "Dogadjaji");

            migrationBuilder.DropColumn(
                name: "SkolaID",
                table: "Dogadjaji");

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
    }
}
