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
    public class KorisniciConfiguration : BaseConfiguration<Korisnik>
    {
        public override void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.KorisnikID);

            builder.HasMany(k => k.KorisniciUloge)
                   .WithOne(ku => ku.Korisnik)
                   .HasForeignKey(ku => ku.KorisnikID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(k => k.KorisniciDogadjaji)
                   .WithOne(kd => kd.Korisnik)
                   .HasForeignKey(kd => kd.KorisnikID);

            builder.HasOne(k => k.KorisnikDetalji)
                   .WithOne(kd => kd.Korisnik)
                   .HasForeignKey<KorisnikDetalji>(kd => kd.KorisnikID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
