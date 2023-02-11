using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class Ejemplar
    {
        public Ejemplar() { }

        public int Id { get; set; }

        public virtual Edicion Edicion { get; set; }
        public string CodigoInventario { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja {get; set;}

    }
}