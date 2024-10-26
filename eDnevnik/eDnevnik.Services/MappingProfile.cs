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
            CreateMap<Model.Requests.KorisniciDeleteRequest, Services.Database.Korisnik>();

            CreateMap<Database.Uloge, Model.Models.Uloge>();
            CreateMap<Database.KorisniciUloge, Model.Models.KorisniciUloge>();

            CreateMap<Database.Predmet, Model.Models.Predmet>();
            CreateMap<Model.Requests.PredmetInsertRequest, Services.Database.Predmet>();
            CreateMap<Model.Requests.PredmetUpdateRequest, Services.Database.Predmet>();
            CreateMap<Model.Requests.PredmetDeleteRequest, Services.Database.Predmet>();

            CreateMap<Database.Odjeljenje, Model.Models.Odjeljenje>();
            CreateMap<Model.Requests.OdjeljenjeInsertRequest, Services.Database.Odjeljenje>();
            CreateMap<Model.Requests.OdjeljenjeUpdateRequest, Services.Database.Odjeljenje>();
            CreateMap<Model.Requests.OdjeljenjeDeleteRequest, Services.Database.Odjeljenje>();

            CreateMap<Database.Poruke, Model.Models.Poruka>();
            CreateMap<Model.Requests.PorukaInsertRequest, Services.Database.Poruke>();
            CreateMap<Model.Requests.PorukaUpdateRequest, Services.Database.Poruke>();
            CreateMap<Model.Requests.PorukeDeleteRequest, Services.Database.Poruke>();

            CreateMap<Database.Casovi, Model.Models.Casovi>();
            CreateMap<Model.Requests.CasoviInsertRequest, Services.Database.Casovi>();
            CreateMap<Model.Requests.CasoviUpdateRequest, Services.Database.Casovi>();
            CreateMap<Model.Requests.CasoviDeleteRequest, Services.Database.Casovi>();

            CreateMap<Database.GodisnjiPlanProgram, Model.Models.GodisnjiPlanProgram>();
            CreateMap<Model.Requests.GodisnjiPlanProgramInsertRequest, Services.Database.GodisnjiPlanProgram>();
            CreateMap<Model.Requests.GodisnjiPlanProgramUpdateRequest, Services.Database.GodisnjiPlanProgram>();
            CreateMap<Model.Requests.GodisnjiPlanProgramDeleteRequest, Services.Database.GodisnjiPlanProgram>();

            CreateMap<Database.Skola, Model.Models.Skola>();
            CreateMap<Model.Requests.SkolaInsertRequest, Services.Database.Skola>();
            CreateMap<Model.Requests.SkolaUpdateRequest, Services.Database.Skola>();
            CreateMap<Model.Requests.SkolaDeleteRequest, Services.Database.Skola>();

            CreateMap<Database.OdjeljenjePredmet, Model.Models.OdjeljenjePredmet>();
            CreateMap<Model.Requests.OdjeljenjePredmetInsertRequest, Services.Database.OdjeljenjePredmet>();
            CreateMap<Model.Requests.OdjeljenjePredmetUpdateRequest, Services.Database.OdjeljenjePredmet>();
            CreateMap<Model.Requests.OdjeljenjePredmetDeleteRequest, Services.Database.OdjeljenjePredmet>();

            CreateMap<Database.Ocjene, Model.Models.Ocjene>();
            CreateMap<Model.Requests.OcjeneInsertRequest, Services.Database.Ocjene>();
            CreateMap<Model.Requests.OcjeneUpdateRequest, Services.Database.Ocjene>();
            CreateMap<Model.Requests.OcjeneDeleteRequest, Services.Database.Ocjene>();

            CreateMap<Database.CasoviUcenici, Model.Models.CasoviUcenici>();
            CreateMap<Model.Requests.CasoviUceniciInsertRequest, Services.Database.CasoviUcenici>();
            CreateMap<Model.Requests.CasoviUceniciUpdateRequest, Services.Database.CasoviUcenici>();
            CreateMap<Model.Requests.CasoviUceniciDeleteRequest, Services.Database.CasoviUcenici>();

            CreateMap<Database.Dogadjaji, Model.Models.Dogadjaji>();
            CreateMap<Model.Requests.DogadjajiInsertRequest, Services.Database.Dogadjaji>();
            CreateMap<Model.Requests.DogadjajiUpdateRequest, Services.Database.Dogadjaji>();
            CreateMap<Model.Requests.DogadjajiDeleteRequest, Services.Database.Dogadjaji>();

            CreateMap<Database.KorisnikDogadjaj, Model.Models.KorisnikDogadjaj>();
            CreateMap<Model.Requests.KorisnikDogadjajInsertRequest, Services.Database.KorisnikDogadjaj>();
            CreateMap<Model.Requests.KorisnikDogadjajUpdateRequest, Services.Database.KorisnikDogadjaj>();
            CreateMap<Model.Requests.KorisnikDogadjajDeleteRequest, Services.Database.KorisnikDogadjaj>();

            CreateMap<Database.ZakljucnaOcjena, Model.Models.ZakljucnaOcjena>();
            CreateMap<Model.Requests.ZakljucnaOcjenaInsertRequest, Services.Database.ZakljucnaOcjena>();
            CreateMap<Model.Requests.ZakljucnaOcjenaUpdateRequest, Services.Database.ZakljucnaOcjena>();
            CreateMap<Model.Requests.ZakljucnaOcjenaDeleteRequest, Services.Database.ZakljucnaOcjena>();
        }
    }
}
