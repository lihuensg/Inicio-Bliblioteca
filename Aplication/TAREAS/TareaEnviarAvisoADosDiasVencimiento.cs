using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DAL.EntityFramework;
using Aplication.LOG;

namespace Aplication.TAREAS {
    public class TareaEnviarAvisoADosDiasVencimiento :  TareaBase {
        private readonly BibliotecaDbContext bibliotecaDbContext;
        NotificadorMail notificadorMail;
        public TareaEnviarAvisoADosDiasVencimiento() {
            this.nombreTarea = "TareaEnviarAvisoADosDiasVencimiento";
            this.intervalo = TimeSpan.FromSeconds(5);

            bibliotecaDbContext = new BibliotecaDbContext();
         notificadorMail = new NotificadorMail(Properties.Settings.Default.CorreoAvisosMail, Properties.Settings.Default.CorreoAvisosServer, Properties.Settings.Default.CorreoAvisosPuerto, Properties.Settings.Default.CorreoAvisosUsaSSL, Properties.Settings.Default.CorreoAvisosUsuario, Properties.Settings.Default.CorreoAvisosContraseña);
        }

        protected override void Tarea() {
            // TODO:
            //  1. Obtener los prestamos que esten a X dias a vencer (definido en una cte)
            //     y que no se les haya enviado el mail de aviso de vencimiento
            //  2. Enviar el mail para cada uno
            //  3. Si fue exitoso: Actualizar el prestamo, indicando que ya se envió el mail.
            //  4. Sino, intentar nuevamente sino seguir con el siguiente.

            // Select * from prestamos join vencimientoNotificacion on (idPrestamos = idNotVencimiento.Prestamo)
            // where prestamos.fechaVencimiento < hoy - 2 and 

            DateTime dias = DateTime.Now.AddDays(2);

            var resultado = (
            from p in bibliotecaDbContext.Prestamos
            join nv in bibliotecaDbContext.NotificacionVencimientoPrestamos
            on p.Id equals nv.Prestamo.Id into temp
            from nv in temp.DefaultIfEmpty()
            where p.FechaVencimiento <= dias && nv == null || nv.DiasAnteracion != 2
            select p).ToList();

            foreach (var prestamo in resultado)
            {

                if (notificadorMail.Enviar(prestamo.Solicitante.Mail, " ", "Vencimiento de prestamo", "Tu prestamos esta proximo a vencer a 2 dias"))
                {
                    LogManager.GetLogger().Info("Enviado el mail de vencimiento");
                }
                else
                {
                    LogManager.GetLogger().Warn("No se puedo envir el mail");
                }

                NotificacionVencimientoPrestamo notificacionVencimientoPrestamo = new NotificacionVencimientoPrestamo
                {
                    DiasAnteracion = 2,
                    Prestamo = prestamo
                };

                bibliotecaDbContext.NotificacionVencimientoPrestamos.Add(notificacionVencimientoPrestamo);
            }

            bibliotecaDbContext.SaveChanges();
        }
    }
}
