using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class KorisnikDogadjaj
    {
        public int KorisnikDogadjajID { get; set; }
        public int KorisnikID { get; set; }
        public int DogadjajId { get; set; }
    }
}
