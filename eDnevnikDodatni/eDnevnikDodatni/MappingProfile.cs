using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eDnevnik.Model.Models;

namespace eDnevnik.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnik, Korisnik>();
            CreateMap<Model.Requests.KorisniciInsertRequest, Database.Korisnik>();
            CreateMap<Model.Requests.KorisniciUpdateRequest, Database.Korisnik>();
            CreateMap<Model.Requests.KorisniciDeleteRequest, Database.Korisnik>();

            CreateMap<Database.Uloge, Uloge>();
            CreateMap<Database.KorisniciUloge, KorisniciUloge>();

            CreateMap<Database.Predmet, Predmet>();
            CreateMap<Model.Requests.PredmetInsertRequest, Database.Predmet>();
            CreateMap<Model.Requests.PredmetUpdateRequest, Database.Predmet>();
            CreateMap<Model.Requests.PredmetDeleteRequest, Database.Predmet>();

            CreateMap<Database.Odjeljenje, Odjeljenje>();
            CreateMap<Model.Requests.OdjeljenjeInsertRequest, Database.Odjeljenje>();
            CreateMap<Model.Requests.OdjeljenjeUpdateRequest, Database.Odjeljenje>();
            CreateMap<Model.Requests.OdjeljenjeDeleteRequest, Database.Odjeljenje>();

            CreateMap<Database.Poruke, Poruke>();
            CreateMap<Model.Requests.PorukaInsertRequest, Database.Poruke>();
            CreateMap<Model.Requests.PorukaUpdateRequest, Database.Poruke>();
            CreateMap<Model.Requests.PorukeDeleteRequest, Database.Poruke>();

            CreateMap<Database.Casovi, Casovi>();
            CreateMap<Model.Requests.CasoviInsertRequest, Database.Casovi>();
            CreateMap<Model.Requests.CasoviUpdateRequest, Database.Casovi>();
            CreateMap<Model.Requests.CasoviDeleteRequest, Database.Casovi>();

            CreateMap<Database.GodisnjiPlanProgram, GodisnjiPlanProgram>();
            CreateMap<Model.Requests.GodisnjiPlanProgramInsertRequest, Database.GodisnjiPlanProgram>();
            CreateMap<Model.Requests.GodisnjiPlanProgramUpdateRequest, Database.GodisnjiPlanProgram>();
            CreateMap<Model.Requests.GodisnjiPlanProgramDeleteRequest, Database.GodisnjiPlanProgram>();

            CreateMap<Database.Skola, Skola>();
            CreateMap<Model.Requests.SkolaInsertRequest, Database.Skola>();
            CreateMap<Model.Requests.SkolaUpdateRequest, Database.Skola>();
            CreateMap<Model.Requests.SkolaDeleteRequest, Database.Skola>();

            CreateMap<Database.OdjeljenjePredmet, OdjeljenjePredmet>();
            CreateMap<Model.Requests.OdjeljenjePredmetInsertRequest, Database.OdjeljenjePredmet>();
            CreateMap<Model.Requests.OdjeljenjePredmetUpdateRequest, Database.OdjeljenjePredmet>();
            CreateMap<Model.Requests.OdjeljenjePredmetDeleteRequest, Database.OdjeljenjePredmet>();

            CreateMap<Database.Ocjene, Ocjene>();
            CreateMap<Model.Requests.OcjeneInsertRequest, Database.Ocjene>();
            CreateMap<Model.Requests.OcjeneUpdateRequest, Database.Ocjene>();
            CreateMap<Model.Requests.OcjeneDeleteRequest, Database.Ocjene>();

            CreateMap<Database.CasoviUcenici, CasoviUcenici>();
            CreateMap<Model.Requests.CasoviUceniciInsertRequest, Database.CasoviUcenici>();
            CreateMap<Model.Requests.CasoviUceniciUpdateRequest, Database.CasoviUcenici>();
            CreateMap<Model.Requests.CasoviUceniciDeleteRequest, Database.CasoviUcenici>();

            CreateMap<Database.Dogadjaji, Dogadjaji>();
            CreateMap<Model.Requests.DogadjajiInsertRequest, Database.Dogadjaji>();
            CreateMap<Model.Requests.DogadjajiUpdateRequest, Database.Dogadjaji>();
            CreateMap<Model.Requests.DogadjajiDeleteRequest, Database.Dogadjaji>();

            CreateMap<Database.KorisnikDogadjaj, KorisnikDogadjaj>();
            CreateMap<Model.Requests.KorisnikDogadjajInsertRequest, Database.KorisnikDogadjaj>();
            CreateMap<Model.Requests.KorisnikDogadjajUpdateRequest, Database.KorisnikDogadjaj>();
            CreateMap<Model.Requests.KorisnikDogadjajDeleteRequest, Database.KorisnikDogadjaj>();
        }
    }
}
