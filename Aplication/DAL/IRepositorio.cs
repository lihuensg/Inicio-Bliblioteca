using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Aplication.DAL
{
    public interface IRepositorio<T>
    {
        void Agregar(T pItem);

        IEnumerable<T> ObtenerTodos();

        T Obtener(int id);
        void Eliminar(T elemento);
    }
}