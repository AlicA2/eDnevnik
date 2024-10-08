﻿using System;
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
        public int? SkolaID { get; set; }
        public string? StateMachine { get; set; }
        public decimal? ZakljucnaOcjena { get; set; }
        public virtual ICollection<Ocjene> Ocjene { get; } = new List<Ocjene>();


    }
}
