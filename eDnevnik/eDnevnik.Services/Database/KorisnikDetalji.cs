using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class KorisnikDetalji
    {
        public int KorisnikDetaljiID { get; set; }
        public int? KorisnikID { get; set; }
        public int? GodinaStudija { get; set; }
        public bool? ObnavljaGodinu { get; set; }
        public decimal? ProsjecnaOcjena { get; set; }
        public int? GodinaUpisaID { get; set; }
        public int? UpisanaSkolskaGodinaID { get; set; }
        public virtual SkolskaGodina GodinaUpisa { get; set; } = null!;
        public virtual SkolskaGodina UpisanaSkolskaGodina { get; set; } = null!;
        public virtual Korisnik Korisnik { get; set; } = null!;
    }
}

