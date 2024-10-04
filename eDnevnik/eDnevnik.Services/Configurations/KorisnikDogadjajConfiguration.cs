using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eDnevnik.Services.Database;

namespace eDnevnik.Services.Configurations
{
    public class KorisnikDogadjajConfiguration : BaseConfiguration<KorisnikDogadjaj>
    {
        public override void Configure(EntityTypeBuilder<KorisnikDogadjaj> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.KorisnikDogadjajID);

            builder.HasOne(kd => kd.Korisnik)
                   .WithMany(k => k.KorisniciDogadjaji)
                   .HasForeignKey(kd => kd.KorisnikID);

            builder.HasOne(kd => kd.Dogadjaj)
                   .WithMany(d => d.KorisniciDogadjaji)
                   .HasForeignKey(kd => kd.DogadjajId);
        }
    }
}
