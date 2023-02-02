using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioEjemplares : Repository<Ejemplar, BibliotecaDbContext>, IRepositorioEjemplares
    {
        public RepositorioEjemplares (BibliotecaDbContext pDbContext) : base(pDbContext)
        {
            
        }

        public Ejemplar ObtenerPorCodInv(string codigoInventario)
        {
            return iDbContext.Ejemplares.Where(u => u.CodigoInventario == codigoInventario).FirstOrDefault();
        }
    }
}