using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Servicios.Notificacion;
using TallerBiblioteca.Infrastructure;
using TallerBiblioteca.Infrastructure.Notificacion;

namespace TallerBiblioteca.WindowsForms
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var sistema = ServiceProvider.GetRequiredService<InicioSistema>();
            sistema.Inicio();

            TallerBiblioteca.Aplication.Log.LogManager.Initialize();


            var hostTaskTokenSrc = new CancellationTokenSource();
            var hostTask = host.RunAsync(hostTaskTokenSrc.Token);

            Application.Run(ServiceProvider.GetRequiredService<Login>());
            hostTaskTokenSrc.Cancel();
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AgregarAplicacion()
                            .AgregarInfrastructura();

                    // agregar forms y usercontrols, que no sean abstractos
                    var forms = typeof(Login).Assembly
                        .GetTypes()
                        .Where(x => x.IsSubclassOf(typeof(Form)) || x.IsSubclassOf(typeof(UserControl)))
                        .Where(x => !x.IsAbstract);

                    foreach (var form in forms)
                    {
                        services.AddTransient(form);
                    }

                    services.AddTransient<INotificador, NotificadorMail>((s) =>
                            new NotificadorMail(Properties.Settings.Default.CorreoAvisosMail,
                                                Properties.Settings.Default.CorreoAvisosServer,
                                                Properties.Settings.Default.CorreoAvisosPuerto,
                                                Properties.Settings.Default.CorreoAvisosUsaSSL,
                                                Properties.Settings.Default.CorreoAvisosUsuario,
                                                Properties.Settings.Default.CorreoAvisosContraseña));
                });
        }
    }
}
