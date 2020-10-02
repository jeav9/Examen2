using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroWebApi.Models
{
    public class Ciudadano
    {
        [Key]
        public int Id { get; set; }
        public string IdCiudadano { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FotoDeCiudadano { get; set; }
        public string NumeroDeTelefono { get; set; }
        [ForeignKey("Ciudad")]
        public int IdCiudad { get; set; }
        public virtual Ciudad Ciudad { get; set; }
    }
}
