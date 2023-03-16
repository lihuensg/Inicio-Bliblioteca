using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface INotificador
    {
         bool Enviar(string destinoMail, string destinoNombre, string asunto, string texto );
    }
}