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
    public class OdjeljenjePredmetConfiguration : BaseConfiguration<OdjeljenjePredmet>
    {
        public override void Configure(EntityTypeBuilder<OdjeljenjePredmet> builder)
        {
            base.Configure(builder);
            builder.HasKey(op => op.OdjeljenjePredmetID);

            builder.HasOne(op => op.Predmet)
                   .WithMany(p => p.OdjeljenjePredmeti)
                   .HasForeignKey(op => op.PredmetID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(op => op.Odjeljenje)
                   .WithMany(o => o.OdjeljenjePredmeti)
                   .HasForeignKey(op => op.OdjeljenjeID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
