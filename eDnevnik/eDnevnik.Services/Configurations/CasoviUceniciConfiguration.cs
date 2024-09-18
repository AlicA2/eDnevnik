using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDnevnik.Services.Configurations
{
    public class CasoviUceniciConfiguration : BaseConfiguration<CasoviUcenici>
    {
        public override void Configure(EntityTypeBuilder<CasoviUcenici> builder)
        {
            base.Configure(builder);
            builder.HasKey(cu => cu.CasoviUceniciID);

            builder.HasOne(cu => cu.Casovi)
                .WithMany(c => c.CasoviUcenici)
                .HasForeignKey(cu => cu.CasoviID);

            builder.HasOne(cu => cu.Ucenik)
                .WithMany()
                .HasForeignKey(cu => cu.UcenikID);
        }
    }
}
