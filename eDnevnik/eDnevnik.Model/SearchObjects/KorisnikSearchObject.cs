using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class KorisnikSearchObject : BaseSearchObject
    {
        public string? Ime { get; set; }
        public string? FTS { get; set; }
        public bool? isUlogeIncluded { get; set; }
        public int? OdjeljenjeID { get; set; }
        public int? UlogaID { get; set; }
    }
}
