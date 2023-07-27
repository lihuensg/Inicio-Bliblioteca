using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL
{
    public interface IRepositorioEjemplares : IRepositorio<Ejemplar>
    {
        Ejemplar ObtenerPorCodigoInventario(string CodigoInventario);

        List<Ejemplar> ObtenerPorISBN(string ISBN);
    }
}