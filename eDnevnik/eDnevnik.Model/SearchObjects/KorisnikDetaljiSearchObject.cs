using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class KorisnikDetaljiSearchObject : BaseSearchObject
    {
        public int? KorisnikDetaljiID { get; set; }
        public int? KorisnikID { get; set; }
        public int? GodinaStudija { get; set; }
        public int? GodinaUpisaID { get; set; }
        public int? UpisanaSkolskaGodinaID { get; set; }
    }
}
