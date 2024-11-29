using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class SkolskaGodina
    {
        public int SkolskaGodinaID { get; set; }
        public string Naziv { get; set; } = null!;
        public virtual ICollection<KorisnikDetalji> KorisniciDetalji { get; set; } = new List<KorisnikDetalji>();
    }
}

