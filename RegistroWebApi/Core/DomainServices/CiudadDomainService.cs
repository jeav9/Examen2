using RegistroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroWebApi.Core.DomainServices
{
    public class CiudadDomainService
    {
        public string PuedeCrearCiudad(IEnumerable<Ciudad> ciudades, string nombreDeNuevaCiudad)
        {
            var existe = ciudades.Where(s => nombreDeNuevaCiudad.Equals(s.Nombre));

            if (existe.Any()) return "El Nombre de la ciudad ya existe";

            return null;
        }
    }
}
