using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IRepositorioEjemplares : IRepositorio<Ejemplar>
    {
        Ejemplar ObtenerPorCodInv(string CodigoInventario);

        List<Ejemplar> ObtenerPorISBN(string ISBN);
    }
}