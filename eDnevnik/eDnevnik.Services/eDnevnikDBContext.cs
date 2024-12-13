using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik.Services
{
    public partial class eDnevnikDBContext:DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Uloge> Uloge { get; set; }
        public DbSet<KorisniciUloge> korisniciUloges { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<Ocjene> Ocjene { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Poruke> Poruke { get; set; }
        public DbSet<GodisnjiPlanProgram> GodisnjiPlanProgram { get; set; }
        public DbSet<Casovi> Casovi { get; set; }
        public DbSet<Skola> Skola { get; set; }
        public DbSet<OdjeljenjePredmet> OdjeljenjePredmet { get; set; }
        public DbSet<CasoviUcenici> CasoviUcenici { get; set; }
        public DbSet<Dogadjaji> Dogadjaji { get; set; }
        public DbSet<KorisnikDogadjaj> KorisniciDogadjaji { get; set; }
        public DbSet<ZakljucnaOcjena> ZakljucnaOcjena { get; set; }
        public DbSet<SkolskaGodina> SkolskaGodina { get; set; }
        public DbSet<KorisnikDetalji> KorisnikDetalji { get; set; }


        public eDnevnikDBContext(DbContextOptions<eDnevnikDBContext> options):base(options)
    { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

    }
}
