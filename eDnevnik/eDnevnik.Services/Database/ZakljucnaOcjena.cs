using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public class ZakljucnaOcjena
    {
        public int ZakljucnaOcjenaID { get; set; }
        public int PredmetID { get; set; }
        public int KorisnikID { get; set; }
        public decimal vrijednostZakljucneOcjene { get; set; }
        public virtual Predmet Predmet { get; set; } = null!;
        public virtual Korisnik Korisnik { get; set; } = null!;
    }
}
