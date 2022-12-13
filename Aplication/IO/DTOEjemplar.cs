using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class DTOEjemplar
    {
        public string codigoInventario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DTOEdicion Edicion { get; set; }

        public DateTime FechaBaja { get; set; }

    }
}