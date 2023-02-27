using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class InicializadorDeContexto : DropCreateDatabaseAlways<BibliotecaDbContext>
    {
        protected override void Seed(BibliotecaDbContext context)
        {
            
            var admin = new Usuario
            {
                Dni = 0,
                NombreUsuario = "Administrador",
                Mail = "email@cambiar.com",
                Password = "administrador",
                FechaRegistro = DateTime.Now,
                Puntaje = 0,
                EsAdministrador = true
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}
