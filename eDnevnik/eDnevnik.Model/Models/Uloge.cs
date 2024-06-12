using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class Uloge
    {
        public int UlogaID { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }
    }
}
