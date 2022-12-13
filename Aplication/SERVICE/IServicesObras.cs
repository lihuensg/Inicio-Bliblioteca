using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IServicesObras
    {
        List<DTOObra> Buscar (Dictionary<string,string> pFiltros);
    }
}