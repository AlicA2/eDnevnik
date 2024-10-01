using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Database
{
    public partial class Dogadjaji
    {
        public int DogadjajId { get; set; }
        public string NazivDogadjaja { get; set; }
        public string OpisDogadjaja { get; set; }
        public byte[]? Slika { get; set; }
        public DateTime DatumDogadjaja { get; set; }
        public bool JeAktivan { get; set; }
    }
}
