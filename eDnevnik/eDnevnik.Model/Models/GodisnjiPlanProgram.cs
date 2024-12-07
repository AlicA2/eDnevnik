using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class GodisnjiPlanProgram
    {
        public int GodisnjiPlanProgramID { get; set; }
        public int brojCasova { get; set; }
        public string Naziv { get; set; }
        public int OdjeljenjeID { get; set; }
        public int PredmetID { get; set; }
        public int SkolaID { get; set; }
        public int? ProfesorID { get; set; }
        public int SkolskaGodinaID { get; set; }
        public virtual ICollection<Casovi> Casovi { get; set; } = new List<Casovi>();
    }
}
