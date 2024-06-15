using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class Ocjene
    {
        public int OcjenaID { get; set; }
        public int Ocjena { get; set; }
        public DateTime Datum { get; set; }
        public int UcenikID { get; set; }
        public int PredmetID { get; set; }
        public int ProfesorID { get; set; }
    }
}
