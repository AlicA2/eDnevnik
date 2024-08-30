using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace eDnevnik.Services
{
    public partial class eDnevnikDBContext
    {
        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedUloge(modelBuilder);
            SeedKorisnici(modelBuilder);
            SeedKorisniciUloge(modelBuilder);
            SeedPredmeti(modelBuilder);
            SeedOcjene(modelBuilder);
            SeedOdjeljenje(modelBuilder);
            SeedSkola(modelBuilder);
            SeedGodisnjiPlanProgram(modelBuilder);
            SeedCasovi(modelBuilder);
        }
        private void SeedGodisnjiPlanProgram(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GodisnjiPlanProgram>().HasData(
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 1,
                    brojCasova = 5,
                    Naziv = "Matematika Plan - 1A",
                    OdjeljenjeID = 1,
                    PredmetID = 1,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 2,
                    brojCasova = 5,
                    Naziv = "Fizika Plan - 1A",
                    OdjeljenjeID = 1,
                    PredmetID = 3,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 3,
                    brojCasova = 5,
                    Naziv = "Hemija Plan - 1A",
                    OdjeljenjeID = 1,
                    PredmetID = 5,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 4,
                    brojCasova = 5,
                    Naziv = "Informatika Plan - 1A",
                    OdjeljenjeID = 1,
                    PredmetID = 7,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 5,
                    brojCasova = 5,
                    Naziv = "Engleski Plan - 1A",
                    OdjeljenjeID = 1,
                    PredmetID = 9,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 6,
                    brojCasova = 5,
                    Naziv = "Matematika Plan - 2A",
                    OdjeljenjeID = 2,
                    PredmetID = 1,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 7,
                    brojCasova = 5,
                    Naziv = "Fizika Plan - 2A",
                    OdjeljenjeID = 2,
                    PredmetID = 3,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 8,
                    brojCasova = 5,
                    Naziv = "Hemija Plan - 2A",
                    OdjeljenjeID = 2,
                    PredmetID = 5,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 9,
                    brojCasova = 5,
                    Naziv = "Informatika Plan - 2A",
                    OdjeljenjeID = 2,
                    PredmetID = 7,
                    SkolaID = 1
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 10,
                    brojCasova = 5,
                    Naziv = "Engleski Plan - 2A",
                    OdjeljenjeID = 2,
                    PredmetID = 9,
                    SkolaID = 1
                },

                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 11,
                    brojCasova = 5,
                    Naziv = "Biologija Plan - 1A",
                    OdjeljenjeID = 3,
                    PredmetID = 2,
                    SkolaID = 2
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 12,
                    brojCasova = 5,
                    Naziv = "Fizika Plan - 1A",
                    OdjeljenjeID = 3,
                    PredmetID = 4,
                    SkolaID = 2
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 13,
                    brojCasova = 5,
                    Naziv = "Hemija Plan - 1A",
                    OdjeljenjeID = 3,
                    PredmetID = 6,
                    SkolaID = 2
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 14,
                    brojCasova = 5,
                    Naziv = "Informatika Plan - 1A",
                    OdjeljenjeID = 3,
                    PredmetID = 8,
                    SkolaID = 2
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 15,
                    brojCasova = 5,
                    Naziv = "Elektrotehnika Plan - 1A",
                    OdjeljenjeID = 3,
                    PredmetID = 10,
                    SkolaID = 2
                }
            );
        }
        private void SeedCasovi(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casovi>().HasData(
                new Casovi { CasoviID = 1, NazivCasa = "Algebra", Opis = "Osnove algebre", GodisnjiPlanProgramID = 1 },
                new Casovi { CasoviID = 2, NazivCasa = "Geometrija", Opis = "Osnove geometrije", GodisnjiPlanProgramID = 1 },
                new Casovi { CasoviID = 3, NazivCasa = "Trigonometrija", Opis = "Osnove trigonometrije", GodisnjiPlanProgramID = 1 },
                new Casovi { CasoviID = 4, NazivCasa = "Kalkulus", Opis = "Osnove kalkulusa", GodisnjiPlanProgramID = 1 },
                new Casovi { CasoviID = 5, NazivCasa = "Statistika", Opis = "Osnove statistike", GodisnjiPlanProgramID = 1 },

                new Casovi { CasoviID = 6, NazivCasa = "Mehanika", Opis = "Osnove mehanike", GodisnjiPlanProgramID = 2 },
                new Casovi { CasoviID = 7, NazivCasa = "Termodinamika", Opis = "Osnove termodinamike", GodisnjiPlanProgramID = 2 },
                new Casovi { CasoviID = 8, NazivCasa = "Optika", Opis = "Osnove optike", GodisnjiPlanProgramID = 2 },
                new Casovi { CasoviID = 9, NazivCasa = "Elektricitet", Opis = "Osnove elektriciteta", GodisnjiPlanProgramID = 2 },
                new Casovi { CasoviID = 10, NazivCasa = "Magnetizam", Opis = "Osnove magnetizma", GodisnjiPlanProgramID = 2 },

                new Casovi { CasoviID = 11, NazivCasa = "Organska hemija", Opis = "Osnove organske hemije", GodisnjiPlanProgramID = 3 },
                new Casovi { CasoviID = 12, NazivCasa = "Neorganska hemija", Opis = "Osnove neorganske hemije", GodisnjiPlanProgramID = 3 },
                new Casovi { CasoviID = 13, NazivCasa = "Fizička hemija", Opis = "Osnove fizičke hemije", GodisnjiPlanProgramID = 3 },
                new Casovi { CasoviID = 14, NazivCasa = "Analitička hemija", Opis = "Osnove analitičke hemije", GodisnjiPlanProgramID = 3 },
                new Casovi { CasoviID = 15, NazivCasa = "Biohemija", Opis = "Osnove biohemije", GodisnjiPlanProgramID = 3 },

                new Casovi { CasoviID = 16, NazivCasa = "Osnove programiranja", Opis = "Osnove programiranja", GodisnjiPlanProgramID = 4 },
                new Casovi { CasoviID = 17, NazivCasa = "Strukture podataka", Opis = "Osnove struktura podataka", GodisnjiPlanProgramID = 4 },
                new Casovi { CasoviID = 18, NazivCasa = "Algoritmi", Opis = "Osnove algoritama", GodisnjiPlanProgramID = 4 },
                new Casovi { CasoviID = 19, NazivCasa = "Baze podataka", Opis = "Osnove baza podataka", GodisnjiPlanProgramID = 4 },
                new Casovi { CasoviID = 20, NazivCasa = "Softverski inženjering", Opis = "Osnove softverskog inženjeringa", GodisnjiPlanProgramID = 4 },

                new Casovi { CasoviID = 21, NazivCasa = "Gramatika", Opis = "Osnove engleske gramatike", GodisnjiPlanProgramID = 5 },
                new Casovi { CasoviID = 22, NazivCasa = "Vokabular", Opis = "Osnove engleskog vokabulara", GodisnjiPlanProgramID = 5 },
                new Casovi { CasoviID = 23, NazivCasa = "Razumijevanje pročitanog", Opis = "Razumijevanje pročitanog", GodisnjiPlanProgramID = 5 },
                new Casovi { CasoviID = 24, NazivCasa = "Pisanje", Opis = "Pisanje na engleskom", GodisnjiPlanProgramID = 5 },
                new Casovi { CasoviID = 25, NazivCasa = "Govorne vještine", Opis = "Govorne vještine na engleskom", GodisnjiPlanProgramID = 5 },

                new Casovi { CasoviID = 26, NazivCasa = "Algebra", Opis = "Osnove algebre", GodisnjiPlanProgramID = 6 },
                new Casovi { CasoviID = 27, NazivCasa = "Geometrija", Opis = "Osnove geometrije", GodisnjiPlanProgramID = 6 },
                new Casovi { CasoviID = 28, NazivCasa = "Trigonometrija", Opis = "Osnove trigonometrije", GodisnjiPlanProgramID = 6 },
                new Casovi { CasoviID = 29, NazivCasa = "Kalkulus", Opis = "Osnove kalkulusa", GodisnjiPlanProgramID = 6 },
                new Casovi { CasoviID = 30, NazivCasa = "Statistika", Opis = "Osnove statistike", GodisnjiPlanProgramID = 6 },

                new Casovi { CasoviID = 31, NazivCasa = "Mehanika", Opis = "Osnove mehanike", GodisnjiPlanProgramID = 7 },
                new Casovi { CasoviID = 32, NazivCasa = "Termodinamika", Opis = "Osnove termodinamike", GodisnjiPlanProgramID = 7 },
                new Casovi { CasoviID = 33, NazivCasa = "Optika", Opis = "Osnove optike", GodisnjiPlanProgramID = 7 },
                new Casovi { CasoviID = 34, NazivCasa = "Elektricitet", Opis = "Osnove elektriciteta", GodisnjiPlanProgramID = 7 },
                new Casovi { CasoviID = 35, NazivCasa = "Magnetizam", Opis = "Osnove magnetizma", GodisnjiPlanProgramID = 7 },

                new Casovi { CasoviID = 36, NazivCasa = "Organska hemija", Opis = "Osnove organske hemije", GodisnjiPlanProgramID = 8 },
                new Casovi { CasoviID = 37, NazivCasa = "Neorganska hemija", Opis = "Osnove neorganske hemije", GodisnjiPlanProgramID = 8 },
                new Casovi { CasoviID = 38, NazivCasa = "Fizička hemija", Opis = "Osnove fizičke hemije", GodisnjiPlanProgramID = 8 },
                new Casovi { CasoviID = 39, NazivCasa = "Analitička hemija", Opis = "Osnove analitičke hemije", GodisnjiPlanProgramID = 8 },
                new Casovi { CasoviID = 40, NazivCasa = "Biohemija", Opis = "Osnove biohemije", GodisnjiPlanProgramID = 8 },

                new Casovi { CasoviID = 41, NazivCasa = "Osnove programiranja", Opis = "Osnove programiranja", GodisnjiPlanProgramID = 9 },
                new Casovi { CasoviID = 42, NazivCasa = "Strukture podataka", Opis = "Osnove struktura podataka", GodisnjiPlanProgramID = 9 },
                new Casovi { CasoviID = 43, NazivCasa = "Algoritmi", Opis = "Osnove algoritama", GodisnjiPlanProgramID = 9 },
                new Casovi { CasoviID = 44, NazivCasa = "Baze podataka", Opis = "Osnove baza podataka", GodisnjiPlanProgramID = 9 },
                new Casovi { CasoviID = 45, NazivCasa = "Softverski inženjering", Opis = "Osnove softverskog inženjeringa", GodisnjiPlanProgramID = 9 },

                new Casovi { CasoviID = 46, NazivCasa = "Gramatika", Opis = "Osnove engleske gramatike", GodisnjiPlanProgramID = 10 },
                new Casovi { CasoviID = 47, NazivCasa = "Vokabular", Opis = "Osnove engleskog vokabulara", GodisnjiPlanProgramID = 10 },
                new Casovi { CasoviID = 48, NazivCasa = "Razumijevanje pročitanog", Opis = "Razumijevanje pročitanog", GodisnjiPlanProgramID = 10 },
                new Casovi { CasoviID = 49, NazivCasa = "Pisanje", Opis = "Pisanje na engleskom", GodisnjiPlanProgramID = 10 },
                new Casovi { CasoviID = 50, NazivCasa = "Govorne vještine", Opis = "Govorne vještine na engleskom", GodisnjiPlanProgramID = 10 }
            );
        }

        private void SeedSkola(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skola>().HasData(
                new Skola
                {
                    SkolaID = 1,
                    Naziv = "Gimnazija",
                    Grad = "Mostar",
                    Drzava = "BiH",
                    Adresa = "Sjeverni logor bb",
                },
                new Skola
                {
                    SkolaID = 2,
                    Naziv = "Srednja Tehnička Škola",
                    Grad = "Mostar",
                    Drzava = "BiH",
                    Adresa = "Trg Ivana Krndelja bb",
                }
            );
        }

        private void SeedOcjene(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ocjene>().HasData(
                new Ocjene
                {
                    OcjenaID = 1,
                    VrijednostOcjene = 5,
                    Datum = DateTime.Now,
                    KorisnikID = 2,
                    PredmetID = 1,
                },
                new Ocjene
                {
                    OcjenaID = 2,
                    VrijednostOcjene = 4,
                    Datum = DateTime.Now,
                    KorisnikID = 2,
                    PredmetID = 2,
                }
            );
        }

        private void SeedPredmeti(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predmet>().HasData(
                new Predmet
                {
                    PredmetID = 1,
                    Naziv = "Matematika",
                    Opis = "Sabiranje, oduzimanje, množenje, dijeljenje",
                    SkolaID = 1,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 3,
                    Naziv = "Fizika",
                    Opis = "Osnovne fizikalne pojave i zakoni",
                    SkolaID = 1,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 5,
                    Naziv = "Hemija",
                    Opis = "Osnovni hemijski spojevi i reakcije",
                    SkolaID = 1,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 7,
                    Naziv = "Informatika",
                    Opis = "Osnove programiranja i računarskih sistema",
                    SkolaID = 1,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 9,
                    Naziv = "Engleski",
                    Opis = "Osnove engleskog jezika i komunikacije",
                    SkolaID = 1,
                    StateMachine = "draft"
                },

                new Predmet
                {
                    PredmetID = 2,
                    Naziv = "Biologija",
                    Opis = "Biljke i životne procese",
                    SkolaID = 2,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 4,
                    Naziv = "Fizika",
                    Opis = "Tehnička primjena fizikalnih zakona",
                    SkolaID = 2,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 6,
                    Naziv = "Hemija",
                    Opis = "Hemijski procesi u tehnologiji",
                    SkolaID = 2,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 8,
                    Naziv = "Informatika",
                    Opis = "Napredno programiranje i sistemi",
                    SkolaID = 2,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 10,
                    Naziv = "Elektrotehnika",
                    Opis = "Osnove elektrotehnike i elektronike",
                    SkolaID = 2,
                    StateMachine = "draft"
                }
            );
        }



        private void SeedOdjeljenje(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Odjeljenje>().HasData(
                new Odjeljenje
                {
                    OdjeljenjeID = 1,
                    NazivOdjeljenja = "1A",
                    SkolaID = 1,
                    RazrednikID=1
                },
                new Odjeljenje
                {
                    OdjeljenjeID = 2,
                    NazivOdjeljenja = "2A",
                    SkolaID = 1,
                    RazrednikID = 4
                },
                new Odjeljenje
                {
                    OdjeljenjeID = 3,
                    NazivOdjeljenja = "1A",
                    SkolaID = 2,
                    RazrednikID = 5
                }
            );
        }

        private void SeedKorisniciUloge(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KorisniciUloge>().HasData(
                new KorisniciUloge
                {
                    KorisnikUlogaID = 1,
                    KorisnikID = 1,
                    UlogaID = 1,
                    DatumIzmjene = DateTime.Now
                },
                new KorisniciUloge
                {
                    KorisnikUlogaID = 2,
                    KorisnikID = 2,
                    UlogaID = 2,
                    DatumIzmjene = DateTime.Now
                },
                new KorisniciUloge
                {
                    KorisnikUlogaID = 3,
                    KorisnikID = 3,
                    UlogaID = 2,
                    DatumIzmjene = DateTime.Now
                },
                new KorisniciUloge
                {
                    KorisnikUlogaID = 4,
                    KorisnikID = 4,
                    UlogaID = 1,
                    DatumIzmjene = DateTime.Now
                },
                new KorisniciUloge { KorisnikUlogaID = 5, KorisnikID = 5, UlogaID = 1, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 6, KorisnikID = 6, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 7, KorisnikID = 7, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 8, KorisnikID = 8, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 9, KorisnikID = 9, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 10, KorisnikID = 10, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 11, KorisnikID = 11, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 12, KorisnikID = 12, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 13, KorisnikID = 13, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 14, KorisnikID = 14, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 15, KorisnikID = 15, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 16, KorisnikID = 16, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 17, KorisnikID = 17, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 18, KorisnikID = 18, UlogaID = 2, DatumIzmjene = DateTime.Now },
                new KorisniciUloge { KorisnikUlogaID = 19, KorisnikID = 19, UlogaID = 2, DatumIzmjene = DateTime.Now }
            );
        }

        private void SeedUloge(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloge>().HasData(
                new Uloge
                {
                    UlogaID = 1,
                    Naziv = "admin",
                    Opis = "admin/profesor"
                },
                new Uloge
                {
                    UlogaID = 2,
                    Naziv = "učenik",
                    Opis = "učenik/roditelj"
                }
            );
        }

        private void SeedKorisnici(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().HasData(
                new Korisnik
                {
                    KorisnikID = 1,
                    Ime = "admin",
                    Prezime = "admin",
                    Email = "adminadmin@gmail.com",
                    Telefon = "060000000",
                    KorisnickoIme = "admin",
                    LozinkaHash = "JfJzsL3ngGWki+Dn67C+8WLy73I=",
                    LozinkaSalt = "7TUJfmgkkDvcY3PB/M4fhg==",
                },
                new Korisnik
                {
                    KorisnikID = 2,
                    Ime = "ucenik",
                    Prezime = "ucenik",
                    Email = "ucenik@gmail.com",
                    Telefon = "+38700000000",
                    KorisnickoIme = "ucenik",
                    LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=",
                    LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w=="
                },
                new Korisnik
                {
                    KorisnikID = 3,
                    Ime = "roditelj",
                    Prezime = "roditelj",
                    Email = "roditelj@gmail.com",
                    Telefon = "+38700000000",
                    KorisnickoIme = "roditelj",
                    LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=",
                    LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w=="
                },
                new Korisnik
                {
                    KorisnikID = 4,
                    Ime = "Denis",
                    Prezime = "Music",
                    Email = "denismusic@gmail.com",
                    Telefon = "060300400",
                    KorisnickoIme = "denis",
                    LozinkaHash = "JfJzsL3ngGWki+Dn67C+8WLy73I=",
                    LozinkaSalt = "7TUJfmgkkDvcY3PB/M4fhg=="
                },
                new Korisnik { KorisnikID = 5, Ime = "Amar", Prezime = "Alić", Email = "student1@gmail.com", Telefon = "+38700000001", KorisnickoIme = "student1", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 6, Ime = "Almir", Prezime = "Gogolo", Email = "student2@gmail.com", Telefon = "+38700000002", KorisnickoIme = "student2", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 7, Ime = "Sefer", Prezime = "Seferović", Email = "student3@gmail.com", Telefon = "+38700000003", KorisnickoIme = "student3", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 8, Ime = "Sinan", Prezime = "Ahmedovski", Email = "student4@gmail.com", Telefon = "+38700000004", KorisnickoIme = "student4", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 9, Ime = "Iman", Prezime = "Gosto", Email = "student5@gmail.com", Telefon = "+38700000005", KorisnickoIme = "student5", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 10, Ime = "Imad", Prezime = "Alić", Email = "student6@gmail.com", Telefon = "+38700000006", KorisnickoIme = "student6", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 11, Ime = "Benaid", Prezime = "Ahmetović", Email = "student7@gmail.com", Telefon = "+38700000007", KorisnickoIme = "student7", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 12, Ime = "Azer", Prezime = "Sultanović", Email = "student8@gmail.com", Telefon = "+38700000008", KorisnickoIme = "student8", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 13, Ime = "Goran", Prezime = "Škondrić", Email = "student9@gmail.com", Telefon = "+38700000009", KorisnickoIme = "student9", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 14, Ime = "Emina", Prezime = "Junuz", Email = "student10@gmail.com", Telefon = "+38700000010", KorisnickoIme = "student10", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 15, Ime = "Amel", Prezime = "Musić", Email = "student11@gmail.com", Telefon = "+38700000011", KorisnickoIme = "student11", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 16, Ime = "Dragi", Prezime = "Tiro", Email = "student12@gmail.com", Telefon = "+38700000012", KorisnickoIme = "student12", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 17, Ime = "Adil", Prezime = "Joldić", Email = "student13@gmail.com", Telefon = "+38700000013", KorisnickoIme = "student13", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 18, Ime = "Lejla", Prezime = "Jazvin", Email = "student14@gmail.com", Telefon = "+38700000014", KorisnickoIme = "student14", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 19, Ime = "Elmir", Prezime = "Babović", Email = "student15@gmail.com", Telefon = "+38700000015", KorisnickoIme = "student15", LozinkaHash = "Tyitt2sn+I+DQuydy0SzIv8Olio=", LozinkaSalt = "iM34ef0JCEUAzA7lkWld9w==", OdjeljenjeID = 2 }
            );
        }
    }
}
