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
        public virtual ICollection<Korisnik>? Ucenici { get; } = new List<Korisnik>();
        public virtual ICollection<Ocjene>? Ocjene { get; } = new List<Ocjene>();
        public string? StateMachine { get; set; }
    }
}
