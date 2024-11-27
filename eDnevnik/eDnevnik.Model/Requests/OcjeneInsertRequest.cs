using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class OcjeneInsertRequest
    {
        public int VrijednostOcjene { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikID { get; set; }
        public int PredmetID { get; set; }
        public string? Komentar { get; set; }
    }
}
