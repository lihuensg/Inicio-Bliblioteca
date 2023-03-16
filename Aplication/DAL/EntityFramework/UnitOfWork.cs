using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        //Conexion a la base de datos//
        private readonly BibliotecaDbContext iDbContext;
        private bool iDisposedValue = false;

        public UnitOfWork(BibliotecaDbContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new NotImplementedException();
            }

            this.iDbContext = pDbContext;
            this.RepositorioEjemplares = new RepositorioEjemplares(pDbContext);
            this.RepositorioObras = new RepositorioObras(pDbContext);
            this.RepositorioPrestamos = new RepositorioPrestamos(pDbContext);
            this.RepositorioUsuarios = new RepositorioUsuarios(pDbContext);
            this.RepositorioEdiciones = new RepositorioEdiciones(pDbContext);
            this.RepositorioNotificacionVencimientoPrestamo = new RepositorioNotificacionVencimientoPrestamo(pDbContext);
        }

        public IRepositorioEjemplares RepositorioEjemplares { get; private set; }

        public IRepositorioObras RepositorioObras { get; private set; }
        public IRepositorioPrestamos RepositorioPrestamos { get; private set; }

        public IRepositorioUsuarios RepositorioUsuarios { get; private set; }
        public IRepositorioEdiciones RepositorioEdiciones { get; private set; }
        public IRepositorioNotificacionVencimientoPrestamo RepositorioNotificacionVencimientoPrestamo { get; private set; }

        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }

        protected virtual void Dispose(bool pDisposing)
        {
            if (!this.iDisposedValue)
            {
                if (pDisposing)
                {
                    this.iDbContext.Dispose();
                }

                this.iDisposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

    }
}