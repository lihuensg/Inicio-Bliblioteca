using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Servicios.LibrosRemotos
{
    public interface IServiciosEdicion
    {
        Task<DTOEdicion> BuscarPorISBNAsync(string pISBN);
    }
}