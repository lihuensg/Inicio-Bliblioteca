using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Aplication.DAL.EntityFramework
{
    public abstract class Repository<TEntity, TDbContext> : IRepositorio<TEntity> where TEntity : class
                                                                                 where TDbContext : DbContext
    {

        protected readonly TDbContext iDbContext;

        protected readonly DbSet<TEntity> iDbSet;
        public Repository(TDbContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new ArgumentNullException(nameof(pDbContext));
            }

            this.iDbContext = pDbContext;
            this.iDbSet = this.iDbContext.Set<TEntity>();
        }
        public void Agregar(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Obtener(int pId)
        {
            return this.iDbContext.Set<TEntity>().Find(pId);
        }

        public IEnumerable<TEntity> ObtenerTodos()
        {
            return this.iDbContext.Set<TEntity>();
        }

        public void Eliminar(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return iDbSet.Where(predicate).ToList();
        }

    }
}
