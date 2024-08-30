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
                    { 2, "ucenik@gmail.com", "ucenik", "ucenik", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", null, "ucenik", null, null, "+38700000000" },
                    { 3, "roditelj@gmail.com", "roditelj", "roditelj", "Tyitt2sn+I+DQuydy0SzIv8Olio=", "iM34ef0JCEUAzA7lkWld9w==", null, "roditelj", null, null, "+38700000000" },
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
                    { 1, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3045), 1, 1 },
                    { 2, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3087), 2, 2 },
                    { 3, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3091), 3, 2 },
                    { 4, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3094), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[,]
                {
                    { 1, "Matematika Plan - 1A", 1, 1, 1, 5 },
                    { 2, "Fizika Plan - 1A", 1, 3, 1, 5 },
                    { 3, "Hemija Plan - 1A", 1, 5, 1, 5 },
                    { 4, "Informatika Plan - 1A", 1, 7, 1, 5 },
                    { 5, "Engleski Plan - 1A", 1, 9, 1, 5 },
                    { 6, "Matematika Plan - 2A", 2, 1, 1, 5 },
                    { 7, "Fizika Plan - 2A", 2, 3, 1, 5 },
                    { 8, "Hemija Plan - 2A", 2, 5, 1, 5 },
                    { 9, "Informatika Plan - 2A", 2, 7, 1, 5 },
                    { 10, "Engleski Plan - 2A", 2, 9, 1, 5 }
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
                    { 1, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3283), 2, 1, 5 },
                    { 2, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3289), 2, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "GodisnjiPlanProgramID", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 1, 1, "Algebra", "Osnove algebre" },
                    { 2, 1, "Geometrija", "Osnove geometrije" },
                    { 3, 1, "Trigonometrija", "Osnove trigonometrije" },
                    { 4, 1, "Kalkulus", "Osnove kalkulusa" },
                    { 5, 1, "Statistika", "Osnove statistike" },
                    { 6, 2, "Mehanika", "Osnove mehanike" },
                    { 7, 2, "Termodinamika", "Osnove termodinamike" },
                    { 8, 2, "Optika", "Osnove optike" },
                    { 9, 2, "Elektricitet", "Osnove elektriciteta" },
                    { 10, 2, "Magnetizam", "Osnove magnetizma" },
                    { 11, 3, "Organska hemija", "Osnove organske hemije" },
                    { 12, 3, "Neorganska hemija", "Osnove neorganske hemije" },
                    { 13, 3, "Fizička hemija", "Osnove fizičke hemije" },
                    { 14, 3, "Analitička hemija", "Osnove analitičke hemije" },
                    { 15, 3, "Biohemija", "Osnove biohemije" },
                    { 16, 4, "Osnove programiranja", "Osnove programiranja" },
                    { 17, 4, "Strukture podataka", "Osnove struktura podataka" },
                    { 18, 4, "Algoritmi", "Osnove algoritama" },
                    { 19, 4, "Baze podataka", "Osnove baza podataka" },
                    { 20, 4, "Softverski inženjering", "Osnove softverskog inženjeringa" },
                    { 21, 5, "Gramatika", "Osnove engleske gramatike" },
                    { 22, 5, "Vokabular", "Osnove engleskog vokabulara" },
                    { 23, 5, "Razumijevanje pročitanog", "Razumijevanje pročitanog" },
                    { 24, 5, "Pisanje", "Pisanje na engleskom" },
                    { 25, 5, "Govorne vještine", "Govorne vještine na engleskom" },
                    { 26, 6, "Algebra", "Osnove algebre" },
                    { 27, 6, "Geometrija", "Osnove geometrije" },
                    { 28, 6, "Trigonometrija", "Osnove trigonometrije" },
                    { 29, 6, "Kalkulus", "Osnove kalkulusa" },
                    { 30, 6, "Statistika", "Osnove statistike" },
                    { 31, 7, "Mehanika", "Osnove mehanike" },
                    { 32, 7, "Termodinamika", "Osnove termodinamike" },
                    { 33, 7, "Optika", "Osnove optike" },
                    { 34, 7, "Elektricitet", "Osnove elektriciteta" },
                    { 35, 7, "Magnetizam", "Osnove magnetizma" },
                    { 36, 8, "Organska hemija", "Osnove organske hemije" },
                    { 37, 8, "Neorganska hemija", "Osnove neorganske hemije" },
                    { 38, 8, "Fizička hemija", "Osnove fizičke hemije" },
                    { 39, 8, "Analitička hemija", "Osnove analitičke hemije" },
                    { 40, 8, "Biohemija", "Osnove biohemije" },
                    { 41, 9, "Osnove programiranja", "Osnove programiranja" },
                    { 42, 9, "Strukture podataka", "Osnove struktura podataka" }
                });

            migrationBuilder.InsertData(
                table: "Casovi",
                columns: new[] { "CasoviID", "GodisnjiPlanProgramID", "NazivCasa", "Opis" },
                values: new object[,]
                {
                    { 43, 9, "Algoritmi", "Osnove algoritama" },
                    { 44, 9, "Baze podataka", "Osnove baza podataka" },
                    { 45, 9, "Softverski inženjering", "Osnove softverskog inženjeringa" },
                    { 46, 10, "Gramatika", "Osnove engleske gramatike" },
                    { 47, 10, "Vokabular", "Osnove engleskog vokabulara" },
                    { 48, 10, "Razumijevanje pročitanog", "Razumijevanje pročitanog" },
                    { 49, 10, "Pisanje", "Pisanje na engleskom" },
                    { 50, 10, "Govorne vještine", "Govorne vještine na engleskom" }
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
                    { 5, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3098), 5, 1 },
                    { 6, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3101), 6, 2 },
                    { 7, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3104), 7, 2 },
                    { 8, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3108), 8, 2 },
                    { 9, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3111), 9, 2 },
                    { 10, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3115), 10, 2 },
                    { 11, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3118), 11, 2 },
                    { 12, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3122), 12, 2 },
                    { 13, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3125), 13, 2 },
                    { 14, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3128), 14, 2 },
                    { 15, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3132), 15, 2 },
                    { 16, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3135), 16, 2 },
                    { 17, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3139), 17, 2 },
                    { 18, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3142), 18, 2 },
                    { 19, new DateTime(2024, 8, 30, 17, 6, 54, 745, DateTimeKind.Local).AddTicks(3145), 19, 2 }
                });

            migrationBuilder.InsertData(
                table: "GodisnjiPlanProgram",
                columns: new[] { "GodisnjiPlanProgramID", "Naziv", "OdjeljenjeID", "PredmetID", "SkolaID", "brojCasova" },
                values: new object[,]
                {
                    { 11, "Biologija Plan - 1A", 3, 2, 2, 5 },
                    { 12, "Fizika Plan - 1A", 3, 4, 2, 5 },
                    { 13, "Hemija Plan - 1A", 3, 6, 2, 5 },
                    { 14, "Informatika Plan - 1A", 3, 8, 2, 5 },
                    { 15, "Elektrotehnika Plan - 1A", 3, 10, 2, 5 }
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
