using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class Dogadjaji
    {
        public int DogadjajId { get; set; }
        public string NazivDogadjaja { get; set; }
        public string OpisDogadjaja { get; set; }
        public byte[]? Slika { get; set; }
        public DateTime DatumDogadjaja { get; set; }
        public string? StateMachine { get; set; }
        public int? SkolaID { get; set; }

    }
}
