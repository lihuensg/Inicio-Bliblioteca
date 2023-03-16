using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Inicio_Bliblioteca.Utils {
    public class FormateoUtiles {
        public static String LimpiarGuionesISBN(String isbn) {
            // Buscar todas las coincidencias de números en la cadena de entrada
            var matches = Regex.Matches(isbn, @"\d+");

            // Concatenar los números encontrados en una sola cadena sin separadores
            var numeros = matches.Cast<Match>().Select(match => match.Value);
            return string.Join("", numeros);
        }
    }
}
