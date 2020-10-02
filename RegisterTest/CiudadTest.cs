using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroWebApi.Core.DomainServices;
using RegistroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterTest
{
    [TestClass]
    public class CiudadTest
    {
        [TestMethod]
        public void ValidarSiExisteCiudad()
        {
            // AAA
            // Arrange
            var ciudadDomainService = new CiudadDomainService();
            var ciudad = new Ciudad { Nombre = "SPS" };
            var ciudades = new List<Ciudad>();
            ciudades.Add(ciudad);

            // Act
            var resultado = ciudadDomainService.PuedeCrearCiudad(ciudades, ciudad.Nombre);

            // Assert
            Assert.AreEqual("El Nombre de la ciudad ya existe", resultado);
        }
    }
}
