using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.SERVICE.Http
{
    public class ExcepcionRespuestaInvalida : Exception
    {
        public ExcepcionRespuestaInvalida()
        {
        }
         public ExcepcionRespuestaInvalida(string message) : base(message)
         {

         }
          public ExcepcionRespuestaInvalida(string message, Exception inner) : base(message, inner)
        {
        }

    }
}