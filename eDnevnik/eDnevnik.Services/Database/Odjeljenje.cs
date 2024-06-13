using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Odjeljenje
    {
        public int OdjeljenjeID { get; set; }
        public string NazivOdjeljenja { get; set; } = null!;
        public int? RazrednikID { get; set; }
        public virtual Korisnik? Razrednik { get; set; } = null!;
        public virtual ICollection<Korisnik> Ucenici { get; } = new List<Korisnik>();
    }
}
