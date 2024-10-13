using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Skola
    {
        public int SkolaID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public virtual ICollection<Odjeljenje> Odjeljenja { get; set; } = new List<Odjeljenje>();
        public virtual ICollection<Predmet> Predmeti { get; set; } = new List<Predmet>();
        public virtual ICollection<GodisnjiPlanProgram> GodisnjiPlanProgrami { get; set; } = new List<GodisnjiPlanProgram>();
        public virtual ICollection<Dogadjaji> Dogadjaji { get; set; } = new List<Dogadjaji>();

    }
}
