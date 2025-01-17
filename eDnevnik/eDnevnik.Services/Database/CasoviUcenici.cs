﻿using System;

namespace eDnevnik.Services.Database
{
    public partial class CasoviUcenici
    {
        public int CasoviUceniciID { get; set; }
        public int CasoviID { get; set; }
        public int UcenikID { get; set; }
        public bool IsPrisutan { get; set; }
        public bool zakljucan { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public virtual Casovi Casovi { get; set; }
        public virtual Korisnik Ucenik { get; set; }
    }
}
