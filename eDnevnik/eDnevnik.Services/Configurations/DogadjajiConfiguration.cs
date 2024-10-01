using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eDnevnik.Services.Database;

namespace eDnevnik.Services.Configurations
{
    public class DogadjajiConfiguration : BaseConfiguration<Dogadjaji>
    {
        public override void Configure(EntityTypeBuilder<Dogadjaji> builder)
        {
            base.Configure(builder);
            builder.HasKey(c => c.DogadjajId);

            builder.HasOne(d => d.Skola)
                   .WithMany(s => s.Dogadjaji)
                   .HasForeignKey(d => d.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.KorisniciDogadjaji)
                   .WithOne(kd => kd.Dogadjaj)
                   .HasForeignKey(kd => kd.DogadjajId);
        }
    }
}
