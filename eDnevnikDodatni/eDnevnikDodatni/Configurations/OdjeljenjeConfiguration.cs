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
    public class OdjeljenjeConfiguration : BaseConfiguration<Odjeljenje>
    {
        public override void Configure(EntityTypeBuilder<Odjeljenje> builder)
        {
            base.Configure(builder);
            builder.HasKey(o => o.OdjeljenjeID);

            builder.HasOne(o => o.Skola)
                   .WithMany(s => s.Odjeljenja)
                   .HasForeignKey(o => o.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Ucenici)
                   .WithOne()
                   .HasForeignKey(u => u.OdjeljenjeID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Razrednik)
                    .WithOne(k => k.Odjeljenje)
                    .HasForeignKey<Odjeljenje>(o => o.RazrednikID);

        }
    }

}
