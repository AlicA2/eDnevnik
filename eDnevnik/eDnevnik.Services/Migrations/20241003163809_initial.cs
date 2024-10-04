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
                name: "Dogadjaji",
                columns: table => new
                {
                    DogadjajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDogadjaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisDogadjaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DatumDogadjaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkolaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaji", x => x.DogadjajId);
                    table.ForeignKey(
                        name: "FK_Dogadjaji_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "SkolaID",
                        onDelete: ReferentialAction.Restrict);
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
                    GodisnjiPlanProgramID = table.Column<int>(type: "int", nullable: false),
                    DatumOdrzavanjaCasa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOdrzan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casovi", x => x.CasoviID);
                });

            migrationBuilder.CreateTable(
                name: "CasoviUcenici",
                columns: table => new
                {
                    CasoviUceniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasoviID = table.Column<int>(type: "int", nullable: false),
                    UcenikID = table.Column<int>(type: "int", nullable: false),
                    IsPrisutan = table.Column<bool>(type: "bit", nullable: false),
                    zakljucan = table.Column<bool>(type: "bit", nullable: false)
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
                    SkolaID = table.Column<int>(type: "int", nullable: false),
                    ProfesorID = table.Column<int>(type: "int", nullable: true)
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
                name: "KorisniciDogadjaji",
                columns: table => new
                {
                    KorisnikDogadjajID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    DogadjajId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciDogadjaji", x => x.KorisnikDogadjajID);
                    table.ForeignKey(
                        name: "FK_KorisniciDogadjaji_Dogadjaji_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaji",
                        principalColumn: "DogadjajId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisniciDogadjaji_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
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
                    UcenikID = table.Column<int>(type: "int", nullable: false),
                    SadrzajPoruke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 2, "ucenik@gmail.com", "ucenik", "ucenik", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", null, "ucenik", null, null, "+38700000000" },
                    { 3, "roditelj@gmail.com", "roditelj", "roditelj", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", null, "roditelj", null, null, "+38700000000" },
                    { 4, "denismusic@gmail.com", "Denis", "denis", "JfJzsL3ngGWki+Dn67C+8WLy73I=", "7TUJfmgkkDvcY3PB/M4fhg==", null, "Music", null, null, "060300400" }
                });

            migrationBuilder.InsertData(
                table: "Skola",
                columns: new[] { "SkolaID", "Adresa", "Drzava", "Grad", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sjeverni logor bb", "BiH", "Mostar", "Srednja Stručna Škola" },
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
                    { 2, "Biologija", "Biljke i životne procese", 2, "draft", null },
                    { 3, "Fizika", "Osnovne fizikalne pojave i zakoni", 1, "draft", null },
                    { 4, "Fizika", "Tehnička primjena fizikalnih zakona", 2, "draft", null },
                    { 5, "Hemija", "Osnovni hemijski spojevi i reakcije", 1, "draft", null },
                    { 6, "Hemija", "Hemijski procesi u tehnologiji", 2, "draft", null },
                    { 7, "Informatika", "Osnove programiranja i računarskih sistema", 1, "draft", null },
                    { 8, "Informatika", "Napredno programiranje i sistemi", 2, "draft", null },
                    { 9, "Engleski", "Osnove engleskog jezika i komunikacije", 1, "draft", null },
                    { 10, "Elektrotehnika", "Osnove elektrotehnike i elektronike", 2, "draft", null }
                });

            migrationBuilder.InsertData(
                table: "korisniciUloges",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3507), 1, 1 },
                    { 2, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3558), 2, 2 },
                    { 3, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3563), 3, 2 },
                    { 4, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3568), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "ProfesorID", "SkolaID", "brojCasova" },
                values: new object[,]
                {
                    { 1, "Matematika Plan - 1A", 1, 1, null, 1, 5 },
                    { 2, "Fizika Plan - 1A", 1, 3, null, 1, 5 },
                    { 3, "Hemija Plan - 1A", 1, 5, null, 1, 5 },
                    { 4, "Informatika Plan - 1A", 1, 7, null, 1, 5 },
                    { 5, "Engleski Plan - 1A", 1, 9, null, 1, 5 },
                    { 6, "Matematika Plan - 2A", 2, 1, null, 1, 5 },
                    { 7, "Fizika Plan - 2A", 2, 3, null, 1, 5 },
                    { 8, "Hemija Plan - 2A", 2, 5, null, 1, 5 },
                    { 9, "Informatika Plan - 2A", 2, 7, null, 1, 5 },
                    { 10, "Engleski Plan - 2A", 2, 9, null, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "OdjeljenjeID", "Prezime", "StateMachine", "Status", "Telefon" },
                values: new object[,]
                {
                    { 5, "student1@gmail.com", "Amar", "student1", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Alić", null, null, "+38700000001" },
                    { 6, "student2@gmail.com", "Almir", "student2", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Gogolo", null, null, "+38700000002" },
                    { 7, "student3@gmail.com", "Sefer", "student3", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Seferović", null, null, "+38700000003" },
                    { 8, "student4@gmail.com", "Sinan", "student4", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Ahmedovski", null, null, "+38700000004" },
                    { 9, "student5@gmail.com", "Iman", "student5", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Gosto", null, null, "+38700000005" },
                    { 10, "student6@gmail.com", "Imad", "student6", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Alić", null, null, "+38700000006" },
                    { 11, "student7@gmail.com", "Benaid", "student7", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Ahmetović", null, null, "+38700000007" },
                    { 12, "student8@gmail.com", "Azer", "student8", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Sultanović", null, null, "+38700000008" },
                    { 13, "student9@gmail.com", "Goran", "student9", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 1, "Škondrić", null, null, "+38700000009" },
                    { 14, "student10@gmail.com", "Emina", "student10", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Junuz", null, null, "+38700000010" },
                    { 15, "student11@gmail.com", "Amel", "student11", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Musić", null, null, "+38700000011" },
                    { 16, "student12@gmail.com", "Dragi", "student12", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Tiro", null, null, "+38700000012" },
                    { 17, "student13@gmail.com", "Adil", "student13", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Joldić", null, null, "+38700000013" },
                    { 18, "student14@gmail.com", "Lejla", "student14", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Jazvin", null, null, "+38700000014" },
                    { 19, "student15@gmail.com", "Elmir", "student15", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", 2, "Babović", null, null, "+38700000015" }
                });

            migrationBuilder.InsertData(
                table: "Ocjene",
                columns: new[] { "OcjenaID", "Datum", "KorisnikID", "PredmetID", "VrijednostOcjene" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3837), 2, 1, 5 },
                    { 2, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3845), 2, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "DatumOdrzavanjaCasa", "GodisnjiPlanProgramID", "IsOdrzan", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 1, null, 1, false, "Algebra", "Osnove algebre" },
                    { 2, null, 1, false, "Geometrija", "Osnove geometrije" },
                    { 3, null, 1, false, "Trigonometrija", "Osnove trigonometrije" },
                    { 4, null, 1, false, "Kalkulus", "Osnove kalkulusa" },
                    { 5, null, 1, false, "Statistika", "Osnove statistike" },
                    { 6, null, 2, false, "Mehanika", "Osnove mehanike" },
                    { 7, null, 2, false, "Termodinamika", "Osnove termodinamike" },
                    { 8, null, 2, false, "Optika", "Osnove optike" },
                    { 9, null, 2, false, "Elektricitet", "Osnove elektriciteta" },
                    { 10, null, 2, false, "Magnetizam", "Osnove magnetizma" },
                    { 11, null, 3, false, "Organska hemija", "Osnove organske hemije" },
                    { 12, null, 3, false, "Neorganska hemija", "Osnove neorganske hemije" },
                    { 13, null, 3, false, "Fizička hemija", "Osnove fizičke hemije" },
                    { 14, null, 3, false, "Analitička hemija", "Osnove analitičke hemije" },
                    { 15, null, 3, false, "Biohemija", "Osnove biohemije" },
                    { 16, null, 4, false, "Osnove programiranja", "Osnove programiranja" },
                    { 17, null, 4, false, "Strukture podataka", "Osnove struktura podataka" },
                    { 18, null, 4, false, "Algoritmi", "Osnove algoritama" },
                    { 19, null, 4, false, "Baze podataka", "Osnove baza podataka" },
                    { 20, null, 4, false, "Softverski inženjering", "Osnove softverskog inženjeringa" },
                    { 21, null, 5, false, "Gramatika", "Osnove engleske gramatike" },
                    { 22, null, 5, false, "Vokabular", "Osnove engleskog vokabulara" },
                    { 23, null, 5, false, "Razumijevanje pročitanog", "Razumijevanje pročitanog" },
                    { 24, null, 5, false, "Pisanje", "Pisanje na engleskom" },
                    { 25, null, 5, false, "Govorne vještine", "Govorne vještine na engleskom" },
                    { 26, null, 6, false, "Algebra", "Osnove algebre" },
                    { 27, null, 6, false, "Geometrija", "Osnove geometrije" },
                    { 28, null, 6, false, "Trigonometrija", "Osnove trigonometrije" },
                    { 29, null, 6, false, "Kalkulus", "Osnove kalkulusa" },
                    { 30, null, 6, false, "Statistika", "Osnove statistike" },
                    { 31, null, 7, false, "Mehanika", "Osnove mehanike" },
                    { 32, null, 7, false, "Termodinamika", "Osnove termodinamike" },
                    { 33, null, 7, false, "Optika", "Osnove optike" },
                    { 34, null, 7, false, "Elektricitet", "Osnove elektriciteta" },
                    { 35, null, 7, false, "Magnetizam", "Osnove magnetizma" },
                    { 36, null, 8, false, "Organska hemija", "Osnove organske hemije" },
                    { 37, null, 8, false, "Neorganska hemija", "Osnove neorganske hemije" },
                    { 38, null, 8, false, "Fizička hemija", "Osnove fizičke hemije" },
                    { 39, null, 8, false, "Analitička hemija", "Osnove analitičke hemije" },
                    { 40, null, 8, false, "Biohemija", "Osnove biohemije" },
                    { 41, null, 9, false, "Osnove programiranja", "Osnove programiranja" },
                    { 42, null, 9, false, "Strukture podataka", "Osnove struktura podataka" }
                });

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "DatumOdrzavanjaCasa", "GodisnjiPlanProgramID", "IsOdrzan", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 43, null, 9, false, "Algoritmi", "Osnove algoritama" },
                    { 44, null, 9, false, "Baze podataka", "Osnove baza podataka" },
                    { 45, null, 9, false, "Softverski inženjering", "Osnove softverskog inženjeringa" },
                    { 46, null, 10, false, "Gramatika", "Osnove engleske gramatike" },
                    { 47, null, 10, false, "Vokabular", "Osnove engleskog vokabulara" },
                    { 48, null, 10, false, "Razumijevanje pročitanog", "Razumijevanje pročitanog" },
                    { 49, null, 10, false, "Pisanje", "Pisanje na engleskom" },
                    { 50, null, 10, false, "Govorne vještine", "Govorne vještine na engleskom" }
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
                    { 5, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3573), 5, 1 },
                    { 6, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3578), 6, 2 },
                    { 7, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3583), 7, 2 },
                    { 8, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3587), 8, 2 },
                    { 9, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3592), 9, 2 },
                    { 10, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3597), 10, 2 },
                    { 11, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3601), 11, 2 },
                    { 12, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3606), 12, 2 },
                    { 13, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3611), 13, 2 },
                    { 14, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3615), 14, 2 },
                    { 15, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3619), 15, 2 },
                    { 16, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3624), 16, 2 },
                    { 17, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3628), 17, 2 },
                    { 18, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3632), 18, 2 },
                    { 19, new DateTime(2024, 10, 3, 18, 38, 9, 116, DateTimeKind.Local).AddTicks(3636), 19, 2 }
                });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "ProfesorID", "SkolaID", "brojCasova" },
                values: new object[,]
                {
                    { 11, "Biologija Plan - 1A", 3, 2, null, 2, 5 },
                    { 12, "Fizika Plan - 1A", 3, 4, null, 2, 5 },
                    { 13, "Hemija Plan - 1A", 3, 6, null, 2, 5 },
                    { 14, "Informatika Plan - 1A", 3, 8, null, 2, 5 },
                    { 15, "Elektrotehnika Plan - 1A", 3, 10, null, 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_GodisnjiPlanProgramID",
                table: "Casovi",
                column: "GodisnjiPlanProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_CasoviUcenici_CasoviID",
                table: "CasoviUcenici",
                column: "CasoviID");

            migrationBuilder.CreateIndex(
                name: "IX_CasoviUcenici_UcenikID",
                table: "CasoviUcenici",
                column: "UcenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaji_SkolaID",
                table: "Dogadjaji",
                column: "SkolaID");

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
                name: "IX_KorisniciDogadjaji_DogadjajId",
                table: "KorisniciDogadjaji",
                column: "DogadjajId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciDogadjaji_KorisnikID",
                table: "KorisniciDogadjaji",
                column: "KorisnikID");

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
                name: "FK_CasoviUcenici_Korisnici_UcenikID",
                table: "CasoviUcenici",
                column: "UcenikID",
                principalTable: "Korisnici",
                principalColumn: "KorisnikID",
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
                name: "FK_Odjeljenje_Korisnici_RazrednikID",
                table: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "CasoviUcenici");

            migrationBuilder.DropTable(
                name: "KorisniciDogadjaji");

            migrationBuilder.DropTable(
                name: "korisniciUloges");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "OdjeljenjePredmet");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "Dogadjaji");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "GodisnjiPlanProgram");

            migrationBuilder.DropTable(
                name: "Predmeti");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Skola");
        }
    }
}
