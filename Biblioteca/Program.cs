using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplication;
using Aplication.LOG;
using Aplication.TAREAS;

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
            NotificadorMail notificadorMail = new NotificadorMail(Properties.Settings.Default.CorreoAvisosMail, Properties.Settings.Default.CorreoAvisosServer, Properties.Settings.Default.CorreoAvisosPuerto, Properties.Settings.Default.CorreoAvisosUsaSSL, Properties.Settings.Default.CorreoAvisosUsuario, Properties.Settings.Default.CorreoAvisosContraseña);
            if (notificadorMail.Enviar("u.enzoaguirre@gmail.com", "Prueba", "Confirmacion de prestamo", "Hola esto es una confirmacion de que pediste prestado 123345 libros y no devolviste ninguno")) {
                MessageBox.Show("Enviado");
            } else {
                MessageBox.Show("No se pudo enviar");
            }

            // TODO: Hacer una lista que tengas estas tareas y las detenga cuando se cierra la app
            var tarea = new TareaEnviarAvisoADosDiasVencimiento();
            tarea.Iniciar();

            Application.Run(new Inicio());
        }
    }
}
