using Aplication.DAL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.Hosting;
using Moq;
using Aplication.Servicios.Tiempo;
using Aplication.DAL;
using Aplication.Servicios.Seguridad;
using Aplication.LOG;
using System.Threading;

namespace Aplication.IntegrationTests
{
    public class CasoDeUsoTestBase
    {
        public static object mutex = new object();

        private IServiceScopeFactory _scopeFactory;

        protected IServiceProvider ScopedServiceProvider => _scopeFactory.CreateScope().ServiceProvider;

        protected BibliotecaDbContext DbContext => _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<BibliotecaDbContext>();

        protected IUnitOfWorkFactory UnitOfWorkFactory => _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWorkFactory>();

        protected Fachada Fachada => _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<Fachada>();

        protected Mock<IDateTimeProvider> DateTimeProviderMock = new Mock<IDateTimeProvider>();

        [TestInitialize]
        public void TestSetup()
        {
            Monitor.Enter(mutex);

            LogManager.initialize();

            DateTimeProviderMock.Setup(x => x.Now).Returns(DateTime.Now);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AgregarAplicacion()
                            .AgregarLibrosRemotos()
                            .AgregarPersistencia();

                    services.AddSingleton(DateTimeProviderMock.Object);
                }).Build();

            _scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

            DbContext.Database.Delete();
            DbContext.Database.CreateIfNotExists();

            Fachada.CrearAdminSiNoHayUsuarios();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Monitor.Exit(mutex);
        }

        protected Usuario GenerarUsuario(int dni)
        {
            Usuario usuario = Usuario.Crear(new CrearUsuario()
            {
                Dni = dni,
                Nombre = "pepe",
                EsAdminitrador = false,
                Mail = dni + "@gmail.com",
                Password = "123456"
            }, new HashingManager(), DateTimeProviderMock.Object);

            return usuario;
        }

        protected Edicion GenerarEdicion(string isbn)
        {
            var edicion = new Edicion()
            {
                Titulo = "titulo",
                Isbn = isbn,
                AñoEdicion = 1990,
                Publicacion = "editorial",
                Autores = "autor",
                DatosAdicionales = "",
                Descripcion = "",
                NumeroPaginas = 1,
                Portada = "portada",
            };

            return edicion;
        }

        protected Ejemplar GenerarEjemplar(Edicion edicion)
        {
            var ejemplar = new Ejemplar()
            {
                Edicion = edicion,
                FechaAlta = DateTimeProviderMock.Object.Now,
            };

            return ejemplar;
        }
    }
}