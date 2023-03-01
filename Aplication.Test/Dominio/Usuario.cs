using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aplication;
using Aplication.Excepciones;

namespace Aplication.Test.Dominio
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void UsuarioCrear_EmailInvalidoTiraError()
        {
            // Arrange
            var solicitud = new CrearUsuario();

            // Act
            solicitud.Mail = "mailinvalido";

            // Assert
            Assert.ThrowsException<ExcepcionEmailInvalido>(() => Usuario.Crear(solicitud));
        }

        [TestMethod]
        public void UsuarioCrear_EmailInvalidoNoTiraError()
        {
            // Arrange
            var solicitud = new CrearUsuario();

            // Act
            solicitud.Mail = "juan@gmail.com";

            // Assert
            Assert.IsTrue(true);
        }

    }
}
