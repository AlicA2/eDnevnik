﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.Requests
{
    public class KorisnikDogadjajUpdateRequest
    {
        public int KorisnikID { get; set; }
        public int DogadjajId { get; set; }
    }
}