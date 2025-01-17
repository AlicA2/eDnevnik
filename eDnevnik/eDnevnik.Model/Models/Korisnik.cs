﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public string? LozinkaHash { get; set; }
        public string? LozinkaSalt { get; set; }
        public int? OdjeljenjeID { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; } = new List<KorisniciUloge>();
    }
}
