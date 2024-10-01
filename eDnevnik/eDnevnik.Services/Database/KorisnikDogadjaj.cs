using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class KorisnikDogadjaj
    {
        public int KorisnikID { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int DogadjajId { get; set; }
        public virtual Dogadjaji Dogadjaj { get; set; }
    }
}
