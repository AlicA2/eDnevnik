using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Korisnik
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? StateMachine { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public bool? Status { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; } = new List<KorisniciUloge>();
        public int? OdjeljenjeID { get; set; }
        public virtual Odjeljenje? Odjeljenje { get; set; }
        public virtual ICollection<Predmet> Predmeti { get; } = new List<Predmet>();
        public virtual ICollection<Ocjene> Ocjene { get; } = new List<Ocjene>();
    }
}
