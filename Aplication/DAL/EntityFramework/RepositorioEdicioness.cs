using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioEdiciones : Repository<Edicion, BibliotecaDbContext>, IRepositorioEdiciones
    {
        public RepositorioEdiciones(BibliotecaDbContext pDbContext) : base(pDbContext)
        {

        }

        public Edicion ObtenerPorISBN(string Isbn)
        {
            return iDbContext.Ediciones.Where(u => u.Isbn == Isbn).First();
        }
    }
}