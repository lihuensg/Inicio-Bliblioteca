using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.SERVICE.Http
{
    public class ExcepcionConsultaWeb : Exception
    {
        public ExcepcionConsultaWeb()
        {
        }
         public ExcepcionConsultaWeb(string message) : base(message)
         {

         }
          public ExcepcionConsultaWeb(string message, Exception inner) : base(message, inner)
        {
        }
    }
}