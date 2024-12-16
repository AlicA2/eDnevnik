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
    public class KorisnikDetaljiConfiguration : BaseConfiguration<KorisnikDetalji>
    {
        public override void Configure(EntityTypeBuilder<KorisnikDetalji> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.KorisnikDetaljiID);

            builder.Property(kd => kd.ProsjecnaOcjena)
               .HasPrecision(18, 2);

            builder.HasOne(kd => kd.Korisnik)
                  .WithOne(k => k.KorisnikDetalji)
                  .HasForeignKey<KorisnikDetalji>(kd => kd.KorisnikID)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(kd => kd.GodinaUpisa)
                   .WithMany(sg => sg.KorisniciDetalji)
                   .HasForeignKey(kd => kd.GodinaUpisaID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasOne(kd => kd.UpisanaSkolskaGodina)
                   .WithMany()
                   .HasForeignKey(kd => kd.UpisanaSkolskaGodinaID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

        }
    }
}
