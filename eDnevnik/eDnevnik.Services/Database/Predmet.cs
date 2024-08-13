using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Predmet
    {
        public int PredmetID { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }
        public string? StateMachine { get; set; }
        public int? SkolaID { get; set; }
        public virtual Skola Skola { get; set; } = null!;
        public int OdjeljenjeID { get; set; }
        public virtual Odjeljenje Odjeljenje { get; set; } = null!;
        public virtual ICollection<Ocjene> Ocjene { get; set; } = new List<Ocjene>();
    }
}
