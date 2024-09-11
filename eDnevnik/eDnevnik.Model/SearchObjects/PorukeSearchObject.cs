using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class PorukeSearchObject:BaseSearchObject
    {
        public string? Naziv { get; set; }
        public string? FTS { get; set; }
        public int? ProfesorID { get; set; }
        public int? UcenikID { get; set; }
    }
}
