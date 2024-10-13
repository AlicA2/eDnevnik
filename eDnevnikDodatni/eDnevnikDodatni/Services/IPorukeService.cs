using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IPorukeService
    {
        Task<List<Poruke>> Get(PorukeSearchObject searchObject);
        Task<Poruke> GetById(int id);
        Task<Poruke> Post(PorukaInsertRequest request);
    }
}
