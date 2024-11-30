using AutoMapper;
using eDnevnik.Model;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class KorisnikDetaljiService : BaseCRUDService<Model.Models.KorisnikDetalji, Database.KorisnikDetalji, KorisnikDetaljiSearchObject, KorisnikDetaljiInsertRequest, KorisnikDetaljiUpdateRequest, KorisnikDetaljiDeleteRequest>, IKorisnikDetaljiService
    {
        public KorisnikDetaljiService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<KorisnikDetalji> AddFilter(IQueryable<KorisnikDetalji> query, KorisnikDetaljiSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.KorisnikDetaljiID.HasValue)
                {
                    query = query.Where(x => x.KorisnikDetaljiID == search.KorisnikDetaljiID.Value);
                }
                if (search.KorisnikID.HasValue)
                {
                    query = query.Where(x => x.KorisnikID == search.KorisnikID.Value);
                }
                if (search.GodinaUpisaID.HasValue)
                {
                    query = query.Where(x => x.GodinaUpisaID == search.GodinaUpisaID.Value);
                }
                if (search.UpisanaSkolskaGodinaID.HasValue)
                {
                    query = query.Where(x => x.UpisanaSkolskaGodinaID == search.UpisanaSkolskaGodinaID.Value);
                }
                if (search.GodinaStudija.HasValue)
                {
                    query = query.Where(x => x.GodinaStudija == search.GodinaStudija.Value);
                }
            }
            return base.AddFilter(query, search);
        }
    }
}
