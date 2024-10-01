using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class DogadjajiSearchObject : BaseSearchObject
    {
        public int? DogadjajId { get; set; }
        public string? NazivDogadjaja { get; set; }
        public string? OpisDogadjaja { get; set; }
    }
}
