using eDnevnik.Services.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public partial class eDnevnikDBContext
    {
        private void ApplyConfigurations (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);
        }
    }
}
