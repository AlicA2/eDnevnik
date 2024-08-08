using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Poruke
    {
        public int PorukaID { get; set; }
        public int ProfesorID { get; set; }
        public int RoditeljID { get; set; }
        public int UcenikID { get; set; }
        public string SadrzajPoruke { get; set; }
        public string Odgovor { get; set; } = null!;
        public DateTime DatumSlanja { get; set; }

        public virtual Korisnik Profesor { get; set; } = null!;
        public virtual Korisnik Roditelj { get; set; } = null!;
        public virtual Korisnik Ucenik { get; set; } = null!;
    }
}
