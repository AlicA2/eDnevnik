using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class OcjeneSearchObject : BaseSearchObject
    {
        public int? OcjenaID { get; set; }
        public int? KorisnikID { get; set; }
        public int? PredmetID { get; set; }
        public int? ProfesorID { get; set; }
    }
}
