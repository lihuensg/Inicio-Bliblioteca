using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DAL.EntityFramework.Mapping;

namespace Aplication.DAL.EntityFramework
{   
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Ejemplar> Ejemplares { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Edicion> Ediciones { get; set; }

        public DbSet<NotificacionVencimientoPrestamo> NotificacionVencimientoPrestamos { get; set; }
        public BibliotecaDbContext() : base("Aplication.Properties.Settings.bdBiblioConnectionString")
        {
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //cambiamos el nombre de la tabla//
            modelBuilder.Configurations.Add(new NotificacionVencimientoPrestamosConfiguration());
            modelBuilder.Entity<Obra>().ToTable("Obras");
            modelBuilder.Entity<Edicion>().ToTable("Ediciones");
            modelBuilder.Configurations.Add(new EjemplarConfiguration());
            modelBuilder.Configurations.Add(new EdicionConfiguration());
            modelBuilder.Configurations.Add(new ObraConfiguration());
            modelBuilder.Configurations.Add(new PrestamoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
        }

    }
}