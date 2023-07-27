using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class DTOEdicion
    {
        public string Isbn { get; set; }
        public int AñoEdicion { get; set; }
        public int NumeroPaginas { get; set; }
        public string Portada { get; set; }
        public string Id { get; set; }
        public string Autores { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Publicacion { get; set; }
        public string DatosAdicionales { get; set; }
    }
}