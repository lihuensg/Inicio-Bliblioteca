using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioUsuarios : Repository<Usuario, BibliotecaDbContext>, IRepositorioUsuarios
    {
        public RepositorioUsuarios (BibliotecaDbContext pDbContext) : base(pDbContext)
        {
            

        }
        
        public Usuario ObtenerPorNombreDeUsuario(string NombreUsuario)
        {
            return this.iDbContext.Usuarios.Where(u => u.NombreUsuario == NombreUsuario).FirstOrDefault();
        }

        public Usuario ObtenerPorDNI(int dni)
        {
            return this.iDbContext.Usuarios.Where(u => u.Dni == dni).FirstOrDefault();
        }

        public Usuario ObtenerPorMail(string mail)
        {
            return this.iDbContext.Usuarios.Where(u => u.Mail == mail).FirstOrDefault();
        }
    }
}