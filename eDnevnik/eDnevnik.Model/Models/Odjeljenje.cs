using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class Odjeljenje
    {
        public int OdjeljenjeID { get; set; }
        public string NazivOdjeljenja { get; set; }
        public int? RazrednikID { get; set; }
        public int? SkolaID { get; set; }
        public virtual ICollection<Korisnik> Ucenici { get; } = new List<Korisnik>();

    }
}
