using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplication;

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
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NotificadorMail notificadorMail = new NotificadorMail(Properties.Settings.Default.CorreoAvisosMail, Properties.Settings.Default.CorreoAvisosServer, Properties.Settings.Default.CorreoAvisosPuerto, Properties.Settings.Default.CorreoAvisosUsaSSL, Properties.Settings.Default.CorreoAvisosUsuario, Properties.Settings.Default.CorreoAvisosContraseña);
            if (notificadorMail.Enviar("u.enzoaguirre@gmail.com", "Prueba", "Confirmacion de prestamo", "Hola esto es una confirmacion de que pediste prestado 123345 libros y no devolviste ninguno")) {
                MessageBox.Show("Enviado");
            } else {
                MessageBox.Show("No se pudo enviar");
            }
            Application.Run(new Inicio());
        }
    }
}
