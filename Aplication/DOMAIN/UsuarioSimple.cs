using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class UsuarioSimple : Usuario
    {
        public UsuarioSimple()
        {
            EsAdministrador = false;
        }
    }
}