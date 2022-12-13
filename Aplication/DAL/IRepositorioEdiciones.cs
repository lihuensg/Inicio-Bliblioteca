using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IRepositorioEdiciones : IRepositorio<Edicion>
    {
       Edicion ObtenerPorISBN(string Isbn);
    }
}