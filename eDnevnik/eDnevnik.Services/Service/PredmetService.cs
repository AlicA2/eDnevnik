using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class PredmetService : BaseCRUDService<Model.Models.Predmet, Database.Predmet, PredmetSearchObject, PredmetInsertRequest, PredmetUpdateRequest>, IPredmetService
    {
        public PredmetService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<Predmet> AddFilter(IQueryable<Predmet> query, PredmetSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }
            if (!string.IsNullOrWhiteSpace(search.FTS))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            return base.AddFilter(query, search);
        }

        //public override IQueryable<Korisnik> AddInclude(IQueryable<Korisnik> query, PredmetSearchObject? search = null)
        //{
        //    if (search?.isUlogeIncluded == true)
        //    {
        //        query = query.Include("KorisniciUloge.Uloga");
        //    }
        //    return base.AddInclude(query, search);
        //}
    }
}
