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

namespace Inicio_Bliblioteca
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogManager.initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: Hacer una lista que tengas estas tareas y las detenga cuando se cierra la app
            var notificadorMail = new NotificadorMail(Properties.Settings.Default.CorreoAvisosMail, Properties.Settings.Default.CorreoAvisosServer, Properties.Settings.Default.CorreoAvisosPuerto, Properties.Settings.Default.CorreoAvisosUsaSSL, Properties.Settings.Default.CorreoAvisosUsuario, Properties.Settings.Default.CorreoAvisosContraseña);
            var tarea = new TareaEnviarAvisoADosDiasVencimiento(TimeSpan.FromSeconds(5), notificadorMail, new UnitOfWorkFactory());
            tarea.Iniciar();

            Fachada fachada = new Fachada();
            fachada.Inicializar();

            OpenLibraryServiceFactory factory = new OpenLibraryServiceFactory();
            LibraryServiceFactory.SetearProveedor(factory);

            Application.Run(new Inicio());
        }
    }
}
