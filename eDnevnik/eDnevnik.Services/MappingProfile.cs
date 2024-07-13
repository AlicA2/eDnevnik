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
        }
    }
}
