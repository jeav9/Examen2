using Microsoft.EntityFrameworkCore;
using RegistroWebApi.Core.DomainServices;
using RegistroWebApi.DataContext;
using RegistroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroWebApi.Core.DomainManager
{
    public class CiudadManager
    {
        private readonly RegisterDataContext _context;
        private readonly CiudadDomainService _ciudadDomainService;
        public CiudadManager(RegisterDataContext context,
            CiudadDomainService ciudadDomainService)
        {
            _context = context;
            _ciudadDomainService = ciudadDomainService;

            if(_context.Ciudades.Count() == 0)
            {
                _context.Ciudades.Add(new Ciudad { Nombre = "SPS", Descripcion = "Capital Industrial" });
                _context.Ciudades.Add(new Ciudad { Nombre = "TGU", Descripcion = "Capital del País" });
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades.Include(s => s.Ciudadanos).ToListAsync();
        }

        public async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context.Ciudades.Include(s => s.Ciudadanos).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<string> Create(Ciudad ciudad)
        {
            var ciudades = await GetAllAsync();
            var ciudadResult = _ciudadDomainService.PuedeCrearCiudad(ciudades, ciudad.Nombre);

            if (ciudadResult != null) return ciudadResult;

            await _context.Ciudades.AddAsync(ciudad);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<string> Update(Ciudad ciudad)
        {
            _context.Entry(ciudad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<string> Delete(int id)
        {
            var ciudad = await GetByIdAsync(id);
            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
