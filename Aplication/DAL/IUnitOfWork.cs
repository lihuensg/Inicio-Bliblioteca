using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioEjemplares RepositorioEjemplares { get; }

        IRepositorioObras RepositorioObras { get; }
        IRepositorioPrestamos RepositorioPrestamos { get; }

        IRepositorioUsuarios RepositorioUsuarios { get; }

        IRepositorioEdiciones RepositorioEdiciones { get; }

        IRepositorioNotificacionVencimientoPrestamo RepositorioNotificacionVencimientoPrestamo { get; }

        void Complete();
    }
}