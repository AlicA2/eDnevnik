using eDnevnik.Services.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDnevnik.Services.Configurations
{
    public class SkolskaGodinaConfiguration : BaseConfiguration<SkolskaGodina>
    {
        public override void Configure(EntityTypeBuilder<SkolskaGodina> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.SkolskaGodinaID);
        }
    }
}
