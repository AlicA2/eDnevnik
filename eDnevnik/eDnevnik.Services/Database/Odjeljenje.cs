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
        public int? SkolaID { get; set; }
        public virtual Skola Skola { get; set; } = null!;
        public virtual ICollection<Predmet> Predmeti { get; set; } = new List<Predmet>();
        public virtual ICollection<Korisnik> Ucenici { get; set; } = new List<Korisnik>();
    }
}
