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
