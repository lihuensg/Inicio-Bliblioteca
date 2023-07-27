using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class NotificacionVencimientoPrestamo
    {
        public int Id { get; set; }
        public virtual Prestamo Prestamo { get; set; }
        public int DiasAnteracion { get; set; }
    }
}