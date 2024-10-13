using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class GodisnjiPlanProgramSearchObject : BaseSearchObject
    {
        public string? Naziv { get; set; }
        public string? FTS { get; set; }
        public int? OdjeljenjeID { get; set; }
        public int? PredmetID { get; set; }
        public int? SkolaID { get; set; }
        public int? ProfesorID { get; set; }
        public bool? isCasoviIncluded { get; set; }
    }
}
