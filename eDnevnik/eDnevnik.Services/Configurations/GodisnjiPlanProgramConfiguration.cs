using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eDnevnik.Services.Database;

namespace eDnevnik.Services.Configurations
{
    public class GodisnjiPlanProgramConfiguration : BaseConfiguration<GodisnjiPlanProgram>
    {
        public override void Configure(EntityTypeBuilder<GodisnjiPlanProgram> builder)
        {
            base.Configure(builder);
            builder.HasKey(gp => gp.GodisnjiPlanProgramID);

            builder.HasOne(gp => gp.Skola)
                   .WithMany(s => s.GodisnjiPlanProgrami)
                   .HasForeignKey(gp => gp.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gp => gp.Predmet)
                   .WithMany()
                   .HasForeignKey(gp => gp.PredmetID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gp => gp.Odjeljenje)
                   .WithMany()
                   .HasForeignKey(gp => gp.OdjeljenjeID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gp => gp.SkolskaGodina)
                   .WithMany()
                   .HasForeignKey(gp => gp.SkolskaGodinaID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
