using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eDnevnik.Services.Database;

namespace eDnevnik.Services.Configurations
{
    public class GodisnjiPlanProgramConfiguration : IEntityTypeConfiguration<GodisnjiPlanProgram>
    {
        public void Configure(EntityTypeBuilder<GodisnjiPlanProgram> builder)
        {
            builder.HasKey(g => g.GodisnjiPlanProgramID);

            builder.HasOne(g => g.Predmet)
                .WithMany()
                .HasForeignKey(g => g.PredmetID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(g => g.Odjeljenje)
                .WithMany()
                .HasForeignKey(g => g.OdjeljenjeID)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(g => g.Casovi)
            //    .WithOne(c => c.GodisnjiPlanProgram)
            //    .HasForeignKey(c => c.GodisnjiPlanProgramID)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
