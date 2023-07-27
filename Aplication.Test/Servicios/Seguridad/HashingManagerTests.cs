using Aplication.Servicios.Seguridad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aplication.Test.Servicios.Seguridad
{
    [TestClass]
    public class HashingManagerTests
    {
        [DataTestMethod]
        [DataRow("1234")]
        [DataRow("")]
        [DataRow("a b c")]
        [DataRow("a $$ # b c 1234")]
        public void HasheaCorrectamente(string password)
        {
            // Arrange
            HashingManager hashingManager = new HashingManager();

            // Act
            string hash = hashingManager.Hash(password);

            // Assert
            Assert.IsTrue(hashingManager.Verify(password, hash));
        }
    }
}
