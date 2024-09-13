using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Casovi
    {
        public int CasoviID { get; set; }
        public string NazivCasa { get; set; }
        public string Opis { get; set; }
        public int GodisnjiPlanProgramID { get; set; }
        public DateTime? DatumOdrzavanjaCasa { get; set; }
        public virtual GodisnjiPlanProgram GodisnjiPlanProgram { get; set; }
    }
}
