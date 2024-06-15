using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class OdjeljenjeSearchObject : BaseSearchObject
    {
        public string? NazivOdjeljenja { get; set; }
        public string? FTS { get; set; }
        public bool? isUceniciIncluded { get; set; }
    }
}
