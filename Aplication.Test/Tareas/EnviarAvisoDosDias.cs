using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aplication.TAREAS;
using Moq;
using Aplication.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Test.Tareas
{
    [TestClass]
    public class EnviarAvisoDosDias
    {
        public class TareaEnviarAvisoADosDiasVencimientoMock : TareaEnviarAvisoADosDiasVencimiento
        {
            public TareaEnviarAvisoADosDiasVencimientoMock(TimeSpan intervaloDeVerificacion, INotificador notificador, IUnitOfWorkFactory pUnitOfWorkFactory) : base(intervaloDeVerificacion, notificador, pUnitOfWorkFactory)
            {

            }

            public void ejecutar()
            {
                base.Tarea();
            }
        }
        [TestMethod]
        public async Task EnviarAviso_LLamaAEnviarYGuardaNotificacion()
        {
            //Arrange
            var notificadorMock = new Mock<INotificador>();

            var usuarioMock = new Mock<Usuario>();
            usuarioMock.SetupGet(u => u.Mail).Returns("juan@gmail.com");

            notificadorMock.Setup(library => library.EnviarGenerico(
                            It.IsAny<string>(), It.IsAny<string>(),
                            usuarioMock.Object))
                .Returns(true);

            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var repositorioVencimientoMock = new Mock<IRepositorioNotificacionVencimientoPrestamo>();

            repositorioVencimientoMock.Setup(repo => repo.ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(It.IsAny<int>()))
                .Returns(new List<Prestamo>() { new Prestamo() {
                    FechaDevolucion = DateTime.Now.AddDays(1),
                    Solicitante = usuarioMock.Object  } });


            unitOfWorkMock.Setup(unit => unit.RepositorioNotificacionVencimientoPrestamo)
                .Returns(repositorioVencimientoMock.Object);

            var unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();

            unitOfWorkFactoryMock.Setup(library => library.Crear())
                .Returns(unitOfWorkMock.Object);


            var tarea = new TareaEnviarAvisoADosDiasVencimientoMock(TimeSpan.FromMinutes(1), notificadorMock.Object, unitOfWorkFactoryMock.Object);

            //Act
            tarea.ejecutar();


            //Assert 
            notificadorMock.Verify(library => library.EnviarGenerico(
                            It.IsAny<string>(),
                            It.IsAny<string>(), usuarioMock.Object), Times.Exactly(1));

            repositorioVencimientoMock.Verify(repo => repo.Agregar(It.IsAny<NotificacionVencimientoPrestamo>()), Times.Exactly(1));

            unitOfWorkFactoryMock.Verify(repo => repo.Crear(), Times.Exactly(1));
        }
    }
}
