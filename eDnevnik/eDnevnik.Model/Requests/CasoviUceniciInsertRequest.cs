using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class CasoviUceniciInsertRequest
    {
        public int CasoviID { get; set; }
        public int UcenikID { get; set; }
        public bool IsPrisutan { get; set; }
    }
}
