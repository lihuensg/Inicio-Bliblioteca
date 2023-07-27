using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Servicios.Tiempo;

namespace Aplication
{
    public class Ejemplar
    {
        public int Id { get; set; }

        public virtual Edicion Edicion { get; set; }

        /// <summary>
        /// Código de inventario del ejemplar.
        /// Ambos, el id y este campo son posibles códigos de inventario.
        /// </summary>
        public string CodigoInventario { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public void DarDeBaja(IDateTimeProvider dateTimeProvider)
        {
            this.FechaBaja = dateTimeProvider.Now;
        }
    }
}