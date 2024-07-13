using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class CasoviSearchObject : BaseSearchObject
    {
        public string? Naziv { get; set; }
        public string? FTS { get; set; }
    }
}
