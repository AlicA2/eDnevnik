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
                    OdjeljenjeID = 2,
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
                    Naziv = "Fakultet Informacijskih Tehnologija",
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
                    //ProfesorID = 1  
                },
                new Ocjene
                {
                    OcjenaID = 2,
                    VrijednostOcjene = 4,
                    Datum = DateTime.Now,
                    KorisnikID = 2,
                    PredmetID = 2,
                    //ProfesorID = 1
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
                    //OdjeljenjeID = 1,
                    SkolaID = 1,
                    StateMachine = "draft"
                },
                new Predmet
                {
                    PredmetID = 2,
                    Naziv = "Biologija",
                    Opis = "Biljke",
                    //OdjeljenjeID = 1,
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
                }
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
                }
            );
        }
    }
}
