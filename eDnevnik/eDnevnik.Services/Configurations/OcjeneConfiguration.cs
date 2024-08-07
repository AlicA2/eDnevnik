﻿using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Configurations
{
    public class OcjeneConfiguration : BaseConfiguration<Ocjene>
    {
        public override void Configure(EntityTypeBuilder<Ocjene> builder)
        {
            base.Configure(builder);
            builder.HasKey(o => o.OcjenaID);

            builder.HasOne(o => o.Korisnik)
                   .WithMany()
                   .HasForeignKey(o => o.KorisnikID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Predmet)
                   .WithMany(p => p.Ocjene)
                   .HasForeignKey(o => o.PredmetID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

