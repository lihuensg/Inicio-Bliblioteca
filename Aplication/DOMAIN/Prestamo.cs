using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class Prestamo
    {
        public Prestamo(int pId,DateTime pFechaPrestamo, DateTime pFechaVencimiento, Ejemplar pEjemplar, Usuario pSolicitante) 
        {
            Id = pId;
            FechaPrestamo = pFechaPrestamo;
            FechaVencimiento = pFechaVencimiento;
            Ejemplar = pEjemplar;
            Solicitante = pSolicitante;
        }
        public Prestamo()
        {
            
        }
    
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public virtual Usuario Solicitante { get; set; }

        public virtual Ejemplar Ejemplar { get; set; }
    }
}