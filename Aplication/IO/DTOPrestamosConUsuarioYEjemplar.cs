using System;

namespace Aplication
{
    public class DTOPrestamoConUsuarioYEjemplar
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Nombre { get; set; }
        public string CodigoInventario { get; set; }
        public DateTime FechaVencimiento { get; set; }

    }
}