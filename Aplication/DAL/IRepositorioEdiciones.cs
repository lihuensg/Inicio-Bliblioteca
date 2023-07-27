using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL
{
    public interface IRepositorioEdiciones : IRepositorio<Edicion>
    {
        ///
        /// <summary>
        /// Obtiene una edicion por su ISBN
        /// </summary>
        /// <param name="Isbn">ISBN de la edicion</param>
        /// <returns>Edicion o nulo si no se encuentra</returns>
        Edicion ObtenerPorISBN(string Isbn);
    }
}