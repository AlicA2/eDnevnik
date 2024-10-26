using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class ZakljucnaOcjena
    {
        public int ZakljucnaOcjenaID { get; set; }
        public int PredmetID { get; set; }
        public int KorisnikID { get; set; }
        public decimal vrijednostZakljucneOcjene { get; set; }
    }
}
