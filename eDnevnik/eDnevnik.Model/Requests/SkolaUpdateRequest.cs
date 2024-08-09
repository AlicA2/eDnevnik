using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class SkolaUpdateRequest
    {
        public int SkolaID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
    }
}
