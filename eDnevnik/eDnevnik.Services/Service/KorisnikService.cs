using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.Helpers;
using eDnevnik.Services.IServices;
using eDnevnik.Services.KorisnikStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace eDnevnik.Services.Service
{
    public class KorisnikService : BaseCRUDService<Model.Models.Korisnik, Database.Korisnik, KorisnikSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisnikService
    {
        public BaseState _baseState { get; set; }
        public KorisnikService(BaseState baseState, eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState = baseState;
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

        public override async Task BeforeInsert(Database.Korisnik entity, KorisniciInsertRequest insert)
        {
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, insert.Password);
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override IQueryable<Korisnik> AddInclude(IQueryable<Korisnik> query, KorisnikSearchObject? search = null)
        {
            if (search?.isUlogeIncluded == true)
            {
                query = query.Include("KorisniciUloge.Uloga");
            }
            return base.AddInclude(query, search);
        }

        //public override async Task<Model.Models.Korisnik> Insert(KorisniciInsertRequest insert)
        //{
        //    if (insert.Password != insert.PasswordPotvrda)
        //        throw new Exception("Passwords do not match.");

        //    var (hash, salt) = PasswordHelper.CreatePasswordHash(insert.Password);

        //    var entity = new Korisnik
        //    {
        //        Ime = insert.Ime,
        //        Prezime = insert.Prezime,
        //        Email = insert.Email,
        //        Telefon = insert.Telefon,
        //        KorisnickoIme = insert.KorisnickoIme,
        //        Status = insert.Status,
        //        StateMachine = "initial",
        //        LozinkaHash = hash,
        //        LozinkaSalt = salt
        //    };

        //    _context.Korisnici.Add(entity);
        //    await _context.SaveChangesAsync();

        //    var model = _mapper.Map<Model.Models.Korisnik>(entity);

        //    return model;
        //}

        //public override async Task<Model.Models.Korisnik> Update(int id, KorisniciUpdateRequest update)
        //{
        //    var entity = await _context.Korisnici.FindAsync(id);
        //    var state = _baseState.CreateState(entity.StateMachine);
        //    return await state.Update(id, update);
        //}

    }
}