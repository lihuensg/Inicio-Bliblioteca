using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DAL;
using Aplication.DAL.EntityFramework;
using Aplication.LOG;

namespace Aplication.TAREAS {
    public class TareaEnviarAvisoADosDiasVencimiento :  TareaBase {
        NotificadorMail notificadorMail;

        public TareaEnviarAvisoADosDiasVencimiento(TimeSpan intervaloDeVerificacion) {
            this.nombreTarea = "TareaEnviarAvisoADosDiasVencimiento";
            this.intervalo = intervaloDeVerificacion;

            notificadorMail = new NotificadorMail(Properties.Settings.Default.CorreoAvisosMail, Properties.Settings.Default.CorreoAvisosServer, Properties.Settings.Default.CorreoAvisosPuerto, Properties.Settings.Default.CorreoAvisosUsaSSL, Properties.Settings.Default.CorreoAvisosUsuario, Properties.Settings.Default.CorreoAvisosContraseña);
        }
        
        protected override void Tarea() {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext())) {
                //  1. Obtener los prestamos que esten a 2 dias a vencer (definido en una cte)
                //     y que no se les haya enviado el mail de aviso de vencimiento
                var resultado = bUoW.RepositorioNotificacionVencimientoPrestamo.ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(2);

                LogManager.GetLogger().Debug($"[TareaEnviarAvisoADosDiasVencimiento] Mails a enviar: {resultado.Count}");

                //  2. Enviar el mail para cada uno
                foreach (var prestamo in resultado) {
                    if (notificadorMail.Enviar(prestamo.Solicitante.Mail, " ", "Vencimiento de prestamo", "Tu prestamos esta proximo a vencer a 2 dias")) {
                        LogManager.GetLogger().Info("[TareaEnviarAvisoADosDiasVencimiento] Enviado el mail de vencimiento");

                        //  3. Si fue exitoso: Actualizar el prestamo, indicando que ya se envió el mail.
                        NotificacionVencimientoPrestamo notificacionVencimientoPrestamo = new NotificacionVencimientoPrestamo {
                            DiasAnteracion = 2,
                            Prestamo = prestamo
                        };

                        bUoW.RepositorioNotificacionVencimientoPrestamo.Agregar(notificacionVencimientoPrestamo);
                    } else {
                        //  4. Sino, seguir con el siguiente.
                        LogManager.GetLogger().Warn("No se puedo envir el mail");
                    }
                }

                bUoW.Complete();
            }
        }
    }
}
