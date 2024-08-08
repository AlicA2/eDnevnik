using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eDnevnik.Services.Database;

namespace eDnevnik.Services.Configurations
{
    public class CasoviConfiguration : BaseConfiguration<Casovi>
    {
        public override void Configure(EntityTypeBuilder<Casovi> builder)
        {
            base.Configure(builder);
            builder.HasKey(c => c.CasoviID);

            //builder.HasOne(c => c.GodisnjiPlanProgram)
            //    .WithMany(g => g.Casovi)
            //    .HasForeignKey(c => c.GodisnjiPlanProgramID)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
