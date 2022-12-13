using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class Edicion
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public int AñoEdicion { get; set; }
        public int NumeroPaginas { get; set; }
        public string Portada { get; set; }
        public Obra Obra { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}