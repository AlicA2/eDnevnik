﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Model.SearchObjects
{
    public class OdjeljenjePredmetSearchObject : BaseSearchObject
    {
        public int? PredmetID { get; set; }
        public int? OdjeljenjeID { get; set; }
    }
}
