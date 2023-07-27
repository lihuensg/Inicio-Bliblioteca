using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class DTOEjemplar
    {
        public string CodigoInventario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DTOEdicion Edicion { get; set; }
        public bool Prestado { get; set; }
        public string PrestadoA { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}