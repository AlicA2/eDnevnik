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
    public class KorisniciUlogeConfiguration:BaseConfiguration<KorisniciUloge>
    {
        public override void Configure(EntityTypeBuilder<KorisniciUloge> builder)
        {
            base.Configure(builder);
            builder.HasKey(e => e.KorisnikUlogaID);

            builder.HasOne(ko => ko.Korisnik)
                .WithMany(k => k.KorisniciUloge)
                .HasForeignKey(ko => ko.KorisnikID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ko => ko.Uloga)
                .WithMany(k => k.KorisniciUloge)
                .HasForeignKey(ko => ko.UlogaID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
