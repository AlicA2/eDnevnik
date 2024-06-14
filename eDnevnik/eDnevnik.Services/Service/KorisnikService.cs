using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace eDnevnik.Services.Service
{
    public class KorisnikService : BaseService<Model.Models.Korisnik, Database.Korisnik, KorisnikSearchObject>, IKorisnikService
    {
        public KorisnikService(eDnevnikDBContext context, IMapper mapper)
            :base(context, mapper)
        {
 
        }
        public override IQueryable<Korisnik> AddFilter(IQueryable<Korisnik> query, KorisnikSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(search.Ime));
            }
            if (!string.IsNullOrWhiteSpace(search.FTS))
            {
                query = query.Where(x => x.Ime.Contains(search.Ime));
            }

            return base.AddFilter(query, search);
        }



        //public Model.Models.Korisnik Insert(KorisniciInsertRequest request)
        //{
        //    var entity = new Korisnik();
        //    _mapper.Map(request, entity);

        //    entity.LozinkaSalt = GenerateSalt();
        //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

        //    _context.Korisnici.Add(entity);
        //    _context.SaveChanges();

        //    return _mapper.Map<Model.Models.Korisnik>(entity);
        //}
        //public static string GenerateSalt()
        //{
        //    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        //    var byteArray = new byte[16];
        //    provider.GetBytes(byteArray);

        //    return Convert.ToBase64String(byteArray);
        //}
        //public static string GenerateHash(string salt, string password)
        //{
        //    byte[] src = Convert.FromBase64String(salt);
        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] dst = new byte[src.Length + bytes.Length];

        //    System.Buffer.BlockCopy(src, 0,dst, 0, src.Length);
        //    System.Buffer.BlockCopy(bytes,0,dst,src.Length, bytes.Length);

        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    return Convert.ToBase64String(inArray);
        //}

        //public Model.Models.Korisnik Update(int id, KorisniciUpdateRequest request)
        //{
        //    var entity = _context.Korisnici.Find(id);

        //    _mapper.Map(request, entity);

        //    _context.SaveChanges();
        //    return _mapper.Map<Model.Models.Korisnik>(entity);
        //}
    }
}
