using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class DTOEdicion
    {
        public string Isbn { get; set; }
        public int AnioEdicion { get; set; }
        public int NumeroPaginas { get; set; }
        public string Portada { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DTOObra Obra { get;  set; }
        public string Id { get; set; }

    }
}