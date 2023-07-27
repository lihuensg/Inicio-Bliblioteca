using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplication;
using Aplication.LOG;
using Aplication.TAREAS;
using Aplication.DAL.EntityFramework;
using Aplication.Servicios.LibrosRemotos.OpenLibrary;
using Aplication.Servicios.LibrosRemotos;
using Quartz.Impl;
using Quartz;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using Aplication.Servicios.Notificacion;

namespace Inicio_Bliblioteca
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            LogManager.initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var fachada = ServiceProvider.GetRequiredService<Fachada>();
            fachada.CrearAdminSiNoHayUsuarios();

            var hostTaskTokenSrc = new CancellationTokenSource();
            var hostTask = host.RunAsync(hostTaskTokenSrc.Token);

            Application.Run(ServiceProvider.GetRequiredService<Login>());
            hostTaskTokenSrc.Cancel();

            await hostTask;
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // quartz
                    services.AddQuartz(q =>
                    {
                        q.UseMicrosoftDependencyInjectionJobFactory();

                        q.AddJob<TareaEnviarAvisoADosDiasVencimiento>(opt =>
                                opt.WithIdentity(TareaEnviarAvisoADosDiasVencimiento.Key)
                        ).AddTrigger(opt =>
                        {
                            opt
                                .ForJob(TareaEnviarAvisoADosDiasVencimiento.Key)
                                .WithIdentity(nameof(TareaEnviarAvisoADosDiasVencimiento) + "-trigger")
                                .WithSimpleSchedule(x => x
                                    .WithIntervalInHours(5)
                                    .RepeatForever())
                                .StartNow();
                        });
                    });

                    services.AddQuartzHostedService(q =>
                    {
                        q.WaitForJobsToComplete = true;
                    });

                    // 
                    services.AgregarAplicacion()
                            .AgregarPersistencia()
                            .AgregarLibrosRemotos()
                            .AgregarTiempo();

                    // agregar forms y usercontrols, que no sean abstractos
                    var forms = typeof(Login).Assembly
                        .GetTypes()
                        .Where(x => x.IsSubclassOf(typeof(Form)) || x.IsSubclassOf(typeof(UserControl)))
                        .Where(x => !x.IsAbstract);

                    foreach (var form in forms)
                    {
                        services.AddTransient(form);
                    }

                    // Agregar notificadores
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
