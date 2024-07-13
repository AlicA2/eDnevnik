using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class newClasses01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GodisnjiPlanProgram",
                columns: table => new
                {
                    GodisnjiPlanProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojCasova = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdjeljenjeID = table.Column<int>(type: "int", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodisnjiPlanProgram", x => x.GodisnjiPlanProgramID);
                    table.ForeignKey(
                        name: "FK_GodisnjiPlanProgram_Odjeljenje_OdjeljenjeID",
                        column: x => x.OdjeljenjeID,
                        principalTable: "Odjeljenje",
                        principalColumn: "OdjeljenjeID");
                    table.ForeignKey(
                        name: "FK_GodisnjiPlanProgram_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetID");
                });

            migrationBuilder.CreateTable(
                name: "Casovi",
                columns: table => new
                {
                    CasoviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivCasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodisnjiPlanProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casovi", x => x.CasoviID);
                    table.ForeignKey(
                        name: "FK_Casovi_GodisnjiPlanProgram_GodisnjiPlanProgramID",
                        column: x => x.GodisnjiPlanProgramID,
                        principalTable: "GodisnjiPlanProgram",
                        principalColumn: "GodisnjiPlanProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 15, 3, 9, 14, DateTimeKind.Local).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 15, 3, 9, 14, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 3, 9, 14, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 3, 9, 14, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 3, 9, 14, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 15, 3, 9, 14, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_GodisnjiPlanProgramID",
                table: "Casovi",
                column: "GodisnjiPlanProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_GodisnjiPlanProgram_OdjeljenjeID",
                table: "GodisnjiPlanProgram",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_GodisnjiPlanProgram_PredmetID",
                table: "GodisnjiPlanProgram",
                column: "PredmetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "GodisnjiPlanProgram");

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "Ocjene",
                keyColumn: "OcjenaID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 7, 11, 11, 15, 57, 295, DateTimeKind.Local).AddTicks(8101));
        }
    }
}
