using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IRepositorioObras : IRepositorio<Obra>
    {
        /// <summary>
        /// Obtiene una obra por su Lccn
        /// </summary>
        /// <param name="Lccn">Lccn de la obra</param>
        /// <returns>Obra o nulo si no se encuentra</returns>
        Obra ObtenerPorLccn(string Lccn);
    }

}