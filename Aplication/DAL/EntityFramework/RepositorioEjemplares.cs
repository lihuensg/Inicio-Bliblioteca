using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioEjemplares : Repository<Ejemplar, BibliotecaDbContext>, IRepositorioEjemplares
    {
        public RepositorioEjemplares(BibliotecaDbContext pDbContext) : base(pDbContext)
        {

        }

        public Ejemplar ObtenerPorCodigoInventario(string codigoInventario)
        {
            if (int.TryParse(codigoInventario, out int codigoInventarioInt))
            {
                // Tanto el id como el código de inventario cuentan como posible 
                // código de inventario.
                return iDbContext.Ejemplares
                                    .Where(u => u.CodigoInventario == codigoInventario
                                                || u.Id == codigoInventarioInt)
                                    .FirstOrDefault();
            }
            else
            {
                // solo el código de inventario cuenta como posible código de inventario.
                return iDbContext.Ejemplares.Where(u => u.CodigoInventario == codigoInventario)
                                            .FirstOrDefault();
            }
        }

        public List<Ejemplar> ObtenerPorISBN(string ISBN)
        {
            return iDbContext.Ejemplares.Where(u => u.Edicion.Isbn == ISBN).ToList();
        }
    }
}