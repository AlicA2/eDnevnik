using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace eDnevnik.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnik, Model.Models.Korisnik>();
            CreateMap<Model.Requests.KorisniciInsertRequest, Services.Database.Korisnik>();
            CreateMap<Model.Requests.KorisniciUpdateRequest, Services.Database.Korisnik>();
        }
    }
}
