using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Servicios.LibrosRemotos
{
    public interface IServicesEdicion
    {
        DTOEdicion Buscar(Dictionary<string, string> pFiltros);
    }
}