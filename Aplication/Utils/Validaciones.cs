using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Aplication.Utils
{
    public static class Validaciones
    {
        public static bool EsMailValido(string email)
        {
            // Expresión regular para validar la dirección de correo electrónico
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Comprobar si la dirección de correo electrónico coincide con el patrón
            return Regex.IsMatch(email, emailPattern);
        }
    }
    
}
