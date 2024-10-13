using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class CasoviInsertRequest
    {
        public string NazivCasa { get; set; }
        public string Opis { get; set; }
        public int GodisnjiPlanProgramID { get; set; }
    }
}
