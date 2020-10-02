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
    public class CiudadanoManager
    {
        private readonly RegisterDataContext _context;
        private readonly CiudadanosDomainService _ciudadanoDomainService;
        public CiudadanoManager(RegisterDataContext context,
            CiudadanosDomainService ciudadanoDomainService)
        {
            _context = context;
            _ciudadanoDomainService = ciudadanoDomainService;

            if(_context.Ciudadanos.Count() == 0)
            {
                _context.Ciudadanos.Add(new Ciudadano 
                {
                    IdCiudadano = "0501199713370",
                    PrimerNombre = "Jorge",
                    SegundoNombre = "Eduardo",
                    SegundoApellido = "Alvarez",
                    IdCiudad = 1,
                });
                _context.Ciudadanos.Add(new Ciudadano
                {
                    IdCiudadano = "0501199713371",
                    PrimerNombre = "Test",
                    SegundoNombre = "Test",
                    SegundoApellido = "Test",
                    IdCiudad = 2,
                });
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Ciudadano>> GetAllAsync()
        {
            return await _context.Ciudadanos.Include(s => s.Ciudad).ToListAsync();
        }

        public async Task<Ciudadano> GetByIdAsync(int id)
        {
            return await _context.Ciudadanos.Include(s => s.Ciudad).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<string> Create(Ciudadano ciudadano)
        {
            var ciudadanos = await GetAllAsync();

            var requerimientos = _ciudadanoDomainService.ValidarCamposRequeridos(ciudadano);
            if (requerimientos != null) return requerimientos;

            var ciudadanoResult = _ciudadanoDomainService.PuedeCrearCiudadano(ciudadanos, ciudadano);
            if (ciudadanoResult != null) return ciudadanoResult;

            await _context.Ciudadanos.AddAsync(ciudadano);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<string> Update(Ciudadano ciudadano)
        {
            _context.Entry(ciudadano).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<string> Delete(int id)
        {
            var ciudadano = await GetByIdAsync(id);
            _context.Ciudadanos.Remove(ciudadano);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
