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
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; } = new List<KorisniciUloge>();
        public int? OdjeljenjeID { get; set; }
        public virtual Odjeljenje Odjeljenje { get; set; }
        public virtual ICollection<KorisnikDogadjaj> KorisniciDogadjaji { get; set; } = new List<KorisnikDogadjaj>();
    }
}
