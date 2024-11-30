using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class KorisnikDetalji
    {
        public int KorisnikDetaljiID { get; set; }
        public int? KorisnikID { get; set; }
        public int? GodinaStudija { get; set; }
        public bool? ObnavljaGodinu { get; set; }
        public decimal? ProsjecnaOcjena { get; set; }
        public int? GodinaUpisaID { get; set; }
        public int? UpisanaSkolskaGodinaID { get; set; }
    }
}
