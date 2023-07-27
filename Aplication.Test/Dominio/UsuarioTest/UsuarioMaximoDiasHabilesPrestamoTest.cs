﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aplication;
using Aplication.Excepciones;
using Moq;
using Aplication.Servicios.Seguridad;
using Aplication.Servicios.Tiempo;

namespace Aplication.Test.Dominio.UsuarioTest
{
    [TestClass]
    public class UsuarioMaximoDiasHabilesPrestamoTest : UsuarioBaseTests
    {

        [TestMethod]
        public void UsuarioMaximoDiasHabilesPrestamos_Puntaje_0()
        {
            // Arrange
            Usuario usuario = Usuario.Crear(new CrearUsuario()
            {
                Nombre = "Juan",
                Mail = "juan@gmail.com",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            }, hashingManager.Object, dateTimeProvider.Object);

            // Act
            var maximoDiasHabilesPrestamos = usuario.MaximoDiasHabilesPrestamos();

            // Assert
            Assert.AreEqual(Constantes.Prestamo.DiasBaseDePrestamo, maximoDiasHabilesPrestamos);
        }

        [TestMethod]
        public void UsuarioMaximoDiasHabilesPrestamos_Puntaje_DeberiaSer5DiasMas()
        {
            // Arrange
            Usuario usuario = Usuario.Crear(new CrearUsuario()
            {
                Nombre = "Juan",
                Mail = "juan@gmail.com",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            }, hashingManager.Object, dateTimeProvider.Object);

            //usuario.ActualizarPuntaje
            usuario.Puntaje = Constantes.Puntaje.PuntajeNecesarioParaExtenderElPrestamoUnDia * 5;

            // Act
            var maximoDiasHabilesPrestamos = usuario.MaximoDiasHabilesPrestamos();

            // Assert
            Assert.AreEqual(Constantes.Prestamo.DiasBaseDePrestamo + 5, maximoDiasHabilesPrestamos);
        }

        [TestMethod]
        public void UsuarioMaximoDiasHabilesPrestamos_Puntaje_DeberiaNoPasarDelMaximo()
        {
            // Arrange
            Usuario usuario = Usuario.Crear(new CrearUsuario()
            {
                Nombre = "Juan",
                Mail = "juan@gmail.com",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            }, hashingManager.Object, dateTimeProvider.Object);

            usuario.Puntaje = Constantes.Puntaje.PuntajeNecesarioParaExtenderElPrestamoUnDia * 500;

            // Act
            var maximoDiasHabilesPrestamos = usuario.MaximoDiasHabilesPrestamos();

            // Assert
            Assert.AreEqual(Constantes.Prestamo.DiasMaximoDePrestamo, maximoDiasHabilesPrestamos);
        }

        [TestMethod]
        public void UsuarioMaximoDiasHabilesPrestamos_PuntajeNegativo_DeberiaSerBase()
        {
            // Arrange
            Usuario usuario = Usuario.Crear(new CrearUsuario()
            {
                Nombre = "Juan",
                Mail = "juan@gmail.com",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            }, hashingManager.Object, dateTimeProvider.Object);

            usuario.Puntaje = -100;

            // Act
            var maximoDiasHabilesPrestamos = usuario.MaximoDiasHabilesPrestamos();

            // Assert
            Assert.AreEqual(Constantes.Prestamo.DiasBaseDePrestamo, maximoDiasHabilesPrestamos);
        }
    }
}
