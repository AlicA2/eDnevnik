using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Ocjene
    {
        public int OcjenaID { get; set; }
        public int VrijednostOcjene { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikID { get; set; }
        public virtual Korisnik Korisnik { get; set; } = null!;
        public int PredmetID { get; set; }
        public virtual Predmet Predmet { get; set; } = null!;
    }
}
