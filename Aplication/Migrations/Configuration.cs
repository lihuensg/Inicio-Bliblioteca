namespace Aplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aplication.DAL.EntityFramework.BibliotecaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aplication.DAL.EntityFramework.BibliotecaDbContext context)
        {
            
            //var admin = new Usuario
            //{
            //    Dni = 0,
            //    NombreUsuario = "Administrador",
            //    Mail = "email@cambiar.com",
            //    Password = "administrador",
            //    FechaRegistro = DateTime.Now,
            //    Puntaje = 0,
            //};
            
            //context.Usuarios.AddOrUpdate(u => u.NombreUsuario, admin);
            //context.SaveChanges();
        }
    }
}
