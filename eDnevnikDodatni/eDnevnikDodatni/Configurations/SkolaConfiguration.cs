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
    public class SkolaConfiguration : BaseConfiguration<Skola>
    {
        public override void Configure(EntityTypeBuilder<Skola> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.SkolaID);

            builder.HasMany(s => s.Odjeljenja)
                   .WithOne(o => o.Skola)
                   .HasForeignKey(o => o.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.GodisnjiPlanProgrami)
                   .WithOne(gp => gp.Skola)
                   .HasForeignKey(gp => gp.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Predmeti)
                   .WithOne(gp => gp.Skola)
                   .HasForeignKey(gp => gp.SkolaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Dogadjaji)
                  .WithOne(d => d.Skola)
                  .HasForeignKey(d => d.SkolaID)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
