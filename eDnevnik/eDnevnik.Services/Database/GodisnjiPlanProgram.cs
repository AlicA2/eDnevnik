using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class GodisnjiPlanProgram
    {
        public int GodisnjiPlanProgramID { get; set; }
        public int brojCasova { get; set; }
        public string Naziv { get; set; }
        public int OdjeljenjeID { get; set; }
        public int PredmetID { get; set; }
        public virtual Predmet Predmet { get; set; }
        public virtual Odjeljenje Odjeljenje { get; set; }
        public virtual ICollection<Casovi> Casovi { get; set; } = new List<Casovi>();
    }
}
