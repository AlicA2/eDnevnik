using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class KorisniciUlogeSearchObject : BaseSearchObject
    {
        public int? KorisnikUlogaID { get; set; }
        public int? KorisnikID { get; set; }
        public int? UlogaID { get; set; }
        public bool? isUlogaIncluded { get; set; }
    }
}
