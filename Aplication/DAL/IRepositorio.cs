using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Aplication
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> Search(Expression<Func<T,bool>> predicate);

        void Agregar(T pItem);

        IEnumerable<T> ObtenerTodos();

        T Obtener(int id);
        void Eliminar(T elemento);
    }
}