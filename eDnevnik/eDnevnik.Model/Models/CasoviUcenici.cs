﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Models
{
    public class CasoviUcenici
    {
        public int CasoviUceniciID { get; set; }
        public int CasoviID { get; set; }
        public int UcenikID { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public bool IsPrisutan { get; set; }
        public bool? zakljucan { get; set; }
    }
}
