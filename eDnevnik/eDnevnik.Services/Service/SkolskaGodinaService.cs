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
    public class SkolskaGodinaService : BaseCRUDService<Model.Models.SkolskaGodina, Database.SkolskaGodina, SkolskaGodinaSearchObject, SkolskaGodinaInsertRequest, SkolskaGodinaUpdateRequest, SkolskaGodinaDeleteRequest>, ISkolskaGodinaService
    {
        public SkolskaGodinaService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<SkolskaGodina> AddFilter(IQueryable<SkolskaGodina> query, SkolskaGodinaSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
                }
                if (search.SkolskaGodinaID.HasValue)
                {
                    query = query.Where(x => x.SkolskaGodinaID == search.SkolskaGodinaID.Value);
                }
            }
            return base.AddFilter(query, search);
        }
    }
}
