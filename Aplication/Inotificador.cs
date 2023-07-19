using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface INotificador
    {
        bool EnviarGenerico(string titulo, string cuerpo, Usuario destinatario);
    }
}