using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class ZakljucnaOcjenaInsertRequest
    {
        public int PredmetID { get; set; }
        public int KorisnikID { get; set; }
        public decimal vrijednostZakljucneOcjene { get; set; }
    }
}
