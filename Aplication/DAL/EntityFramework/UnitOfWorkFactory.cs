using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Crear()
        {
            return new UnitOfWork(new BibliotecaDbContext());
        }
    }
}
