using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioPrestamos : Repository<Prestamo, BibliotecaDbContext>, IRepositorioPrestamos
    {
        public RepositorioPrestamos(BibliotecaDbContext pDbContext) : base(pDbContext)
        {

        }
    }
}