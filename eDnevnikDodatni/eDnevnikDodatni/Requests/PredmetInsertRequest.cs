using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class PredmetInsertRequest
    {
        public string Naziv { get; set; } 
        public string? Opis { get; set; }
        public int? SkolaID { get; set; }
    }
}
