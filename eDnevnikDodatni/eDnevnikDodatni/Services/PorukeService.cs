using AutoMapper;
using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Services
{
    public class PorukeService : IPorukeService
    {
        private readonly eDnevnikDBContext _context;
        private readonly IMapper _mapper;

        public PorukeService(eDnevnikDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Poruke>> Get(PorukeSearchObject searchObject)
        {
            var query = _context.Poruke.AsQueryable();

            var poruke = await query.ToListAsync();
            return _mapper.Map<List<Poruke>>(poruke);
        }

        public async Task<Poruke> GetById(int id)
        {
            var poruke = await _context.Poruke.FindAsync(id);
            return _mapper.Map<Poruke>(poruke);
        }
        public async Task<eDnevnik.Model.Models.Poruke> Post(PorukaInsertRequest request)
        {
            var poruke = new eDnevnik.Services.Database.Poruke
            {
                ProfesorID = request.ProfesorID,
                UcenikID = request.UcenikID,
                SadrzajPoruke = request.SadrzajPoruke,
                DatumSlanja = request.DatumSlanja,
            };

            _context.Poruke.Add(poruke);
            await _context.SaveChangesAsync();

            return _mapper.Map<Poruke>(poruke);
        }
    }
}
