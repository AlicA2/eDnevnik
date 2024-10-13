using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class OdjeljenjePredmetUpdateRequest
    {
        public int PredmetID { get; set; }
        public int OdjeljenjeID { get; set; }
    }
}
