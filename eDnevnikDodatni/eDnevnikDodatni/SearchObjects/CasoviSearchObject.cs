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
        public int? CasoviID { get; set; }
        public int? GodisnjiPlanProgramID { get; set; }
        public int? SkolaID { get; set; }
        public bool? IsOdrzan { get; set; }
        public int? ProfesorID { get; set; }
        public int? OdjeljenjeID { get; set; }
    }
}
