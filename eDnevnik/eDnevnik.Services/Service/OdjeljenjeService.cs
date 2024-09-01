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
    public class OdjeljenjeService : BaseCRUDService<Model.Models.Odjeljenje, Database.Odjeljenje, OdjeljenjeSearchObject, OdjeljenjeInsertRequest, OdjeljenjeUpdateRequest, OdjeljenjeDeleteRequest>, IOdjeljenjeService
    {
        private readonly eDnevnikDBContext _context;
        private readonly IMapper _mapper;

        public OdjeljenjeService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<bool> AddStudentToDepartment(int odjeljenjeID, int korisnikID)
        {
            var odjeljenje = await _context.Odjeljenje
                .Include(o => o.Ucenici)
                .FirstOrDefaultAsync(o => o.OdjeljenjeID == odjeljenjeID);

            if (odjeljenje == null)
            {
                throw new ArgumentException("Odjeljenje not found.");
            }

            var student = await _context.Korisnici
                .Include(k => k.KorisniciUloge)
                .FirstOrDefaultAsync(k => k.KorisnikID == korisnikID &&
                                           k.KorisniciUloge.Any(ku => ku.UlogaID == 2));

            if (student == null)
            {
                throw new ArgumentException("Student not found or the user is not a student.");
            }

            if (odjeljenje.Ucenici.Any(u => u.KorisnikID == korisnikID))
            {
                throw new InvalidOperationException("Student is already in this department.");
            }

            odjeljenje.Ucenici.Add(student);
            await _context.SaveChangesAsync();

            return true;
        }
        public override IQueryable<Odjeljenje> AddFilter(IQueryable<Odjeljenje> query, OdjeljenjeSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.NazivOdjeljenja))
                {
                    query = query.Where(x => x.NazivOdjeljenja.StartsWith(search.NazivOdjeljenja));
                }
                if (!string.IsNullOrWhiteSpace(search.FTS))
                {
                    query = query.Where(x => x.NazivOdjeljenja.Contains(search.NazivOdjeljenja));
                }
                if (search.SkolaID.HasValue)
                {
                    query = query.Where(x => x.SkolaID == search.SkolaID.Value);
                }
                if (search.OdjeljenjeID.HasValue)
                {
                    query = query.Where(x => x.OdjeljenjeID == search.OdjeljenjeID.Value);
                }
            }
            return base.AddFilter(query, search);
        }
        public override IQueryable<Odjeljenje> AddInclude(IQueryable<Odjeljenje> query, OdjeljenjeSearchObject? search = null)
        {
            if (search?.isUceniciIncluded == true)
            {
                query = query.Include("Ucenici");
            }
            return base.AddInclude(query, search);
        }

        public async Task<bool> RemoveStudentFromDepartment(int odjeljenjeID, int korisnikID)
        {
            var odjeljenje = await _context.Odjeljenje
                .Include(o => o.Ucenici)
                .FirstOrDefaultAsync(o => o.OdjeljenjeID == odjeljenjeID);

            if (odjeljenje == null)
            {
                throw new ArgumentException("Odjeljenje not found.");
            }

            var student = odjeljenje.Ucenici.FirstOrDefault(u => u.KorisnikID == korisnikID);

            if (student == null)
            {
                throw new ArgumentException("Student not found in this department.");
            }

            odjeljenje.Ucenici.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }

        public override async Task<Model.Models.Odjeljenje> Delete(int id, OdjeljenjeDeleteRequest request)
        {
            var odjeljenje = await _context.Odjeljenje
                .Include(o => o.Ucenici)
                .Include(o => o.OdjeljenjePredmeti)
                .FirstOrDefaultAsync(o => o.OdjeljenjeID == id);

            if (odjeljenje == null)
            {
                throw new ArgumentException("Odjeljenje nije pronađeno.");
            }

            if (odjeljenje.Ucenici.Any())
            {
                throw new UserException("Ne možete izbrisati odjeljenje koje ima dodjeljene učenike.");
            }

            if (odjeljenje.OdjeljenjePredmeti.Any())
            {
                throw new UserException("Ne možete izbrisati odjeljenje koje ima dodjeljene predmete.");
            }

            _context.Odjeljenje.Remove(odjeljenje);
            await _context.SaveChangesAsync();

            var model = _mapper.Map<Model.Models.Odjeljenje>(odjeljenje);
            return model;
        }
    }
}
