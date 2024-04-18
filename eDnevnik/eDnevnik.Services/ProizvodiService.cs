using eDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public class ProizvodiService : IProizvodiService
    {
        List<Proizvodi> proizvodis = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                ProizvodID = 1,
                Naziv = "Laptop"
            }
        };
        public IList<Proizvodi> Get()
        {
            return proizvodis;
        }
    }
}
