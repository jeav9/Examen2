using RegistroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroWebApi.Core.DomainServices
{
    public class CiudadanosDomainService
    {
        public string PuedeCrearCiudadano(IEnumerable<Ciudadano> ciudadanos, Ciudadano ciudadano)
        {
            if (!ValidarId(ciudadano.IdCiudadano)) return "El idCiudadano debe tener 13 caracteres";
            var existe = ciudadanos.Where(s => s.IdCiudadano == ciudadano.IdCiudadano);
            if (existe.Any()) return "El ciudadano ya existe";
            return null;
        }

        public string ValidarCamposRequeridos(Ciudadano ciudadano)
        {
            if (ciudadano.IdCiudadano == null) return "El campo IdCiudadano es requerido";

            if (ciudadano.PrimerNombre == null) return "El campo PrimerNombre es requerido";

            if (ciudadano.SegundoNombre == null) return "El campo SegundoNombre es requerido";

            if (ciudadano.PrimerApellido == null) return "El campo PrimerApellido es requerido";

            if (ciudadano.SegundoApellido == null) return "El campo SegundoApellido es requerido";

            if (ciudadano.IdCiudad == 0) return "El campo IdCiudad es requerido";

            return null;
        }

        private bool ValidarId(string id)
        {
            if (id.Length != 13) return false;
            return true;
        }
    }
}
