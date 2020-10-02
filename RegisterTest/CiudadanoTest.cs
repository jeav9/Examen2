using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroWebApi.Core.DomainServices;
using RegistroWebApi.Models;
using System.Collections.Generic;

namespace RegisterTest
{
    [TestClass]
    public class CiudadanoTest
    {
        [TestMethod]
        public void ValidarLongitudDeId()
        {
            // AAA
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudadanoDomainService = new CiudadanosDomainService();
            ciudadano.IdCiudadano = "123456789";
            var ciudadanos = new List<Ciudadano>();
            // Act
            var result = ciudadanoDomainService.PuedeCrearCiudadano(ciudadanos, ciudadano);
            // Assert
            Assert.AreEqual("El idCiudadano debe tener 13 caracteres", result);
        }

        [TestMethod]
        public void ValidarSiExiste()
        {
            // AAA
            // Arrange
            var ciudadanoDomainService = new CiudadanosDomainService();

            var ciudadano = new Ciudadano();
            ciudadano.IdCiudadano = "0501199713370";

            var ciudadanos = new List<Ciudadano>();
            ciudadanos.Add(new Ciudadano { IdCiudadano = "0501199713370" });
            // Act
            var result = ciudadanoDomainService.PuedeCrearCiudadano(ciudadanos, ciudadano);
            // Assert
            Assert.AreEqual("El ciudadano ya existe", result);
        }

        [TestMethod]
        public void ValidarIdCiudadanoRequerido()
        {
            // AAA
            // Arrange
            var ciudadanoDomainService = new CiudadanosDomainService();

            var ciudadano = new Ciudadano();

            // Act
            var result = ciudadanoDomainService.ValidarCamposRequeridos(ciudadano);

            // Assert
            Assert.AreEqual("El campo IdCiudadano es requerido", result);
        }

        [TestMethod]
        public void PasarValidacionesCiudadano()
        {
            // AAA
            // Arrange
            var ciudadanoDomainService = new CiudadanosDomainService();

            var ciudadano = new Ciudadano();
            ciudadano.IdCiudadano = "0501199713370";
            ciudadano.PrimerNombre = "Jorge";
            ciudadano.SegundoNombre = "Eduardo";
            ciudadano.PrimerApellido = "Alvarez";
            ciudadano.SegundoApellido = "Valdez";
            ciudadano.IdCiudad = 1;

            // Act
            var result = ciudadanoDomainService.ValidarCamposRequeridos(ciudadano);

            // Assert
            Assert.IsNull(result);
        }
    }
}
