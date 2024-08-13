using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Configurations
{
    public class PredmetConfiguration : BaseConfiguration<Predmet>
    {
        public override void Configure(EntityTypeBuilder<Predmet> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.PredmetID);

            builder.HasOne(p => p.Odjeljenje)
                   .WithMany(o => o.Predmeti)
                   .HasForeignKey(p => p.OdjeljenjeID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Ocjene)
                   .WithOne(o => o.Predmet)
                   .HasForeignKey(o => o.PredmetID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gp => gp.Skola)
                   .WithMany(s => s.Predmeti)
                   .HasForeignKey(gp => gp.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
