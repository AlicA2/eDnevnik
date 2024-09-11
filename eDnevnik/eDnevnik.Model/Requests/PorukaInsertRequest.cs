using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class PorukaInsertRequest
    {
        public int ProfesorID { get; set; }
        public int UcenikID { get; set; }
        public string SadrzajPoruke { get; set; }
        public DateTime DatumSlanja { get; set; }
    }
}
