using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skola",
                columns: table => new
                {
                    SkolaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skola", x => x.SkolaID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Predmeti",
                columns: table => new
                {
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkolaID = table.Column<int>(type: "int", nullable: false),
                    ZakljucnaOcjena = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmeti", x => x.PredmetID);
                    table.ForeignKey(
                        name: "FK_Predmeti_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "SkolaID",
                        onDelete: ReferentialAction.Restrict);
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
                });

            migrationBuilder.CreateTable(
                name: "GodisnjiPlanProgram",
                columns: table => new
                {
                    GodisnjiPlanProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojCasova = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdjeljenjeID = table.Column<int>(type: "int", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false),
                    SkolaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodisnjiPlanProgram", x => x.GodisnjiPlanProgramID);
                    table.ForeignKey(
                        name: "FK_GodisnjiPlanProgram_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GodisnjiPlanProgram_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "SkolaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    OdjeljenjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "korisniciUloges",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UlogaID = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisniciUloges", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "FK_korisniciUloges_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_korisniciUloges_Uloge_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijednostOcjene = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK_Ocjene_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ocjene_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odjeljenje",
                columns: table => new
                {
                    OdjeljenjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivOdjeljenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkolaID = table.Column<int>(type: "int", nullable: false),
                    RazrednikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeljenje", x => x.OdjeljenjeID);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Korisnici_RazrednikID",
                        column: x => x.RazrednikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID");
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "SkolaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    PorukaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorID = table.Column<int>(type: "int", nullable: false),
                    RoditeljID = table.Column<int>(type: "int", nullable: false),
                    UcenikID = table.Column<int>(type: "int", nullable: false),
                    SadrzajPoruke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumSlanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.PorukaID);
                    table.ForeignKey(
                        name: "FK_Poruke_Korisnici_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poruke_Korisnici_RoditeljID",
                        column: x => x.RoditeljID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poruke_Korisnici_UcenikID",
                        column: x => x.UcenikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdjeljenjePredmet",
                columns: table => new
                {
                    OdjeljenjePredmetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredmetID = table.Column<int>(type: "int", nullable: false),
                    OdjeljenjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdjeljenjePredmet", x => x.OdjeljenjePredmetID);
                    table.ForeignKey(
                        name: "FK_OdjeljenjePredmet_Odjeljenje_OdjeljenjeID",
                        column: x => x.OdjeljenjeID,
                        principalTable: "Odjeljenje",
                        principalColumn: "OdjeljenjeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdjeljenjePredmet_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "OdjeljenjeID", "Prezime", "StateMachine", "Status", "Telefon" },
                values: new object[,]
                {
                    { 1, "adminadmin@gmail.com", "admin", "admin", "JfJzsL3ngGWki+Dn67C+8WLy73I=", "7TUJfmgkkDvcY3PB/M4fhg==", null, "admin", null, null, "060000000" },
                    { 2, "ucenik@gmail.com", "ucenik", "ucenik", "", "", null, "ucenik", null, null, "+38700000000" },
                    { 3, "roditelj@gmail.com", "roditelj", "roditelj", "", "", null, "roditelj", null, null, "+38700000000" },
                    { 4, "denismusic@gmail.com", "Denis", "denis", "JfJzsL3ngGWki+Dn67C+8WLy73I=", "7TUJfmgkkDvcY3PB/M4fhg==", null, "Music", null, null, "060300400" }
                });

            migrationBuilder.InsertData(
                table: "Skola",
                columns: new[] { "SkolaID", "Adresa", "Drzava", "Grad", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sjeverni logor bb", "BiH", "Mostar", "Gimnazija" },
                    { 2, "Trg Ivana Krndelja bb", "BiH", "Mostar", "Srednja Tehnička Škola" }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "admin", "admin/profesor" },
                    { 2, "učenik", "učenik/roditelj" }
                });

            migrationBuilder.InsertData(
                table: "Odjeljenje",
                columns: new[] { "OdjeljenjeID", "NazivOdjeljenja", "RazrednikID", "SkolaID" },
                values: new object[,]
                {
                    { 1, "1A", 1, 1 },
                    { 2, "2A", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Predmeti",
                columns: new[] { "PredmetID", "Naziv", "Opis", "SkolaID", "StateMachine", "ZakljucnaOcjena" },
                values: new object[,]
                {
                    { 1, "Matematika", "Sabiranje, oduzimanje, množenje, dijeljenje", 1, "draft", null },
                    { 2, "Biologija", "Biljke", 2, "draft", null }
                });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8204), 1, 1 },
                    { 2, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8255), 2, 2 },
                    { 3, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8259), 3, 2 },
                    { 4, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8262), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { 1, "Plan 1", 1, 1, 1, 5 });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "OdjeljenjeID", "Prezime", "StateMachine", "Status", "Telefon" },
                values: new object[,]
                {
                    { 5, "student1@gmail.com", "Amar", "student1", "", "", 1, "Alić", null, null, "+38700000001" },
                    { 6, "student2@gmail.com", "Almir", "student2", "", "", 1, "Gogolo", null, null, "+38700000002" },
                    { 7, "student3@gmail.com", "Sefer", "student3", "", "", 1, "Seferović", null, null, "+38700000003" },
                    { 8, "student4@gmail.com", "Sinan", "student4", "", "", 1, "Ahmedovski", null, null, "+38700000004" },
                    { 9, "student5@gmail.com", "Iman", "student5", "", "", 1, "Gosto", null, null, "+38700000005" },
                    { 10, "student6@gmail.com", "Imad", "student6", "", "", 1, "Alić", null, null, "+38700000006" },
                    { 11, "student7@gmail.com", "Benaid", "student7", "", "", 1, "Ahmetović", null, null, "+38700000007" },
                    { 12, "student8@gmail.com", "Azer", "student8", "", "", 1, "Sultanović", null, null, "+38700000008" },
                    { 13, "student9@gmail.com", "Goran", "student9", "", "", 1, "Škondrić", null, null, "+38700000009" },
                    { 14, "student10@gmail.com", "Emina", "student10", "", "", 2, "Junuz", null, null, "+38700000010" },
                    { 15, "student11@gmail.com", "Amel", "student11", "", "", 2, "Musić", null, null, "+38700000011" },
                    { 16, "student12@gmail.com", "Dragi", "student12", "", "", 2, "Tiro", null, null, "+38700000012" },
                    { 17, "student13@gmail.com", "Adil", "student13", "", "", 2, "Joldić", null, null, "+38700000013" },
                    { 18, "student14@gmail.com", "Lejla", "student14", "", "", 2, "Jazvin", null, null, "+38700000014" },
                    { 19, "student15@gmail.com", "Elmir", "student15", "", "", 2, "Babović", null, null, "+38700000015" }
                });

            migrationBuilder.InsertData(
                table: "Ocjene",
                columns: new[] { "OcjenaID", "Datum", "KorisnikID", "PredmetID", "VrijednostOcjene" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8438), 2, 1, 5 },
                    { 2, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8444), 2, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "GodisnjiPlanProgramID", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 1, 1, "Cas 1", "Opis Casa 1" },
                    { 2, 1, "Cas 2", "Opis Casa 2" },
                    { 3, 1, "Cas 3", "Opis Casa 3" },
                    { 4, 1, "Cas 4", "Opis Casa 4" },
                    { 5, 1, "Cas 5", "Opis Casa 5" }
                });

            migrationBuilder.InsertData(
                table: "Odjeljenje",
                columns: new[] { "OdjeljenjeID", "NazivOdjeljenja", "RazrednikID", "SkolaID" },
                values: new object[] { 3, "1A", 5, 2 });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8266), 5, 1 },
                    { 6, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8269), 6, 2 },
                    { 7, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8273), 7, 2 },
                    { 8, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8324), 8, 2 },
                    { 9, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8328), 9, 2 },
                    { 10, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8332), 10, 2 },
                    { 11, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8335), 11, 2 },
                    { 12, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8339), 12, 2 },
                    { 13, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8342), 13, 2 },
                    { 14, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8346), 14, 2 },
                    { 15, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8349), 15, 2 },
                    { 16, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8353), 16, 2 },
                    { 17, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8356), 17, 2 },
                    { 18, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8360), 18, 2 },
                    { 19, new DateTime(2024, 8, 28, 13, 51, 23, 324, DateTimeKind.Local).AddTicks(8363), 19, 2 }
                });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[] { 2, "Plan 2", 3, 2, 2, 7 });

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "GodisnjiPlanProgramID", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 6, 2, "Cas 1", "Opis Casa 6" },
                    { 7, 2, "Cas 2", "Opis Casa 7" },
                    { 8, 2, "Cas 3", "Opis Casa 8" },
                    { 9, 2, "Cas 4", "Opis Casa 9" },
                    { 10, 2, "Cas 5", "Opis Casa 10" },
                    { 11, 2, "Cas 6", "Opis Casa 11" },
                    { 12, 2, "Cas 7", "Opis Casa 12" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GodisnjiPlanProgram_SkolaID",
                table: "GodisnjiPlanProgram",
                column: "SkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_OdjeljenjeID",
                table: "Korisnici",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_korisniciUloges_KorisnikID",
                table: "korisniciUloges",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_korisniciUloges_UlogaID",
                table: "korisniciUloges",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_KorisnikID",
                table: "Ocjene",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_PredmetID",
                table: "Ocjene",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_RazrednikID",
                table: "Odjeljenje",
                column: "RazrednikID",
                unique: true,
                filter: "[RazrednikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_SkolaID",
                table: "Odjeljenje",
                column: "SkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_OdjeljenjePredmet_OdjeljenjeID",
                table: "OdjeljenjePredmet",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_OdjeljenjePredmet_PredmetID",
                table: "OdjeljenjePredmet",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_ProfesorID",
                table: "Poruke",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_RoditeljID",
                table: "Poruke",
                column: "RoditeljID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_UcenikID",
                table: "Poruke",
                column: "UcenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_SkolaID",
                table: "Predmeti",
                column: "SkolaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Casovi_GodisnjiPlanProgram_GodisnjiPlanProgramID",
                table: "Casovi",
                column: "GodisnjiPlanProgramID",
                principalTable: "GodisnjiPlanProgram",
                principalColumn: "GodisnjiPlanProgramID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GodisnjiPlanProgram_Odjeljenje_OdjeljenjeID",
                table: "GodisnjiPlanProgram",
                column: "OdjeljenjeID",
                principalTable: "Odjeljenje",
                principalColumn: "OdjeljenjeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Odjeljenje_OdjeljenjeID",
                table: "Korisnici",
                column: "OdjeljenjeID",
                principalTable: "Odjeljenje",
                principalColumn: "OdjeljenjeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Odjeljenje_OdjeljenjeID",
                table: "Korisnici");

            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "korisniciUloges");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "OdjeljenjePredmet");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "GodisnjiPlanProgram");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Predmeti");

            migrationBuilder.DropTable(
                name: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Skola");
        }
    }
}
