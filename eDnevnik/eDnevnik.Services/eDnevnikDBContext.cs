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


        public eDnevnikDBContext(DbContextOptions<eDnevnikDBContext> options):base(options)
    { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

    }
}
