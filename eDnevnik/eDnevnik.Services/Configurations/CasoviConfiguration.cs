using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eDnevnik.Services.Database;

namespace eDnevnik.Services.Configurations
{
    public class CasoviConfiguration : IEntityTypeConfiguration<Casovi>
    {
        public void Configure(EntityTypeBuilder<Casovi> builder)
        {
            builder.HasKey(c => c.CasoviID);

            builder.HasOne(c => c.GodisnjiPlanProgram)
                .WithMany(g => g.Casovi)
                .HasForeignKey(c => c.GodisnjiPlanProgramID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
