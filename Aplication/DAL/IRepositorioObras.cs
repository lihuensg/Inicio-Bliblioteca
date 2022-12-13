using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IRepositorioObras : IRepositorio<Obra>
    {
       Obra ObtenerPorLccn (string Lccn);
    }

}