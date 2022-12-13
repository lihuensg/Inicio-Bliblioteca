using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>
    {
        Usuario ObtenerPorNombreDeUsuario(string NombreUsuario);
        Usuario ObtenerPorDNI(int Dni);

    }
}