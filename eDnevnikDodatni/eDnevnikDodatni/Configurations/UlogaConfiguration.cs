using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Configurations
{
    public class UlogaConfiguration:BaseConfiguration<Uloge>
    {
        public override void Configure(EntityTypeBuilder<Uloge> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.UlogaID);
        }
    }
}
