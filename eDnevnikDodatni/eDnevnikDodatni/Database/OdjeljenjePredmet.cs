using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class OdjeljenjePredmet
    {
        public int OdjeljenjePredmetID { get; set; }
        public int PredmetID { get; set; }
        public int OdjeljenjeID { get; set; }
        public virtual Predmet Predmet { get; set; } = null!;
        public virtual Odjeljenje Odjeljenje { get; set; } = null!;
    }
}
