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
    public class KorisnikService : BaseCRUDService<Model.Models.Korisnik, Database.Korisnik, KorisnikSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest, KorisniciDeleteRequest>, IKorisnikService
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
            if (search?.UlogaID.HasValue == true)
            {
                query = query.Where(x => x.KorisniciUloge.Any(ku => ku.UlogaID == search.UlogaID.Value));
            }
            if (search.OdjeljenjeID.HasValue)
            {
                query = query.Where(x => x.OdjeljenjeID == search.OdjeljenjeID.Value);
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

        public async Task<Model.Models.Korisnik> Login(string username, string password)
        {
            var entity =await _context.Korisnici.Include("KorisniciUloge.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return _mapper.Map<Model.Models.Korisnik>(entity);

        }

        public async Task<bool> VerifyOldPassword(int id, string oldPassword)
        {
            var entity = await _context.Korisnici.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("Korisnik nije pronađen");
            }

            var hash = GenerateHash(entity.LozinkaSalt, oldPassword);

            return hash == entity.LozinkaHash;
        }


        public async Task<int?> GetLoged(string username, string password)
        {
            var entity = await _context.Korisnici.FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return entity.KorisnikID;
        }
        public async Task<(int? korisnikId, string uloga)> GetLogedWithRole(string username, string password)
        {
            var entity = await _context.Korisnici
                .Include(x => x.KorisniciUloge)
                .ThenInclude(x => x.Uloga)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return (null, null);
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return (null, null);
            }

            var uloga = entity.KorisniciUloge.FirstOrDefault()?.Uloga.Naziv;

            return (entity.KorisnikID, uloga);
        }

        public async Task UpdatePasswordAndUsername(int id, KorisniciUpdateRequestLimited request)
        {
            var entity = await _context.Korisnici.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("Korisnik nije pronađen");
            }

            entity.KorisnickoIme = request.KorisnickoIme;

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}