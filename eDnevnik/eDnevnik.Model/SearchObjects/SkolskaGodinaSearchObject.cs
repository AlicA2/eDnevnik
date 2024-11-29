using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class SkolskaGodinaSearchObject : BaseSearchObject
    {
        public int? SkolskaGodinaID { get; set; }
        public string? Naziv { get; set; } = null!;
    }
}
