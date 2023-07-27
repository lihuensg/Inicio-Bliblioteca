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

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Autores { get; set; }

        /// <summary>
        /// Datos extra de la publicación como editorial, fecha de publicación, etc.
        /// </summary>
        public string Publicacion { get; set; }

        public string DatosAdicionales { get; set; }
    }
}