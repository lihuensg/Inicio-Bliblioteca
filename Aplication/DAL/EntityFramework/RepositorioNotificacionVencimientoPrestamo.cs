using Aplication.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioNotificacionVencimientoPrestamo : Repository<NotificacionVencimientoPrestamo, BibliotecaDbContext>, IRepositorioNotificacionVencimientoPrestamo
    {
        public RepositorioNotificacionVencimientoPrestamo(BibliotecaDbContext pDbContext) : base(pDbContext)
        {
        }

        public IList<Prestamo> ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(DateTime fechaActual, int diasAntelacion)
        {
            DateTime limite = fechaActual.AddDays(diasAntelacion);

            // Select * from prestamos join vencimientoNotificacion on (idPrestamos = idNotVencimiento.Prestamo)
            // where prestamos.fechaVencimiento < hoy - 2 and 

            return (from p in iDbContext.Prestamos
                    join nv in iDbContext.NotificacionVencimientoPrestamos
                    on p.Id equals nv.Prestamo.Id into temp
                    from nv in temp.DefaultIfEmpty()
                    where p.FechaVencimiento <= limite && (nv == null || nv.DiasAnteracion != diasAntelacion)
                    select p).ToList();
        }
    }
}