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
            var usuariosEncontrados = this.iDbContext.Usuarios.Where(u => u.NombreUsuario == NombreUsuario).ToList();
            if (usuariosEncontrados.Count == 0)
            {
                throw new Exception();
            }
            return usuariosEncontrados[0]; 
        }

        public Usuario ObtenerPorDNI(int dni)
        {
            var usuariosEncontrados = this.iDbContext.Usuarios.Where(u => u.Dni == dni).FirstOrDefault();
            return usuariosEncontrados; 
        }
    }
}