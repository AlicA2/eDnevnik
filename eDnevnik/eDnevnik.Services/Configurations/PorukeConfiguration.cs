using eDnevnik.Services.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDnevnik.Services.Database
{
    public class PorukaConfiguration : BaseConfiguration<Poruke>
    {
        public override void Configure(EntityTypeBuilder<Poruke> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.PorukaID);

            builder.HasOne(p => p.Profesor)
                .WithMany()
                .HasForeignKey(p => p.ProfesorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Roditelj)
                .WithMany()
                .HasForeignKey(p => p.RoditeljID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Ucenik)
                .WithMany()
                .HasForeignKey(p => p.UcenikID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
