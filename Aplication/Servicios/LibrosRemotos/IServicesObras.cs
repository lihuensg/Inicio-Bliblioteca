using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Servicios.LibrosRemotos 
{
    public interface IServicesObras
    {
        List<DTOObra> Buscar(Dictionary<string,string> pFiltros);
        DTOObra BuscarUnaObra(string pIdRemoto);
    }
}