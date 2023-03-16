using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Servicios.LibrosRemotos
{
    public interface IServicesAutores
    {
         List<DTOAutor> Buscar (Dictionary<string,string> pFiltros);
    }
}