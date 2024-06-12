using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class KorisniciUloge
    {
        public int KorisnikUlogaID { get; set; }
        public int KorisnikID { get; set; }
        public int UlogaID { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public virtual Uloge Uloga { get; set; } = null!;


    }
}
