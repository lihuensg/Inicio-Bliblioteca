using Aplication;
using Aplication.Servicios.Tiempo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Aplication.Test.Dominio.PrestamoTest
{
    [TestClass]
    public class PrestamoCrearTest
    {
        readonly Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>();

        [TestInitialize]
        public void TestSetup()
        {
            dateTimeProvider.Setup(x => x.Now).Returns(DateTime.Now);
        }

        [TestMethod]
        public void Crear_SeteaFechaVencimiento_Correctamente()
        {
            // Arrange
            var usuario = new Usuario();
            usuario.Puntaje = 0;

            // Act
            var prestamo = Prestamo.Crear(usuario, new Ejemplar(), dateTimeProvider.Object);

            // Assert
            DateTime esperada = dateTimeProvider.Object.Now.AddDays(Constantes.Prestamo.DiasBaseDePrestamo);
            Assert.AreEqual(esperada, prestamo.FechaVencimiento);
        }
    }
}
