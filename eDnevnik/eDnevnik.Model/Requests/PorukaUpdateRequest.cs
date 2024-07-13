using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class PorukaUpdateRequest
    {
        public string SadrzajPoruke { get; set; }
        public string Odgovor { get; set; }
        public DateTime DatumSlanja { get; set; }
    }
}
