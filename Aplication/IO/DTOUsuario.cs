using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class DTOUsuario
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int Puntaje { get; set; }

        
    }
}