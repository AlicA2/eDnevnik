using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class OcjeneUpdateRequest
    {
        public int VrijednostOcjene { get; set; }
        public int PredmetID { get; set; }
        public DateTime Datum { get; set; }
    }
}
