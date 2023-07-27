using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Servicios.Tiempo;

namespace Aplication
{
    public class Prestamo
    {
        public void DevolverEjemplar(bool buenEstado, IDateTimeProvider dateTimeProvider)
        {
            if (!buenEstado)
            {
                Solicitante.Puntaje += Constantes.Puntaje.PuntajePorEjemplarEnMalasCondiciones;
            }

            if (dateTimeProvider.Now > this.FechaVencimiento)
            {
                int diasDeMora = (int)(dateTimeProvider.Now - this.FechaVencimiento).TotalDays;
                Solicitante.Puntaje += Constantes.Puntaje.PuntajePorEjemplarFueraDePlazoPorDiaDeMora
                                       * diasDeMora;
            }

            if (buenEstado && this.FechaVencimiento > dateTimeProvider.Now)
            {
                Solicitante.Puntaje += Constantes.Puntaje.PuntajePorEjemplarDevueltoCorrectamente;
            }

            this.FechaDevolucion = dateTimeProvider.Now;
        }

        public static Prestamo Crear(Usuario pSolicitante,
                                     Ejemplar pEjemplar,
                                     IDateTimeProvider pDateTimeProvider)
        {
            DateTime now = pDateTimeProvider.Now;

            var fechaVencimiento = now.AddDays(pSolicitante.MaximoDiasHabilesPrestamos());

            Prestamo prestamo = new Prestamo
            {
                FechaPrestamo = now,
                FechaVencimiento = fechaVencimiento,
                Solicitante = pSolicitante,
                Ejemplar = pEjemplar,
            };

            return prestamo;
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