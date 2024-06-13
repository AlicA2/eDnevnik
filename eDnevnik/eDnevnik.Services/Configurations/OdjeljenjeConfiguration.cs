using eDnevnik.Services.Database;
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

            builder.HasOne(o => o.Razrednik)
                        .WithMany()
                        .HasForeignKey(o => o.RazrednikID);

            builder.HasMany(o => o.Ucenici)
                   .WithOne(k => k.Odjeljenje)
                   .HasForeignKey(k => k.OdjeljenjeID);
        }
    }
}
