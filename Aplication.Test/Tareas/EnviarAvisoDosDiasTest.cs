using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aplication.TAREAS;
using Moq;
using Aplication.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplication.Servicios.Tiempo;
using Aplication.Servicios.Notificacion;

namespace Aplication.Test.Tareas
{
    [TestClass]
    public class EnviarAvisoDosDiasTest
    {
        [TestMethod]
        public void EnviarAviso_LLamaAEnviarYGuardaNotificacion()
        {
            //Arrange
            var notificadorMock = new Mock<INotificador>();
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();

            var usuario = new Usuario();

            notificadorMock.Setup(library => library.EnviarGenerico(
                            It.IsAny<string>(), It.IsAny<string>(),
                            usuario))
                .Returns(true);

            dateTimeProviderMock.Setup(library => library.Now)
                .Returns(DateTime.Now);

            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var repositorioVencimientoMock = new Mock<IRepositorioNotificacionVencimientoPrestamo>();

            repositorioVencimientoMock.Setup(
                repo => repo.ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(It.IsAny<DateTime>(), It.IsAny<int>()))
                .Returns(new List<Prestamo>() { new Prestamo()
                {
                    FechaDevolucion = dateTimeProviderMock.Object.Now.AddDays(1),
                    Solicitante = usuario
                } });


            unitOfWorkMock.Setup(unit => unit.RepositorioNotificacionVencimientoPrestamo)
                .Returns(repositorioVencimientoMock.Object);

            var unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();

            unitOfWorkFactoryMock.Setup(library => library.Crear())
                .Returns(unitOfWorkMock.Object);

            var tarea = new TareaEnviarAvisoADosDiasVencimiento(
                                new List<INotificador>() { notificadorMock.Object },
                                unitOfWorkFactoryMock.Object,
                                dateTimeProviderMock.Object);

            //Act
            tarea.Execute(null);

            //Assert 
            notificadorMock.Verify(library => library.EnviarGenerico(
                            It.IsAny<string>(),
                            It.IsAny<string>(), usuario), Times.Exactly(1));

            repositorioVencimientoMock.Verify(repo => repo.Agregar(It.IsAny<NotificacionVencimientoPrestamo>()), Times.Exactly(1));

            unitOfWorkFactoryMock.Verify(repo => repo.Crear(), Times.Exactly(1));
        }
    }
}
