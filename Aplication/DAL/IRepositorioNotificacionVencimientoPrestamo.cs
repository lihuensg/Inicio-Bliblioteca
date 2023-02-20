using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IRepositorioNotificacionVencimientoPrestamo : IRepositorio<NotificacionVencimientoPrestamo>
    {
        NotificacionVencimientoPrestamo ObtenerConDiasAntelacion(Prestamo prestamo, int diasAntelacion);
    }
}