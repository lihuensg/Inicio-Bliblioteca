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

        public void DevolverEjemplar(bool buenEstado)
        {
             if (!buenEstado)
                {
                    Solicitante.Puntaje -= 10;
                }

             if (DateTime.Now > this.FechaVencimiento)
                {
                    Solicitante.Puntaje -= 2 * (int)(DateTime.Now - this.FechaVencimiento).TotalDays;
                }

             if (buenEstado && this.FechaVencimiento > DateTime.Now)
                {
                    Solicitante.Puntaje += 5;
                }
        }
    
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public virtual Usuario Solicitante { get; set; }

        public virtual Ejemplar Ejemplar { get; set; }
    }
}