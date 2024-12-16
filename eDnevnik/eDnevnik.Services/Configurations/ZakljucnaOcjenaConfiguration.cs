using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDnevnik.Services.Configurations
{
    public class ZakljucnaOcjenaConfiguration : BaseConfiguration<ZakljucnaOcjena>
    {
        public override void Configure(EntityTypeBuilder<ZakljucnaOcjena> builder)
        {
            base.Configure(builder);
            builder.HasKey(z => z.ZakljucnaOcjenaID);

            builder.Property(z => z.vrijednostZakljucneOcjene)
               .HasPrecision(18, 2);

            builder.HasOne(z => z.Korisnik)
                   .WithMany()
                   .HasForeignKey(z => z.KorisnikID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(z => z.Predmet)
                   .WithMany()
                   .HasForeignKey(z => z.PredmetID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
