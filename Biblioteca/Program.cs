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

            // TODO: Hacer una lista que tengas estas tareas y las detenga cuando se cierra la app
            var tarea = new TareaEnviarAvisoADosDiasVencimiento(TimeSpan.FromSeconds(5));
            tarea.Iniciar();

            Fachada fachada = new Fachada();
            fachada.Inicializar();

            Application.Run(new Inicio());

           
        }
    }
}
