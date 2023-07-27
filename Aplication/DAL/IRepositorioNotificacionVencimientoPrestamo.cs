using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL
{
    public interface IRepositorioNotificacionVencimientoPrestamo : IRepositorio<NotificacionVencimientoPrestamo>
    {
        /// <summary>
        /// Obtiene aquellos prestamos a los cuales no se les han enviado una notificacion
        /// de por lo menos `diasAntelacion` dias y este a `diasAntelacion` dias de vencer.
        /// </summary>
        /// <param name="fechaActual"></param>
        /// <param name="diasAntelacion"></param>
        /// <returns></returns>
        IList<Prestamo> ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(DateTime fechaActual, int diasAntelacion);
    }
}