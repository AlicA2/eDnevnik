using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDnevnik.Services.Database
{
    public class PorukaConfiguration : IEntityTypeConfiguration<Poruke>
    {
        public void Configure(EntityTypeBuilder<Poruke> builder)
        {
            builder.HasKey(p => p.PorukaID);

            builder.HasOne(p => p.Profesor)
                .WithMany()
                .HasForeignKey(p => p.ProfesorID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Roditelj)
                .WithMany()
                .HasForeignKey(p => p.RoditeljID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Ucenik)
                .WithMany()
                .HasForeignKey(p => p.UcenikID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
