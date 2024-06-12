using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    KorisnikUlogaID=1,
                    KorisnikID=1,
                    UlogaID=1,
                    DatumIzmjene=DateTime.Now
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
                    UlogaID = 3,
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
                    Naziv="admin",
                    Opis="admin ili profesor"
                },
                 new Uloge
                 {
                     UlogaID = 2,
                     Naziv = "učenik",
                     Opis = "učenik/ca"
                 }, 
                 new Uloge
                 {
                     UlogaID = 3,
                     Naziv = "roditelj",
                     Opis = "roditelj"
                 }
                );
        }

        private void SeedKorisnici(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().HasData(
                new Korisnik
                {
                    KorisnikID = 1,
                    Ime="admin",
                    Prezime="admin",
                    Email="adminadmin@gmail.com",
                    Telefon="+38700000000",
                    KorisnickoIme="admin",
                    LozinkaHash="",
                    LozinkaSalt="",
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
                      LozinkaSalt = "",
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
                        LozinkaSalt = "",
                    }
                );
        }
    }
}
