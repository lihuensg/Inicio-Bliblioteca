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
            NotificadorMail notificadorMail = new NotificadorMail("bibliotecautnfrcu@gmail.com","Bibliotecautnfrcu01",465,true,"Biblioteca UTN FRCU");
            notificadorMail.Enviar("bibliotecautnfrcu@gmail.com","Confirmacion de prestamo","Hola esto es una confirmacion de que pediste prestado 123345 libros y no devolviste ninguno");
            Application.Run(new Inicio());
        }
    }
}
