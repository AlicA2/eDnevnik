using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class KorisnikDetaljiInsertRequest
    {
        public int? KorisnikID { get; set; }
        public int? GodinaStudija { get; set; }
        public bool? ObnavljaGodinu { get; set; }
        public double? ProsjecnaOcjena { get; set; }
        public int? GodinaUpisaID { get; set; }
        public int? UpisanaSkolskaGodinaID { get; set; }
    }
}
