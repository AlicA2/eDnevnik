using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Configurations
{
    public class KorisniciConfiguration:BaseConfiguration<Korisnik>
    {
        public override void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.KorisnikID);
        }
    }
}
