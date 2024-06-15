using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class Predmet
    {
        public int PredmetID { get; set; }
        public string Naziv { get; set; }
        public string? Opis { get; set; }
    }
}
