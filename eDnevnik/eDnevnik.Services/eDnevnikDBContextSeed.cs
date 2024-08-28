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
                    Naziv = "Plan 1",
                    OdjeljenjeID = 1,
                    PredmetID = 1,
                    SkolaID = 1,
                },
                new GodisnjiPlanProgram
                {
                    GodisnjiPlanProgramID = 2,
                    brojCasova = 7,
                    Naziv = "Plan 2",
                    OdjeljenjeID = 3,
                    PredmetID = 2,
                    SkolaID = 2
                }
            );
        }

        private void SeedCasovi(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casovi>().HasData(
                new Casovi
                {
                    CasoviID = 1,
                    NazivCasa = "Cas 1",
                    Opis = "Opis Casa 1",
                    GodisnjiPlanProgramID = 1
                },
                new Casovi
                {
                    CasoviID = 2,
                    NazivCasa = "Cas 2",
                    Opis = "Opis Casa 2",
                    GodisnjiPlanProgramID = 1
                },
                new Casovi
                {
                    CasoviID = 3,
                    NazivCasa = "Cas 3",
                    Opis = "Opis Casa 3",
                    GodisnjiPlanProgramID = 1
                },
                new Casovi
                {
                    CasoviID = 4,
                    NazivCasa = "Cas 4",
                    Opis = "Opis Casa 4",
                    GodisnjiPlanProgramID = 1
                },
                new Casovi
                {
                    CasoviID = 5,
                    NazivCasa = "Cas 5",
                    Opis = "Opis Casa 5",
                    GodisnjiPlanProgramID = 1
                },
                new Casovi
                {
                    CasoviID = 6,
                    NazivCasa = "Cas 1",
                    Opis = "Opis Casa 6",
                    GodisnjiPlanProgramID = 2
                },
                new Casovi
                {
                    CasoviID = 7,
                    NazivCasa = "Cas 2",
                    Opis = "Opis Casa 7",
                    GodisnjiPlanProgramID = 2
                },
                new Casovi
                {
                    CasoviID = 8,
                    NazivCasa = "Cas 3",
                    Opis = "Opis Casa 8",
                    GodisnjiPlanProgramID = 2
                },
                new Casovi
                {
                    CasoviID = 9,
                    NazivCasa = "Cas 4",
                    Opis = "Opis Casa 9",
                    GodisnjiPlanProgramID = 2
                },
                new Casovi
                {
                    CasoviID = 10,
                    NazivCasa = "Cas 5",
                    Opis = "Opis Casa 10",
                    GodisnjiPlanProgramID = 2
                },
                new Casovi
                {
                    CasoviID = 11,
                    NazivCasa = "Cas 6",
                    Opis = "Opis Casa 11",
                    GodisnjiPlanProgramID = 2
                },
                new Casovi
                {
                    CasoviID = 12,
                    NazivCasa = "Cas 7",
                    Opis = "Opis Casa 12",
                    GodisnjiPlanProgramID = 2
                }
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
                    PredmetID = 2,
                    Naziv = "Biologija",
                    Opis = "Biljke",
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
                    LozinkaHash = "",
                    LozinkaSalt = ""
                },
                new Korisnik
                {
                    KorisnikID = 3,
                    Ime = "roditelj",
                    Prezime = "roditelj",
                    Email = "roditelj@gmail.com",
                    Telefon = "+38700000000",
                    KorisnickoIme = "roditelj",
                    LozinkaHash = "",
                    LozinkaSalt = ""
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
                new Korisnik { KorisnikID = 5, Ime = "Amar", Prezime = "Alić", Email = "student1@gmail.com", Telefon = "+38700000001", KorisnickoIme = "student1", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 6, Ime = "Almir", Prezime = "Gogolo", Email = "student2@gmail.com", Telefon = "+38700000002", KorisnickoIme = "student2", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 7, Ime = "Sefer", Prezime = "Seferović", Email = "student3@gmail.com", Telefon = "+38700000003", KorisnickoIme = "student3", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 8, Ime = "Sinan", Prezime = "Ahmedovski", Email = "student4@gmail.com", Telefon = "+38700000004", KorisnickoIme = "student4", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 9, Ime = "Iman", Prezime = "Gosto", Email = "student5@gmail.com", Telefon = "+38700000005", KorisnickoIme = "student5", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 10, Ime = "Imad", Prezime = "Alić", Email = "student6@gmail.com", Telefon = "+38700000006", KorisnickoIme = "student6", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 11, Ime = "Benaid", Prezime = "Ahmetović", Email = "student7@gmail.com", Telefon = "+38700000007", KorisnickoIme = "student7", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 12, Ime = "Azer", Prezime = "Sultanović", Email = "student8@gmail.com", Telefon = "+38700000008", KorisnickoIme = "student8", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 13, Ime = "Goran", Prezime = "Škondrić", Email = "student9@gmail.com", Telefon = "+38700000009", KorisnickoIme = "student9", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 1 },
                new Korisnik { KorisnikID = 14, Ime = "Emina", Prezime = "Junuz", Email = "student10@gmail.com", Telefon = "+38700000010", KorisnickoIme = "student10", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 15, Ime = "Amel", Prezime = "Musić", Email = "student11@gmail.com", Telefon = "+38700000011", KorisnickoIme = "student11", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 16, Ime = "Dragi", Prezime = "Tiro", Email = "student12@gmail.com", Telefon = "+38700000012", KorisnickoIme = "student12", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 17, Ime = "Adil", Prezime = "Joldić", Email = "student13@gmail.com", Telefon = "+38700000013", KorisnickoIme = "student13", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 18, Ime = "Lejla", Prezime = "Jazvin", Email = "student14@gmail.com", Telefon = "+38700000014", KorisnickoIme = "student14", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 2 },
                new Korisnik { KorisnikID = 19, Ime = "Elmir", Prezime = "Babović", Email = "student15@gmail.com", Telefon = "+38700000015", KorisnickoIme = "student15", LozinkaHash = "", LozinkaSalt = "", OdjeljenjeID = 2 }
            );
        }
    }
}
