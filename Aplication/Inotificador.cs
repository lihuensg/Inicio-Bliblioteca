using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
     interface INotificador
    {
         void Enviar(string destino,string asunto, string texto );
        
        
    }
}